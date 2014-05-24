// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwContextInitializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The Guild Wars context initializer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Builds;
    using GW2DotNET.V1.Builds.Contracts;
    using GW2DotNET.V1.Items;
    using GW2DotNET.V1.Items.Details;
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    /// <summary>The Guild Wars context initializer.</summary>
    public class GwContextInitializer : DbMigrationsConfiguration<GwContext>
    {
        /// <summary>Initializes a new instance of the <see cref="GwContextInitializer" /> class.</summary>
        public GwContextInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>Runs after upgrading to the latest migration to allow seed data to be updated.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        protected override void Seed(GwContext context)
        {
            var cultures = new[]
                               {
                                   CultureInfo.GetCultureInfo("de"), 
                                   CultureInfo.GetCultureInfo("en"), 
                                   CultureInfo.GetCultureInfo("es"), 
                                   CultureInfo.GetCultureInfo("fr")
                               };

            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            this.SeedBuild(context);
            foreach (var culture in cultures)
            {
                this.SeedItems(context, culture);
            }
        }

        /// <summary>Ensures that the database has a reference to the latest game build number.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        private void SeedBuild(GwContext context)
        {
            var buildService = new BuildService();
            var build = buildService.GetBuild();

            if (context.Builds.Find(build.BuildId) == null)
            {
                context.Builds.Add(build);
                context.SaveChanges();
            }
        }

        /// <summary>Ensures that the database has an updated index of discovered items.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <param name="language">The language.</param>
        private void SeedItems(GwContext context, CultureInfo language)
        {
            var buildService = new BuildService();

            var itemService = new ItemService();

            var build = buildService.GetBuild();

            var allItemIds = itemService.GetItems().ToList();

            var knownItems = context.Items.Where(item => item.Language == language.TwoLetterISOLanguageName);

            var outdatedItemIds = knownItems.Where(item => item.BuildId < build.BuildId).Select(item => item.ItemId).ToList();

            if (outdatedItemIds.Any())
            {
                this.SeedItems(context, outdatedItemIds, language, build, true);
            }

            var unknownItemIds = allItemIds.Except(knownItems.Select(item => item.ItemId)).ToList();

            if (unknownItemIds.Any())
            {
                this.SeedItems(context, unknownItemIds, language, build, false);
            }
        }

        /// <summary>Updates or inserts the specified items.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <param name="itemIds">The item identifiers.</param>
        /// <param name="language">The language.</param>
        /// <param name="build">The build.</param>
        /// <param name="itemsExistsInDatabase">Indicates whether the specified item identifiers exist in the database.</param>
        private void SeedItems(GwContext context, IList<int> itemIds, CultureInfo language, Build build, bool itemsExistsInDatabase)
        {
            var itemDetailService = new ItemDetailsService();

            foreach (var partition in Partitioner.Create(0, itemIds.Count(), 100).GetDynamicPartitions())
            {
                var tasks = new List<Task<Item>>();

                for (var index = partition.Item1; index < partition.Item2; index++)
                {
                    tasks.Add(itemDetailService.GetItemDetailsAsync(itemIds[index], language));
                }

                // ReSharper disable once CoVariantArrayConversion
                Task.WaitAll(tasks.ToArray());

                var items = tasks.Where(t => t.IsCompleted).Select(task => task.Result).ToList();

                foreach (var item in items)
                {
                    item.BuildId = build.BuildId;

                    var upgradedItem = item as IUpgrade;
                    if (upgradedItem != null && upgradedItem.Attributes.Any())
                    {
                        var collection = new ItemAttributeCollection();
                        foreach (var attribute in upgradedItem.Attributes)
                        {
                            collection.Add(context.ItemAttributes.Find(attribute.Type, attribute.Modifier) ?? context.ItemAttributes.Add(attribute));
                        }

                        upgradedItem.Attributes = collection;
                    }

                    if (itemsExistsInDatabase)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Items.Add(item);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}