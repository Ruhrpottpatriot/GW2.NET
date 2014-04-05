// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecipeDetailsServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a recipe details service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Recipes.Details.Types;

    /// <summary>Provides the interface for a recipe details service cache.</summary>
    public interface IRecipeDetailsServiceCache : IRecipeDetailsService
    {
        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(int recipeId, bool allowCache);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(int recipeId, CultureInfo language, bool allowCache);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, bool allowCache);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, CultureInfo language, bool allowCache);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipeId">A recipe.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(int recipeId, CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a recipe and its localized details.</summary>
        /// <param name="recipe">A recipe.</param>
        /// <param name="language">The language.</param>
        void SetRecipeDetails(Recipe recipe, CultureInfo language);
    }
}