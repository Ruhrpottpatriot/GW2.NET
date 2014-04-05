// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecipeServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a recipes service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for a recipes service cache.</summary>
    public interface IRecipeServiceCache : IRecipeService
    {
        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        IEnumerable<int> GetRecipes(bool allowCache);

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        Task<IEnumerable<int>> GetRecipesAsync(bool allowCache);

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        Task<IEnumerable<int>> GetRecipesAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of discovered recipes.</summary>
        /// <param name="recipes">A collection of discovered recipes.</param>
        void SetRecipes(IEnumerable<int> recipes);
    }
}