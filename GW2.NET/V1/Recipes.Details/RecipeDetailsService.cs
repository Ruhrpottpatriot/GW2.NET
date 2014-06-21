// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the recipe details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Recipes.Details.Contracts;

    /// <summary>Provides the default implementation of the recipe details service.</summary>
    public class RecipeDetailsService : IRecipeDetailsService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeDetailsService" /> class.</summary>
        public RecipeDetailsService()
            : this(new ServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RecipeDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RecipeDetailsService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipeId)
        {
            return this.GetRecipeDetails(recipeId, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipeId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new RecipeDetailsRequest { RecipeId = recipeId, Culture = language };
            var result = this.serviceClient.Send<Recipe>(serviceRequest);

            // patch missing language information
            result.Language = language.TwoLetterISOLanguageName;
            foreach (var ingredient in result.Ingredients)
            {
                ingredient.Language = language.TwoLetterISOLanguageName;
            }

            return result;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId)
        {
            return this.GetRecipeDetailsAsync(recipeId, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken cancellationToken)
        {
            return this.GetRecipeDetailsAsync(recipeId, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CultureInfo language)
        {
            return this.GetRecipeDetailsAsync(recipeId, language, CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipeId, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new RecipeDetailsRequest { RecipeId = recipeId, Culture = language };
            var t1 = this.serviceClient.SendAsync<Recipe>(serviceRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // patch missing language information
                        result.Language = language.TwoLetterISOLanguageName;
                        foreach (var ingredient in result.Ingredients)
                        {
                            ingredient.Language = language.TwoLetterISOLanguageName;
                        }

                        return result;
                    }, 
                cancellationToken);

            return t1;
        }
    }
}