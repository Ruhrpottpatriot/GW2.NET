// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwContextInitializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The Guild Wars context initializer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Persistence
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Builds;
    using GW2DotNET.V1.Builds.Contracts;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Items;
    using GW2DotNET.V1.Items.Details;
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;
    using GW2DotNET.V1.Recipes;
    using GW2DotNET.V1.Recipes.Details;
    using GW2DotNET.V1.Recipes.Details.Contracts;

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

            foreach (var culture in cultures)
            {
                this.SeedItems(context, culture);
                this.SeedRecipes(context, culture);
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

            var allItemIds = itemService.GetItems().Take(300).ToList();

            var knownItems = context.Items.Where(item => item.Language == language.TwoLetterISOLanguageName);

            var unknownItemIds = allItemIds.Except(knownItems.Select(item => item.ItemId)).ToList();

            if (unknownItemIds.Any())
            {
                this.SeedItems(context, unknownItemIds, language, build, false);
            }

            var outdatedItemIds = knownItems.Where(item => item.BuildId < build.BuildId).Select(item => item.ItemId).ToList();

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

                    if (itemsExistInDatabase)
                    {
                        this.Update(item, context);
                    }
                    else
                    {
                        this.Add(item, context);
                    }
                }

                context.SaveChanges();
            }
        }

        /// <summary>Updates or inserts the specified items.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <param name="itemIds">The item identifiers.</param>
        /// <param name="language">The language.</param>
        /// <param name="build">The build.</param>
        /// <param name="itemsExistInDatabase">Indicates whether the specified item identifiers exist in the database.</param>
        private void SeedItems(GwContext context, IList<int> itemIds, CultureInfo language, Build build, bool itemsExistInDatabase)
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

                    if (itemsExistInDatabase)
                    {
                        this.Update(item, context);
                    }
                    else
                    {
                        this.Add(item, context);
                    }
                }

                context.SaveChanges();
            }
        }

        /// <summary>Adds the specified item.</summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="Item"/>.</returns>
        private Item Add(Item item, GwContext context)
        {
            var upgradedItem = item as IUpgrade;
            if (upgradedItem != null && upgradedItem.Attributes.Any())
            {
                upgradedItem.Attributes = this.AddOrGetExisting(upgradedItem.Attributes, context);
            }

            return context.Items.Add(item);
        }

        /// <summary>Updates the specified item.</summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="Item"/>.</returns>
        private Item Update(Item item, GwContext context)
        {
            var upgradedItem = item as IUpgrade;
            if (upgradedItem != null && upgradedItem.Attributes.Any())
            {
                upgradedItem.Attributes = this.AddOrGetExisting(upgradedItem.Attributes, context);
            }

            item = context.Items.Attach(item);
            context.Entry(item).State = EntityState.Modified;

            return item;
        }

        /// <summary>Ensures that all entries in the specified collection exist in the database.</summary>
        /// <param name="itemAttributeCollection">The item attribute collection.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="ItemAttributeCollection"/>.</returns>
        private ItemAttributeCollection AddOrGetExisting(IEnumerable<ItemAttribute> itemAttributeCollection, GwContext context)
        {
            var collection = new ItemAttributeCollection();
            foreach (var attribute in itemAttributeCollection)
            {
                collection.Add(context.ItemAttributes.Find(attribute.Type, attribute.Modifier) ?? context.ItemAttributes.Add(attribute));
            }

            return collection;
        }


        /// <summary>Ensures that the database has an updated index of discovered recipes.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <param name="language">The language.</param>
        private void SeedRecipes(GwContext context, CultureInfo language)
        {
            var buildService = new BuildService();

            var recipeService = new RecipeService();

            var build = buildService.GetBuild();

            var allRecipeIds = recipeService.GetRecipes().Take(300).ToList();

            var knownRecipes = context.Recipes.Where(recipe => recipe.Language == language.TwoLetterISOLanguageName);

            var unknownRecipeIds = allRecipeIds.Except(knownRecipes.Select(recipe => recipe.RecipeId)).ToList();

            if (unknownRecipeIds.Any())
            {
                this.SeedRecipes(context, unknownRecipeIds, language, build, false);
            }

            var outdatedRecipeIds = knownRecipes.Where(recipe => recipe.BuildId < build.BuildId).Select(recipe => recipe.RecipeId).ToList();

            if (outdatedRecipeIds.Any())
            {
                this.SeedRecipes(context, outdatedRecipeIds, language, build, true);
            }
        }

        /// <summary>Updates or inserts the specified items.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <param name="itemIds">The item identifiers.</param>
        /// <param name="language">The language.</param>
        /// <param name="build">The build.</param>
        /// <param name="recipesExistInDatabase">Indicates whether the specified item identifiers exist in the database.</param>
        private void SeedRecipes(GwContext context, IList<int> itemIds, CultureInfo language, Build build, bool recipesExistInDatabase)
        {
            var recipeDetailsService = new RecipeDetailsService();

            var itemDetailsService = new ItemDetailsService();

            foreach (var partition in Partitioner.Create(0, itemIds.Count(), 100).GetDynamicPartitions())
            {
                var tasks = new List<Task<Recipe>>();

                for (var index = partition.Item1; index < partition.Item2; index++)
                {
                    tasks.Add(recipeDetailsService.GetRecipeDetailsAsync(itemIds[index], language));
                }

                // ReSharper disable once CoVariantArrayConversion
                Task.WaitAll(tasks.ToArray());

                var recipes = tasks.Where(t => t.IsCompleted).Select(task => task.Result).ToList();

                foreach (var recipe in recipes)
                {
                    recipe.BuildId = build.BuildId;

                    try
                    {
                        recipe.OutputItem = context.Items.Find(recipe.OutputItemId, recipe.Language) ?? this.Add(itemDetailsService.GetItemDetails(recipe.OutputItemId, language), context);

                        var ingredients = new IngredientCollection(recipe.Ingredients.Count);
                        foreach (var ingredient in recipe.Ingredients)
                        {
                            ingredients.Add(context.Ingredients.Find(ingredient.ItemId, ingredient.Count) ?? context.Ingredients.Add(ingredient));
                            ingredient.Item = context.Items.Find(ingredient.ItemId, ingredient.Language) ?? this.Add(itemDetailsService.GetItemDetails(ingredient.ItemId, language), context);
                        }

                        recipe.Ingredients = ingredients;

                        if (recipesExistInDatabase)
                        {
                            context.Entry(recipe).State = EntityState.Modified;
                        }
                        else
                        {
                            context.Recipes.Add(recipe);
                        }
                    }
                    catch (ServiceException)
                    {
                    }
                }

                context.SaveChanges();
            }
        }
    }
}