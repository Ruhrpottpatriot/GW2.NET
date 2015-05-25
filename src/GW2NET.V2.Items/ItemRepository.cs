// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/items interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;

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
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<ItemDataContract>>, IDictionaryRange<int, Item>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<ItemDataContract>>, ICollectionPage<Item>> converterForPageResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ItemDataContract>, Item> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<int>>(), new ConverterForItem())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForItemCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        /// <param name="converterForItem">The converter for <see cref="Item"/>.</param>
        internal ItemRepository(IServiceClient serviceClient, IConverter<ICollection<int>, ICollection<int>> converterForItemCollection, IConverter<ItemDataContract, Item> converterForItem)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForItemCollection == null)
            {
                throw new ArgumentNullException("converterForItemCollection", "Precondition: converterForItemCollection != null");
            }

            if (converterForItem == null)
            {
                throw new ArgumentNullException("converterForItem", "Precondition: converterForItem != null");
            }

            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForResponse<ICollection<int>, ICollection<int>>(converterForItemCollection);
            this.converterForResponse = new ConverterForResponse<ItemDataContract, Item>(converterForItem);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<ItemDataContract, int, Item>(converterForItem, item => item.ItemId);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<ItemDataContract, Item>(converterForItem);
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new ItemDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.converterForIdentifiersResponse.Convert(response, null) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IItemRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ItemDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
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
            var response = this.serviceClient.Send<ItemDataContract>(request);
            return this.converterForResponse.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Item> IRepository<int, Item>.FindAll()
        {
            IItemRepository self = this;
            var request = new ItemBulkRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<ItemDataContract>>(request);
            return this.converterForBulkResponse.Convert(response, null);
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
            var response = this.serviceClient.Send<ICollection<ItemDataContract>>(request);
            return this.converterForBulkResponse.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Item>> IRepository<int, Item>.FindAllAsync()
        {
            IItemRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Item>> IRepository<int, Item>.FindAllAsync(CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemBulkRequest
            {
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ItemDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Item>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Item>> IRepository<int, Item>.FindAllAsync(ICollection<int> identifiers)
        {
            IItemRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Item>> IRepository<int, Item>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ItemDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Item>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<Item> IRepository<int, Item>.FindAsync(int identifier)
        {
            IItemRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Item> IRepository<int, Item>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ItemDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<Item>(this.ConvertAsyncResponse, cancellationToken);
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
            var response = this.serviceClient.Send<ICollection<ItemDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response, null);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
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
            var response = this.serviceClient.Send<ICollection<ItemDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response, null);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Item>> IPaginator<Item>.FindPageAsync(int pageIndex)
        {
            IItemRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Item>> IPaginator<Item>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemPageRequest
            {
                Page = pageIndex,
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ItemDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Item>> IPaginator<Item>.FindPageAsync(int pageIndex, int pageSize)
        {
            IItemRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Item>> IPaginator<Item>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IItemRepository self = this;
            var request = new ItemPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ItemDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, Item> ConvertAsyncResponse(Task<IResponse<ICollection<ItemDataContract>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.converterForBulkResponse.Convert(task.Result, null);
            if (values == null)
            {
                return new DictionaryRange<int, Item>(0);
            }

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Item> ConvertAsyncResponse(Task<IResponse<ICollection<ItemDataContract>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.converterForPageResponse.Convert(task.Result, null);
            if (values == null)
            {
                return new CollectionPage<Item>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var ids = this.converterForIdentifiersResponse.Convert(task.Result, null);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Item ConvertAsyncResponse(Task<IResponse<ItemDataContract>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.converterForResponse.Convert(task.Result, null);
        }
    }
}