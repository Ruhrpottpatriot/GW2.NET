// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateListingRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/commerce/prices interface. See the remarks section for important limitations regarding this implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Commerce.Prices.Json;

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
        private readonly IConverter<IResponse<ICollection<AggregateListingDTO>>, IDictionaryRange<int, AggregateListing>> bulkResponseConverter;

        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        private readonly IConverter<IResponse<ICollection<AggregateListingDTO>>, ICollectionPage<AggregateListing>> pageResponseConverter;

        private readonly IConverter<IResponse<AggregateListingDTO>, AggregateListing> responseConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="AggregateListingRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        public AggregateListingRepository(
            IServiceClient serviceClient,
            IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter,
            IConverter<IResponse<AggregateListingDTO>, AggregateListing> responseConverter,
            IConverter<IResponse<ICollection<AggregateListingDTO>>, IDictionaryRange<int, AggregateListing>> bulkResponseConverter,
            IConverter<IResponse<ICollection<AggregateListingDTO>>, ICollectionPage<AggregateListing>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException(nameof(serviceClient));
            }

            if (identifiersResponseConverter == null)
            {
                throw new ArgumentNullException(nameof(identifiersResponseConverter));
            }

            if (responseConverter == null)
            {
                throw new ArgumentNullException(nameof(responseConverter));
            }

            if (bulkResponseConverter == null)
            {
                throw new ArgumentNullException(nameof(bulkResponseConverter));
            }

            if (pageResponseConverter == null)
            {
                throw new ArgumentNullException(nameof(pageResponseConverter));
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = identifiersResponseConverter;
            this.responseConverter = responseConverter;
            this.bulkResponseConverter = bulkResponseConverter;
            this.pageResponseConverter = pageResponseConverter;
        }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new AggregateListingDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersResponseConverter.Convert(response, null);
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
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        AggregateListing IRepository<int, AggregateListing>.Find(int identifier)
        {
            var request = new AggregateListingDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo)
            };
            var response = this.serviceClient.Send<AggregateListingDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, AggregateListing> IRepository<int, AggregateListing>.FindAll()
        {
            var request = new AggregateListingBulkRequest();
            var response = this.serviceClient.Send<ICollection<AggregateListingDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, AggregateListing> IRepository<int, AggregateListing>.FindAll(ICollection<int> identifiers)
        {
            var request = new AggregateListingBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };
            var response = this.serviceClient.Send<ICollection<AggregateListingDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
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
            var response = await this.serviceClient.SendAsync<ICollection<AggregateListingDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
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
            var response = await this.serviceClient.SendAsync<ICollection<AggregateListingDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
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
            var response = await this.serviceClient.SendAsync<AggregateListingDTO>(request, cancellationToken).ConfigureAwait(false);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        ICollectionPage<AggregateListing> IPaginator<AggregateListing>.FindPage(int pageIndex)
        {
            var request = new AggregateListingPageRequest
            {
                Page = pageIndex
            };
            var response = this.serviceClient.Send<ICollection<AggregateListingDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        ICollectionPage<AggregateListing> IPaginator<AggregateListing>.FindPage(int pageIndex, int pageSize)
        {
            var request = new AggregateListingPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = this.serviceClient.Send<ICollection<AggregateListingDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
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
            var response = await this.serviceClient.SendAsync<ICollection<AggregateListingDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
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
            var response = await this.serviceClient.SendAsync<ICollection<AggregateListingDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }
    }
}