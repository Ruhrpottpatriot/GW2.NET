// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDiscoveryServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The recipe discovery service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Recipes
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>The recipe discovery service contract.</summary>
    [ContractClassFor(typeof(IRecipeDiscoveryService))]
    internal abstract class RecipeDiscoveryServiceContract : IRecipeDiscoveryService
    {
        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public ICollection<int> GetRecipes()
        {
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetRecipesAsync()
        {
            Contract.Ensures(Contract.Result<Task<ICollection<int>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<int>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<ICollection<int>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<int>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}