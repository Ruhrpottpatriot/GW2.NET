// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListingRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/commerce/listings interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Listings
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

    /// <summary>Represents a repository that retrieves data from the /v2/commerce/listings interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="Listing.Item"/>:</term>
    ///         <description>Always <c>null</c>. Use the value of <see cref="Listing.ItemId"/> to retrieve the <see cref="Item"/>.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    public class ListingRepository : IListingRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<ListingDataContract>>, IDictionaryRange<int, Listing>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<ListingDataContract>>, ICollectionPage<Listing>> converterForPageResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ListingDataContract>, Listing> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ListingRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ListingRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForListing())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ListingRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForListing">The converter for <see cref="Listing"/>.</param>
        internal ListingRepository(IServiceClient serviceClient, IConverter<ListingDataContract, Listing> converterForListing)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForListing == null)
            {
                throw new ArgumentNullException("converterForListing", "Precondition: converterForListing != null");
            }

            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForCollectionResponse<int, int>(new ConverterAdapter<int>());
            this.converterForResponse = new ConverterForResponse<ListingDataContract, Listing>(converterForListing);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<ListingDataContract, int, Listing>(converterForListing, listing => listing.ItemId);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<ListingDataContract, Listing>(converterForListing);
        }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new ListingDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            var values = this.converterForIdentifiersResponse.Convert(response);
            return values ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IListingRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ListingDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Listing IRepository<int, Listing>.Find(int identifier)
        {
            var request = new ListingDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo)
            };
            var response = this.serviceClient.Send<ListingDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Listing> IRepository<int, Listing>.FindAll()
        {
            var request = new ListingBulkRequest();
            var response = this.serviceClient.Send<ICollection<ListingDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, Listing>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Listing> IRepository<int, Listing>.FindAll(ICollection<int> identifiers)
        {
            var request = new ListingBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };
            var response = this.serviceClient.Send<ICollection<ListingDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, Listing>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Listing>> IRepository<int, Listing>.FindAllAsync()
        {
            IListingRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Listing>> IRepository<int, Listing>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ListingBulkRequest();
            var response = await this.serviceClient.SendAsync<ICollection<ListingDataContract>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, Listing>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Listing>> IRepository<int, Listing>.FindAllAsync(ICollection<int> identifiers)
        {
            IListingRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Listing>> IRepository<int, Listing>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new ListingBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };
            var response = await this.serviceClient.SendAsync<ICollection<ListingDataContract>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<int, Listing>(0);
        }

        /// <inheritdoc />
        Task<Listing> IRepository<int, Listing>.FindAsync(int identifier)
        {
            IListingRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Listing> IRepository<int, Listing>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new ListingDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo)
            };
            var response = await this.serviceClient.SendAsync<ListingDataContract>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        ICollectionPage<Listing> IPaginator<Listing>.FindPage(int pageIndex)
        {
            var request = new ListingPageRequest
            {
                Page = pageIndex
            };
            var response = this.serviceClient.Send<ICollection<ListingDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Listing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        ICollectionPage<Listing> IPaginator<Listing>.FindPage(int pageIndex, int pageSize)
        {
            var request = new ListingPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = this.serviceClient.Send<ICollection<ListingDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Listing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Listing>> IPaginator<Listing>.FindPageAsync(int pageIndex)
        {
            IListingRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Listing>> IPaginator<Listing>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new ListingPageRequest
            {
                Page = pageIndex
            };
            var response = await this.serviceClient.SendAsync<ICollection<ListingDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Listing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Listing>> IPaginator<Listing>.FindPageAsync(int pageIndex, int pageSize)
        {
            IListingRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Listing>> IPaginator<Listing>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new ListingPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = await this.serviceClient.SendAsync<ICollection<ListingDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Listing>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }
    }
}