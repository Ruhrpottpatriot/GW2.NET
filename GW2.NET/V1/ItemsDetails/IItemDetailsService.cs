// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemDetailsService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the item details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.ItemsDetails.Types;

    /// <summary>Provides the interface for the item details service.</summary>
    public interface IItemDetailsService
    {
        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Item GetItemDetails(int itemId);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Item GetItemDetails(int itemId, CultureInfo language);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, CancellationToken cancellationToken);

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="itemId">The item ID.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        Task<Item> GetItemDetailsAsync(int itemId, CultureInfo language, CancellationToken cancellationToken);
    }
}