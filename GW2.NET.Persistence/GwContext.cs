// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwContext.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The Guild Wars database context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Persistence
{
    using System.Data.Common;
    using System.Data.Entity;

    using GW2DotNET.Persistence.Configuration;
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;
    using GW2DotNET.V1.Recipes.Details.Contracts;

    /// <summary>The Guild Wars database context.</summary>
    public class GwContext : DbContext
    {
        /// <summary>Initializes static members of the <see cref="GwContext"/> class.</summary>
        static GwContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GwContext, GwContextInitializer>());
        }

        /// <summary>Initializes a new instance of the <see cref="GwContext"/> class.</summary>
        public GwContext()
        {
            this.ItemAttributes = this.Set<ItemAttribute>();
            this.Ingredients = this.Set<Ingredient>();
        }

        /// <summary>Initializes a new instance of the <see cref="GwContext"/> class.</summary>
        /// <param name="nameOrConnectionString">The connection string or connection string name.</param>
        public GwContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this.ItemAttributes = this.Set<ItemAttribute>();
            this.Ingredients = this.Set<Ingredient>();
        }

        /// <summary>Initializes a new instance of the <see cref="GwContext"/> class. Constructs a new context instance using the existing connection to connect to a database.</summary>
        /// <param name="existingConnection">An existing connection to use for the new context.</param>
        /// <param name="contextOwnsConnection">If set to true the connection is disposed when the context is disposed, otherwise the caller must dispose the connection.</param>
        public GwContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            this.ItemAttributes = this.Set<ItemAttribute>();
        }

        /// <summary>Gets or sets the items.</summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>Gets or sets the recipes.</summary>
        public DbSet<Recipe> Recipes { get; set; }

        /// <summary>Gets or sets the ingredients.</summary>
        internal DbSet<Ingredient> Ingredients { get; set; }

        /// <summary>Gets or sets the item attributes.</summary>
        internal DbSet<ItemAttribute> ItemAttributes { get; set; }

        /// <summary>This method is called when the model for a derived context has been initialized, but before the model has been locked down and used to initialize the context.</summary>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context is created.  The model for that context is then cached and is for all further instances of the context in the app domain.  This caching can be disabled by setting the ModelCaching property on the given ModelBuilder, but note that this can seriously degrade performance. More control over caching is provided through use of the ModelBuilder and ContextFactory classes directly.</remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new EquipmentConfiguration());
            modelBuilder.Configurations.Add(new UpgradeComponentConfiguration());
            modelBuilder.Configurations.Add(new ItemAttributeConfiguration());
            modelBuilder.Configurations.Add(new RecipeConfiguration());
            modelBuilder.Configurations.Add(new IngredientConfiguration());
        }
    }
}