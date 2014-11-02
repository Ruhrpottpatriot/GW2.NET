// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriceRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/commerce/prices interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Entities.Commerce;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Commerce.Prices.Converters;
    using GW2NET.V2.Commerce.Prices.Json;
    using GW2NET.V2.Common;

    /// <summary>Represents a repository that retrieves data from the /v2/commerce/prices interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="AggregateListing.Item"/>:</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="AggregateListing.ItemId"/> to retrieve the <see cref="Item"/>.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    public class PriceRepository : IRepository<int, AggregateListing>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<AggregateListingDataContract>>, IDictionaryRange<int, AggregateListing>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<AggregateListingDataContract>>, ICollectionPage<AggregateListing>> converterForPageResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<AggregateListingDataContract>, AggregateListing> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="PriceRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public PriceRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForAggregateListing())
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="PriceRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForAggregateListing">The converter for <see cref="AggregateListing"/>.</param>
        internal PriceRepository(IServiceClient serviceClient, IConverter<AggregateListingDataContract, AggregateListing> converterForAggregateListing)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForAggregateListing != null);
            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForCollectionResponse<int, int>(new ConverterAdapter<int>());
            this.converterForResponse = new ConverterForResponse<AggregateListingDataContract, AggregateListing>(converterForAggregateListing);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<AggregateListingDataContract, int, AggregateListing>(converterForAggregateListing, listing => listing.ItemId);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<AggregateListingDataContract, AggregateListing>(converterForAggregateListing);
        }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new PriceDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IRepository<int, AggregateListing>)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new PriceDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        AggregateListing IRepository<int, AggregateListing>.Find(int identifier)
        {
            var request = new PriceDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo) };
            var response = this.serviceClient.Send<AggregateListingDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, AggregateListing> IRepository<int, AggregateListing>.FindAll()
        {
            var request = new PriceBulkRequest();
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, AggregateListing>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<int, AggregateListing> IRepository<int, AggregateListing>.FindAll(ICollection<int> identifiers)
        {
            var request = new PriceBulkRequest { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, AggregateListing>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync()
        {
            return ((IRepository<int, AggregateListing>)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new PriceBulkRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, AggregateListing>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IRepository<int, AggregateListing>)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new PriceBulkRequest { Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList() };
            var responseTask = this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, AggregateListing>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<AggregateListing> IRepository<int, AggregateListing>.FindAsync(int identifier)
        {
            return ((IRepository<int, AggregateListing>)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<AggregateListing> IRepository<int, AggregateListing>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new PriceDetailsRequest { Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo) };
            var responseTask = this.serviceClient.SendAsync<AggregateListingDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<AggregateListing>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<AggregateListing> IPaginator<AggregateListing>.FindPage(int pageIndex)
        {
            var request = new PricePageRequest { Page = pageIndex };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        ICollectionPage<AggregateListing> IPaginator<AggregateListing>.FindPage(int pageIndex, int pageSize)
        {
            var request = new PricePageRequest { Page = pageIndex, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex)
        {
            return ((IRepository<int, AggregateListing>)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new PricePageRequest { Page = pageIndex };
            var responseTask = this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IRepository<int, AggregateListing>)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new PricePageRequest { Page = pageIndex, PageSize = pageSize };
            var responseTask = this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            return this.converterForIdentifiersResponse.Convert(task.Result) ?? new List<int>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, AggregateListing> ConvertAsyncResponse(Task<IResponse<ICollection<AggregateListingDataContract>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<int, AggregateListing>>() != null);
            return this.converterForBulkResponse.Convert(task.Result) ?? new DictionaryRange<int, AggregateListing>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private AggregateListing ConvertAsyncResponse(Task<IResponse<AggregateListingDataContract>> task)
        {
            Contract.Requires(task != null);
            return this.converterForResponse.Convert(task.Result);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<AggregateListing> ConvertAsyncResponse(Task<IResponse<ICollection<AggregateListingDataContract>>> task, int pageIndex)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollectionPage<AggregateListing>>() != null);
            var values = this.converterForPageResponse.Convert(task.Result);
            if (values == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForBulkResponse != null);
            Contract.Invariant(this.converterForIdentifiersResponse != null);
            Contract.Invariant(this.converterForPageResponse != null);
            Contract.Invariant(this.converterForResponse != null);
        }
    }
}