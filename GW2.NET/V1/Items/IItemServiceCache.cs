// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for an items service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common.Caching;

    /// <summary>Provides the interface for an items service cache.</summary>
    public interface IItemServiceCache : IItemService
    {
        /// <summary>Gets a collection of discovered items.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        IEnumerable<int> GetItems(bool allowCache);

        /// <summary>Gets a collection of discovered items.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        Task<IEnumerable<int>> GetItemsAsync(bool allowCache);

        /// <summary>Gets a collection of discovered items.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        Task<IEnumerable<int>> GetItemsAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of discovered items.</summary>
        /// <param name="items">A collection of discovered items.</param>
        void SetItems(IEnumerable<int> items);

        /// <summary>Sets a collection of discovered items.</summary>
        /// <param name="items">A collection of discovered items.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetItems(IEnumerable<int> items, CacheItemParameters parameters);
    }
}