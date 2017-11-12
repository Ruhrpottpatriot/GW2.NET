// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateListingRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/commerce/prices interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;

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
    public class AggregateListingRepository : IAggregateListingRepository
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

        /// <summary>Initializes a new instance of the <see cref="AggregateListingRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public AggregateListingRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForAggregateListing())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AggregateListingRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForAggregateListing">The converter for <see cref="AggregateListing"/>.</param>
        internal AggregateListingRepository(IServiceClient serviceClient, IConverter<AggregateListingDataContract, AggregateListing> converterForAggregateListing)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForAggregateListing == null)
            {
                throw new ArgumentNullException("converterForAggregateListing", "Precondition: converterForAggregateListing != null");
            }

            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForCollectionResponse<int, int>(new ConverterAdapter<int>());
            this.converterForResponse = new ConverterForResponse<AggregateListingDataContract, AggregateListing>(converterForAggregateListing);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<AggregateListingDataContract, int, AggregateListing>(converterForAggregateListing, listing => listing.ItemId);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<AggregateListingDataContract, AggregateListing>(converterForAggregateListing);
        }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new AggregateListingDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IAggregateListingRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new AggregateListingDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        AggregateListing IRepository<int, AggregateListing>.Find(int identifier)
        {
            var request = new AggregateListingDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo)
            };
            var response = this.serviceClient.Send<AggregateListingDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, AggregateListing> IRepository<int, AggregateListing>.FindAll()
        {
            var request = new AggregateListingBulkRequest();
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, AggregateListing>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<int, AggregateListing> IRepository<int, AggregateListing>.FindAll(ICollection<int> identifiers)
        {
            var request = new AggregateListingBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };
            var response = this.serviceClient.Send<ICollection<AggregateListingDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, AggregateListing>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync()
        {
            IAggregateListingRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new AggregateListingBulkRequest();
            var response = await this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, AggregateListing>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(ICollection<int> identifiers)
        {
            IAggregateListingRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, AggregateListing>> IRepository<int, AggregateListing>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new AggregateListingBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };
            var response = await this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, AggregateListing>(0);
        }

        /// <inheritdoc />
        Task<AggregateListing> IRepository<int, AggregateListing>.FindAsync(int identifier)
        {
            IAggregateListingRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<AggregateListing> IRepository<int, AggregateListing>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new AggregateListingDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo)
            };
            var response = await this.serviceClient.SendAsync<AggregateListingDataContract>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        ICollectionPage<AggregateListing> IPaginator<AggregateListing>.FindPage(int pageIndex)
        {
            var request = new AggregateListingPageRequest
            {
                Page = pageIndex
            };
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
            var request = new AggregateListingPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
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
            IAggregateListingRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new AggregateListingPageRequest
            {
                Page = pageIndex
            };
            var response = await this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, int pageSize)
        {
            IAggregateListingRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<AggregateListing>> IPaginator<AggregateListing>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new AggregateListingPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = await this.serviceClient.SendAsync<ICollection<AggregateListingDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<AggregateListing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }
    }
}
