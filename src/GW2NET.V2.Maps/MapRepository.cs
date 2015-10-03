// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Maps
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
    using GW2NET.Maps;
    using GW2NET.V2.Maps.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/items interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// </remarks>
    public sealed class MapRepository : IMapRepository
    {
        private readonly IConverter<IResponse<ICollection<MapDTO>>, IDictionaryRange<int, Map>> bulkResponseConverter;

        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        private readonly IConverter<IResponse<ICollection<MapDTO>>, ICollectionPage<Map>> pageResponseConverter;

        private readonly IConverter<IResponse<MapDTO>, Map> responseConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="bulkResponseConverter"/> or <paramref name="responseConverter"/> is a null reference.</exception>
        public MapRepository(
            IServiceClient serviceClient,
            IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter,
            IConverter<IResponse<MapDTO>, Map> responseConverter,
            IConverter<IResponse<ICollection<MapDTO>>, IDictionaryRange<int, Map>> bulkResponseConverter,
            IConverter<IResponse<ICollection<MapDTO>>, ICollectionPage<Map>> pageResponseConverter)
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
            var request = new MapDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersResponseConverter.Convert(response, null) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IMapRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new MapDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Map IRepository<int, Map>.Find(int identifier)
        {
            var request = new MapDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<MapDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Map> IRepository<int, Map>.FindAll()
        {
            var request = new MapBulkRequest
            {
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<MapDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Map> IRepository<int, Map>.FindAll(ICollection<int> identifiers)
        {
            var request = new MapBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<MapDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync()
        {
            return ((IMapRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new MapBulkRequest
            {
                Culture = ((IMapRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<MapDTO>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Map>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IMapRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new MapBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((IMapRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<MapDTO>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, Map>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<Map> IRepository<int, Map>.FindAsync(int identifier)
        {
            return ((IMapRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Map> IRepository<int, Map>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new MapDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((IMapRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<MapDTO>(request, cancellationToken);
            return responseTask.ContinueWith<Map>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Map> IPaginator<Map>.FindPage(int pageIndex)
        {
            var request = new MapPageRequest
            {
                Page = pageIndex,
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<MapDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Map>(0);
        }

        /// <inheritdoc />
        ICollectionPage<Map> IPaginator<Map>.FindPage(int pageIndex, int pageSize)
        {
            var request = new MapPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<MapDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Map>(0);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex)
        {
            return ((IMapRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new MapPageRequest
            {
                Page = pageIndex,
                Culture = ((IMapRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<MapDTO>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IMapRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new MapPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((IMapRepository)this).Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<MapDTO>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, Map> ConvertAsyncResponse(Task<IResponse<ICollection<MapDTO>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.bulkResponseConverter.Convert(task.Result, null);
            return values ?? new DictionaryRange<int, Map>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Map> ConvertAsyncResponse(Task<IResponse<ICollection<MapDTO>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.pageResponseConverter.Convert(task.Result, pageIndex);
            return values ?? new CollectionPage<Map>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var ids = this.identifiersResponseConverter.Convert(task.Result, null);
            return ids ?? new List<int>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Map ConvertAsyncResponse(Task<IResponse<MapDTO>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.responseConverter.Convert(task.Result, null);
        }
    }
}