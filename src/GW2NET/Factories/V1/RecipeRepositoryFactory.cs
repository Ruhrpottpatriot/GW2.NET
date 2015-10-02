// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.V1
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;
    using GW2NET.Recipes;
    using GW2NET.V1.Recipes;
    using GW2NET.V1.Recipes.Converters;
    using GW2NET.V1.Recipes.Json;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class RecipeRepositoryFactory
    {
        
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        public RecipeRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public IRecipeRepository this[string language]
        {
            get
            {
                if (language == null)
                {
                    throw new ArgumentNullException("language");
                }

                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IRecipeRepository this[CultureInfo culture]
        {
            get
            {
                if (culture == null)
                {
                    throw new ArgumentNullException("culture");
                }

                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public IRecipeRepository ForDefaultCulture()
        {
            var recipeCollectionConverter = new RecipeCollectionConverter();
            var recipeConverterFactory = new RecipeConverterFactory();
            var craftingDisciplineCollectionConverter = new CraftingDisciplineCollectionConverter(new CraftingDisciplineConverter());
            var recipeFlagCollectionConverter = new RecipeFlagCollectionConverter(new RecipeFlagConverter());
            var quantityCollectionConverter = new CollectionConverter<IngredientDTO, ItemQuantity>(new ItemQuantityConverter());
            var recipeConverter = new RecipeConverter(recipeConverterFactory, craftingDisciplineCollectionConverter, recipeFlagCollectionConverter, quantityCollectionConverter);
            return new RecipeRepository(this.serviceClient, recipeCollectionConverter, recipeConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IRecipeRepository ForCulture(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            IRecipeRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IRecipeRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public IRecipeRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}