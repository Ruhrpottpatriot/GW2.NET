// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the items service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Items.Contracts;

    /// <summary>Provides the default implementation of the items service.</summary>
    public class ItemService : IItemService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly ItemSerializerSettings Settings = new ItemSerializerSettings();

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(Item item)
        {
            return this.GetItemDetails(item, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Item GetItemDetails(Item item, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "item", value: item);
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new ItemDetailsRequest { ItemId = item.ItemId, Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<Item>(Settings));

            // Patch missing language information
            result.Language = language.TwoLetterISOLanguageName;

            // Patch empty descriptions
            if (result.Description != null && result.Description == string.Empty)
            {
                result.Description = null;
            }

            return result;
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(Item item)
        {
            return this.GetItemDetailsAsync(item, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(Item item, CultureInfo language)
        {
            return this.GetItemDetailsAsync(item, language, CancellationToken.None);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(Item item, CancellationToken cancellationToken)
        {
            return this.GetItemDetailsAsync(item, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets an item and its localized details.</summary>
        /// <param name="item">The item identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public Task<Item> GetItemDetailsAsync(Item item, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "item", value: item);
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new ItemDetailsRequest { ItemId = item.ItemId, Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<Item>(Settings), cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Patch missing language information
                        result.Language = language.TwoLetterISOLanguageName;

                        // Patch empty descriptions
                        if (result.Description != null && result.Description == string.Empty)
                        {
                            result.Description = null;
                        }

                        return result;
                    }, 
                cancellationToken);

            return t1;
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public IEnumerable<Item> GetItems()
        {
            var request = new ItemRequest();
            var result = this.serviceClient.Send(request, new JsonSerializer<ItemCollectionResult>());

            return result.Items;
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            return this.GetItemsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of item identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of item identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Item>> GetItemsAsync(CancellationToken cancellationToken)
        {
            var request = new ItemRequest();
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<ItemCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Item>>(task => task.Result.Items, cancellationToken);

            return t2;
        }
    }
}