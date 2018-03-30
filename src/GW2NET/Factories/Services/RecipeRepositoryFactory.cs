// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Common;
    using Common.Converters;
    using GW2NET.V2.Recipes;
    using GW2NET.V2.Recipes.Converters;
    using GW2NET.V2.Recipes.Json;
    using Items;
    using Recipes;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class RecipeRepositoryFactory : RepositoryFactoryBase<IRecipeRepository>
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public RecipeRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException(nameof(serviceClient));
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IRecipeRepository ForDefaultCulture()
        {
            var recipeConverterFactory = new RecipeConverterFactory();
            var craftingDisciplineCollectionConverter = new CraftingDisciplineCollectionConverter(new CraftingDisciplineConverter());
            var recipeFlagCollectionConverter = new RecipeFlagCollectionConverter(new RecipeFlagConverter());
            var itemStackCollectionConverter = new CollectionConverter<IngredientDTO, ItemQuantity>(new ItemQuantityConverter());
            var recipeConverter = new RecipeConverter(recipeConverterFactory, craftingDisciplineCollectionConverter, recipeFlagCollectionConverter, itemStackCollectionConverter);
            var identifiersResponseConverter = new ResponseConverter<ICollection<int>, ICollection<int>>(new ConverterAdapter<ICollection<int>>());
            var responseConverter = new ResponseConverter<RecipeDTO, Recipe>(recipeConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<RecipeDTO, int, Recipe>(recipeConverter, recipe => recipe.RecipeId);
            var pageResponseConverter = new CollectionPageResponseConverter<RecipeDTO, Recipe>(recipeConverter);
            return new RecipeRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IRecipeRepository ForCulture(CultureInfo culture)
        {
            IRecipeRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }
    }
}