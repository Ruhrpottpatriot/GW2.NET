// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListingRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
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
    using GW2NET.V2.Commerce.Listings.Json;

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
        private readonly IConverter<IResponse<ICollection<ListingDTO>>, IDictionaryRange<int, Listing>> bulkResponseConverter;

        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        private readonly IConverter<IResponse<ICollection<ListingDTO>>, ICollectionPage<Listing>> pageResponseConverter;

        private readonly IConverter<IResponse<ListingDTO>, Listing> responseConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ListingRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ListingRepository(
            IServiceClient serviceClient,
            IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter,
            IConverter<IResponse<ListingDTO>, Listing> responseConverter,
            IConverter<IResponse<ICollection<ListingDTO>>, IDictionaryRange<int, Listing>> bulkResponseConverter,
            IConverter<IResponse<ICollection<ListingDTO>>, ICollectionPage<Listing>> pageResponseConverter)
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
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new ListingDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            var values = this.identifiersResponseConverter.Convert(response, null);
            return values ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IListingRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ListingDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Listing IRepository<int, Listing>.Find(int identifier)
        {
            var request = new ListingDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo)
            };
            var response = this.serviceClient.Send<ListingDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Listing> IRepository<int, Listing>.FindAll()
        {
            var request = new ListingBulkRequest();
            var response = this.serviceClient.Send<ICollection<ListingDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null) ?? new DictionaryRange<int, Listing>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Listing> IRepository<int, Listing>.FindAll(ICollection<int> identifiers)
        {
            var request = new ListingBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };
            var response = this.serviceClient.Send<ICollection<ListingDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null) ?? new DictionaryRange<int, Listing>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Listing>> IRepository<int, Listing>.FindAllAsync()
        {
            IListingRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Listing>> IRepository<int, Listing>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ListingBulkRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<ListingDTO>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Listing>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Listing>> IRepository<int, Listing>.FindAllAsync(ICollection<int> identifiers)
        {
            IListingRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Listing>> IRepository<int, Listing>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new ListingBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ListingDTO>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Listing>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<Listing> IRepository<int, Listing>.FindAsync(int identifier)
        {
            IListingRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Listing> IRepository<int, Listing>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new ListingDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo)
            };
            var responseTask = this.serviceClient.SendAsync<ListingDTO>(request, cancellationToken);
            return responseTask.ContinueWith<Listing>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Listing> IPaginator<Listing>.FindPage(int pageIndex)
        {
            var request = new ListingPageRequest
            {
                Page = pageIndex
            };
            var response = this.serviceClient.Send<ICollection<ListingDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Listing>(0);
        }

        /// <inheritdoc />
        ICollectionPage<Listing> IPaginator<Listing>.FindPage(int pageIndex, int pageSize)
        {
            var request = new ListingPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = this.serviceClient.Send<ICollection<ListingDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Listing>(0);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Listing>> IPaginator<Listing>.FindPageAsync(int pageIndex)
        {
            IListingRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Listing>> IPaginator<Listing>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new ListingPageRequest
            {
                Page = pageIndex
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ListingDTO>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Listing>> IPaginator<Listing>.FindPageAsync(int pageIndex, int pageSize)
        {
            IListingRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Listing>> IPaginator<Listing>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new ListingPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<ListingDTO>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.identifiersResponseConverter.Convert(task.Result, null) ?? new List<int>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, Listing> ConvertAsyncResponse(Task<IResponse<ICollection<ListingDTO>>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.bulkResponseConverter.Convert(task.Result, null) ?? new DictionaryRange<int, Listing>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Listing ConvertAsyncResponse(Task<IResponse<ListingDTO>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.responseConverter.Convert(task.Result, null);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Listing> ConvertAsyncResponse(Task<IResponse<ICollection<ListingDTO>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.pageResponseConverter.Convert(task.Result, pageIndex);
            return values ?? new CollectionPage<Listing>(0);
        }
    }
}