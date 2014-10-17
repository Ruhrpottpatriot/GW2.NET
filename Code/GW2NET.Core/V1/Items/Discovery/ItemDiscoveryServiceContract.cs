// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDiscoveryServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The item discovery service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>The item discovery service contract.</summary>
    [ContractClassFor(typeof(IItemDiscoveryService))]
    internal abstract class ItemDiscoveryServiceContract : IItemDiscoveryService
    {
        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public ICollection<int> GetItems()
        {
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetItemsAsync()
        {
            Contract.Ensures(Contract.Result<Task<ICollection<int>>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetItemsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<ICollection<int>>>() != null);
            throw new System.NotImplementedException();
        }
    }
}