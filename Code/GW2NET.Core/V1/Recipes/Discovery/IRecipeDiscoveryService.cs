// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecipeDiscoveryService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the recipe discovery service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Recipes
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for the recipe discovery service.</summary>
    [ContractClass(typeof(ContractClassForIRecipeDiscoveryService))]
    public interface IRecipeDiscoveryService
    {
        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        ICollection<int> GetRecipes();

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        Task<ICollection<int>> GetRecipesAsync();

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        Task<ICollection<int>> GetRecipesAsync(CancellationToken cancellationToken);
    }
}