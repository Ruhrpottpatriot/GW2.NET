﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecipeDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the recipe details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Recipes.Details.Contracts;

    /// <summary>Provides the interface for the recipe details service.</summary>
    public interface IRecipeDetailsService
    {
        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(Recipe recipe);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Recipe GetRecipeDetails(Recipe recipe, CultureInfo language);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(Recipe recipe);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CancellationToken cancellationToken);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CultureInfo language);

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        Task<Recipe> GetRecipeDetailsAsync(Recipe recipe, CultureInfo language, CancellationToken cancellationToken);
    }
}