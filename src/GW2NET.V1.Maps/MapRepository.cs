// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/maps.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Common;
    using GW2NET.Maps;
    using GW2NET.V1.Maps.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/maps.json interface.</summary>
    public class MapRepository : IMapRepository
    {
        private readonly IConverter<MapCollectionDTO, ICollection<Map>> mapCollectionConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="mapCollectionConverter">The converter for <see cref="ICollection{Map}"/>.</param>
        public MapRepository(IServiceClient serviceClient, IConverter<MapCollectionDTO, ICollection<Map>> mapCollectionConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (mapCollectionConverter == null)
            {
                throw new ArgumentNullException("mapCollectionConverter");
            }

            this.serviceClient = serviceClient;
            this.mapCollectionConverter = mapCollectionConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Map IRepository<int, Map>.Find(int identifier)
        {
            IMapRepository self = this;
            var request = new MapRequest
            {
                MapId = identifier,
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<MapCollectionDTO>(request);
            if (response.Content == null || response.Content.Maps == null)
            {
                return null;
            }

            var values = this.mapCollectionConverter.Convert(response.Content, null);
            if (values == null)
            {
                return null;
            }

            var map = values.SingleOrDefault();
            if (map != null)
            {
                map.Culture = request.Culture;
            }

            return map;
        }

        /// <inheritdoc />
        IDictionaryRange<int, Map> IRepository<int, Map>.FindAll()
        {
            IMapRepository self = this;
            var request = new MapRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<MapCollectionDTO>(request);
            if (response.Content == null || response.Content.Maps == null)
            {
                return new DictionaryRange<int, Map>(0);
            }

            var values = this.mapCollectionConverter.Convert(response.Content, null);
            var maps = new DictionaryRange<int, Map>(values.Count)
            {
                SubtotalCount = values.Count,
                TotalCount = values.Count
            };

            foreach (var map in values)
            {
                map.Culture = request.Culture;
                maps.Add(map.MapId, map);
            }

            return maps;
        }

        /// <inheritdoc />
        IDictionaryRange<int, Map> IRepository<int, Map>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync()
        {
            IMapRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(CancellationToken cancellationToken)
        {
            IMapRepository self = this;
            var request = new MapRequest
            {
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<MapCollectionDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null || response.Content.Maps == null)
            {
                return null;
            }

            var values = this.mapCollectionConverter.Convert(response.Content, null);
            var maps = new DictionaryRange<int, Map>(values.Count)
            {
                SubtotalCount = values.Count,
                TotalCount = values.Count
            };

            foreach (var map in values)
            {
                map.Culture = request.Culture;
                maps.Add(map.MapId, map);
            }

            return maps;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, Map>> IRepository<int, Map>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Map> IRepository<int, Map>.FindAsync(int identifier)
        {
            IMapRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Map> IRepository<int, Map>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IMapRepository self = this;
            var request = new MapRequest
            {
                MapId = identifier,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<MapCollectionDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null || response.Content.Maps == null)
            {
                return null;
            }

            var map = this.mapCollectionConverter.Convert(response.Content, null).SingleOrDefault();
            if (map != null)
            {
                map.Culture = request.Culture;
            }

            return map;
        }

        /// <inheritdoc />
        ICollectionPage<Map> IPaginator<Map>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Map> IPaginator<Map>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Map>> IPaginator<Map>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}