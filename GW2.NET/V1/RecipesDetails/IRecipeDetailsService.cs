// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecipeDetailsService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the recipe details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.RecipesDetails
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.RecipesDetails.Types;

    /// <summary>Provides the interface for the recipe details service.</summary>
    public interface IRecipeDetailsService
    {
        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(int recipeId);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(int recipeId, CultureInfo language);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken cancellationToken);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, CultureInfo language);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, CultureInfo language, CancellationToken cancellationToken);
    }
}