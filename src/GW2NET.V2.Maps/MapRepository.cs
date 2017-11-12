// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
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
    using GW2NET.Common.Converters;
    using GW2NET.Maps;

    /// <summary>Represents a repository that retrieves data from the /v2/items interface. See the remarks section for important limitations regarding this implementation.</summary>
    /// <remarks>
    /// This implementation does not retrieve associated entities.
    /// </remarks>
    public sealed class MapRepository : IMapRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<MapDataContract>>, IDictionaryRange<int, Map>> bulkResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<MapDataContract>>, ICollectionPage<Map>> pageResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<MapDataContract>, Map> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public MapRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<int>>(), new MapConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="collectionConverter">The converter for <see cref="T:ICollection{int}"/>.</param>
        /// <param name="mapConverter">The converter for <see cref="Map"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="collectionConverter"/> or <paramref name="mapConverter"/> is a null reference.</exception>
        internal MapRepository(IServiceClient serviceClient, IConverter<ICollection<int>
            , ICollection<int>> collectionConverter
            , IConverter<MapDataContract, Map> mapConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (collectionConverter == null)
            {
                throw new ArgumentNullException("collectionConverter", "Precondition: collectionConverter != null");
            }

            if (mapConverter == null)
            {
                throw new ArgumentNullException("mapConverter", "Precondition: mapConverter != null");
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = new ConverterForResponse<ICollection<int>, ICollection<int>>(collectionConverter);
            this.responseConverter = new ConverterForResponse<MapDataContract, Map>(mapConverter);
            this.bulkResponseConverter = new ConverterForDictionaryRangeResponse<MapDataContract, int, Map>(mapConverter, map => map.MapId);
            this.pageResponseConverter = new ConverterForCollectionPageResponse<MapDataContract, Map>(mapConverter);
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new MapDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            return this.identifiersResponseConverter.Convert(response) ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            return ((IMapRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new MapDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            var ids = this.identifiersResponseConverter.Convert(response);
            return ids ?? new List<int>(0);
        }

        /// <inheritdoc />
        Map IRepository<int, Map>.Find(int identifier)
        {
            var request = new MapDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<MapDataContract>(request);
            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Map> IRepository<int, Map>.FindAll()
        {
            var request = new MapBulkRequest
            {
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<MapDataContract>>(request);
            return this.bulkResponseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, Map> IRepository<int, Map>.FindAll(ICollection<int> identifiers)
        {
            var request = new MapBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<MapDataContract>>(request);
            return this.bulkResponseConverter.Convert(response);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync()
        {
            return ((IMapRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new MapBulkRequest
            {
                Culture = ((IMapRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<MapDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.bulkResponseConverter.Convert(response);
            return values ?? new DictionaryRange<int, Map>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(ICollection<int> identifiers)
        {
            return ((IMapRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            var request = new MapBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = ((IMapRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<MapDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.bulkResponseConverter.Convert(response);
            return values ?? new DictionaryRange<int, Map>(0);
        }

        /// <inheritdoc />
        Task<Map> IRepository<int, Map>.FindAsync(int identifier)
        {
            return ((IMapRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Map> IRepository<int, Map>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new MapDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = ((IMapRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<MapDataContract>(request, cancellationToken).ConfigureAwait(false);
            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        ICollectionPage<Map> IPaginator<Map>.FindPage(int pageIndex)
        {
            var request = new MapPageRequest
            {
                Page = pageIndex,
                Culture = ((IMapRepository)this).Culture
            };
            var response = this.serviceClient.Send<ICollection<MapDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
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
            var response = this.serviceClient.Send<ICollection<MapDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response);
            PageContextPatchUtility.Patch(values, pageIndex);
            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex)
        {
            return ((IMapRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new MapPageRequest
            {
                Page = pageIndex,
                Culture = ((IMapRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<MapDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.pageResponseConverter.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Map>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IMapRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new MapPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = ((IMapRepository)this).Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<MapDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.pageResponseConverter.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Map>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }
    }
}
