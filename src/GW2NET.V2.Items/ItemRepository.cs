// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/items interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/items interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// <list type="bullet">
    ///     <item>
    ///         <description><see cref="Item"/>: <see cref="Item.BuildId"/> is always <c>0</c>. Retrieve the build number from the build service.</description>
    ///     </item>
    ///     <item>
    ///         <description><see cref="ISkinnable"/>: <see cref="ISkinnable.DefaultSkin"/> is always <c>null</c>. Use the value of <see cref="ISkinnable.DefaultSkinId"/> to retrieve the skin (applies to <see cref="Armor"/>, <see cref="Backpack"/>, <see cref="GatheringTool"/> and <see cref="Weapon"/>).</description>
    ///     </item>
    ///     <item>
    ///         <description><see cref="IUpgradable"/>: <see cref="IUpgradable.SuffixItem"/> is always <c>null</c>. Use the value of <see cref="IUpgradable.SuffixItemId"/> to retrieve the suffix item (applies to <see cref="Armor"/>, <see cref="Backpack"/>, <see cref="Trinket"/> and <see cref="Weapon"/>).</description>
    ///     </item>
    ///     <item>
    ///         <description><see cref="IUpgradable"/>: <see cref="IUpgradable.SecondarySuffixItem"/> is always <c>null</c>. Use the value of <see cref="IUpgradable.SecondarySuffixItemId"/> to retrieve the secondary suffix item (applies to <see cref="Armor"/>, <see cref="Backpack"/>, <see cref="Trinket"/> and <see cref="Weapon"/>).</description>
    ///     </item>
    ///     <item>
    ///         <description><see cref="InfusionSlot"/>: <see cref="InfusionSlot.Item"/> is always <c>null</c>. Use the value of <see cref="InfusionSlot.ItemId"/> to retrieve the infusion item.</description>
    ///     </item>
    ///     <item>
    ///         <description><see cref="DyeUnlocker"/>: <see cref="DyeUnlocker.Color"/> is always <c>null</c>. Use the value of <see cref="DyeUnlocker.ColorId"/> to retrieve the color.</description>
    ///     </item>
    ///     <item>
    ///         <description><see cref="CraftingRecipeUnlocker"/>: <see cref="CraftingRecipeUnlocker.Recipe"/> is always <c>null</c>. Use the value of <see cref="CraftingRecipeUnlocker.RecipeId"/> to retrieve the recipe.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    public class ItemRepository : IItemRepository
    {
        private readonly IConverter<IResponse<ICollection<ItemDTO>>, IDictionaryRange<int, Item>> bulkResponseConverter;

        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        private readonly IConverter<IResponse<ICollection<ItemDTO>>, ICollectionPage<Item>> pageResponseConverter;

        private readonly IConverter<IResponse<ItemDTO>, Item> responseConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        public ItemRepository(
            IServiceClient serviceClient,
            IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter,
            IConverter<IResponse<ItemDTO>, Item> responseConverter,
            IConverter<IResponse<ICollection<ItemDTO>>, IDictionaryRange<int, Item>> bulkResponseConverter,
            IConverter<IResponse<ICollection<ItemDTO>>, ICollectionPage<Item>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (identifiersResponseConverter == null)
            {
                throw new ArgumentNullException("identifiersResponseConverter");
            }

            if (responseConverter == null)
            {
                throw new ArgumentNullException("responseConverter");
            }

            if (bulkResponseConverter == null)
            {
                throw new ArgumentNullException("bulkResponseConverter");
            }

            if (pageResponseConverter == null)
            {
                throw new ArgumentNullException("pageResponseConverter");
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = identifiersResponseConverter;
            this.responseConverter = responseConverter;
            this.bulkResponseConverter = bulkResponseConverter;
            this.pageResponseConverter = pageResponseConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new ItemDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IItemRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ItemDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Item IRepository<int, Item>.Find(int identifier)
        {
            IItemRepository self = this;
            var request = new ItemDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ItemDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Item> IRepository<int, Item>.FindAll()
        {
            IItemRepository self = this;
            var request = new ItemBulkRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<ItemDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Item> IRepository<int, Item>.FindAll(ICollection<int> identifiers)
        {
            IItemRepository self = this;
            var request = new ItemBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<ItemDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Item>> IRepository<int, Item>.FindAllAsync()
        {
            IItemRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Item>> IRepository<int, Item>.FindAllAsync(CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemBulkRequest
            {
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ItemDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Item>> IRepository<int, Item>.FindAllAsync(ICollection<int> identifiers)
        {
            IItemRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Item>> IRepository<int, Item>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ItemDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<Item> IRepository<int, Item>.FindAsync(int identifier)
        {
            IItemRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Item> IRepository<int, Item>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ItemDTO>(request, cancellationToken).ConfigureAwait(false);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        ICollectionPage<Item> IPaginator<Item>.FindPage(int pageIndex)
        {
            IItemRepository self = this;
            var request = new ItemPageRequest
            {
                Page = pageIndex,
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<ItemDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        ICollectionPage<Item> IPaginator<Item>.FindPage(int pageIndex, int pageSize)
        {
            IItemRepository self = this;
            var request = new ItemPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<ItemDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Item>> IPaginator<Item>.FindPageAsync(int pageIndex)
        {
            IItemRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Item>> IPaginator<Item>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemPageRequest
            {
                Page = pageIndex,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ItemDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Item>> IPaginator<Item>.FindPageAsync(int pageIndex, int pageSize)
        {
            IItemRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Item>> IPaginator<Item>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<ItemDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }
    }
}