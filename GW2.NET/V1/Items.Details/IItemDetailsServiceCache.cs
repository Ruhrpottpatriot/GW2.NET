// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemDetailsServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for an item details service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Items.Details.Types;

    /// <summary>Provides the interface for an item details service cache.</summary>
    public interface IItemDetailsServiceCache : IItemDetailsService
    {
        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Item GetItemDetails(int itemId, bool allowCache);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Item GetItemDetails(int itemId, CultureInfo language, bool allowCache);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, bool allowCache);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language, bool allowCache);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets an item and its localized details.</summary>
        /// <param name="item">An item and its localized details.</param>
        /// <param name="language">The language.</param>
        void SetItemDetails(Item item, CultureInfo language);
    }
}