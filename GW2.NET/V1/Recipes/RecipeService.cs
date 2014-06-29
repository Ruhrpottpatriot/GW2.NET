// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the recipe service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Recipes.Contracts;

    /// <summary>Provides the default implementation of the recipe service.</summary>
    public class RecipeService : IRecipeService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly RecipeSerializerSettings Settings = new RecipeSerializerSettings();

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RecipeService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(Recipe recipe)
        {
            return this.GetRecipeDetails(recipe, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(Recipe recipe, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "recipe", value: recipe);
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new RecipeDetailsRequest { RecipeId = recipe.RecipeId, Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<Recipe>(Settings));

            // Patch missing language information
            result.Language = language.TwoLetterISOLanguageName;

            return result;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe)
        {
            return this.GetRecipeDetailsAsync(recipe, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CancellationToken cancellationToken)
        {
            return this.GetRecipeDetailsAsync(recipe, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CultureInfo language)
        {
            return this.GetRecipeDetailsAsync(recipe, language, CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "recipe", value: recipe);
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new RecipeDetailsRequest { RecipeId = recipe.RecipeId, Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<Recipe>(Settings), cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Patch missing language information
                        result.Language = language.TwoLetterISOLanguageName;

                        return result;
                    }, 
                cancellationToken);

            return t1;
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public IEnumerable<Recipe> GetRecipes()
        {
            var request = new RecipeRequest();
            var result = this.serviceClient.Send(request, new JsonSerializer<RecipeCollectionResult>());

            return result.Recipes;
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return this.GetRecipesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Recipe>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            var request = new RecipeRequest();
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<RecipeCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Recipe>>(task => task.Result.Recipes, cancellationToken);

            return t2;
        }
    }
}