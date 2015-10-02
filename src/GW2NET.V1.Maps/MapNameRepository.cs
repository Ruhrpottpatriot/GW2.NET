// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNameRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/map_names.json interface.
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
    using GW2NET.V1.Maps.Converters;
    using GW2NET.V1.Maps.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/map_names.json interface.</summary>
    public class MapNameRepository : IMapNameRepository
    {
        private readonly IConverter<MapNameDTO, MapName> mapNameConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapNameRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="mapNameConverter">The converter for <see cref="MapName"/>.</param>
        public MapNameRepository(IServiceClient serviceClient, IConverter<MapNameDTO, MapName> mapNameConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (mapNameConverter == null)
            {
                throw new ArgumentNullException("mapNameConverter");
            }

            this.serviceClient = serviceClient;
            this.mapNameConverter = mapNameConverter;
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
        MapName IRepository<int, MapName>.Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, MapName> IRepository<int, MapName>.FindAll()
        {
            IMapNameRepository self = this;
            var request = new MapNameRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<MapNameDTO>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, MapName>(0);
            }

            var values = response.Content.Select(value => this.mapNameConverter.Convert(value, null)).ToList();
            var mapNames = new DictionaryRange<int, MapName>(values.Count)
            {
                SubtotalCount = values.Count,
                TotalCount = values.Count
            };

            foreach (var mapName in values)
            {
                mapName.Culture = request.Culture;
                mapNames.Add(mapName.MapId, mapName);
            }

            return mapNames;
        }

        /// <inheritdoc />
        IDictionaryRange<int, MapName> IRepository<int, MapName>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, MapName>> IRepository<int, MapName>.FindAllAsync()
        {
            IMapNameRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, MapName>> IRepository<int, MapName>.FindAllAsync(CancellationToken cancellationToken)
        {
            IMapNameRepository self = this;
            var request = new MapNameRequest
            {
                Culture = self.Culture
            };
            return this.serviceClient.SendAsync<ICollection<MapNameDTO>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, MapName>>(
                task =>
                {
                    var response = task.Result;
                    if (response.Content == null)
                    {
                        return new DictionaryRange<int, MapName>(0);
                    }

                    var values = response.Content.Select(value => this.mapNameConverter.Convert(value, null)).ToList();
                    var mapNames = new DictionaryRange<int, MapName>(values.Count)
                    {
                        SubtotalCount = values.Count,
                        TotalCount = values.Count
                    };

                    foreach (var mapName in values)
                    {
                        mapName.Culture = request.Culture;
                        mapNames.Add(mapName.MapId, mapName);
                    }

                    return mapNames;
                },
            cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, MapName>> IRepository<int, MapName>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, MapName>> IRepository<int, MapName>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<MapName> IRepository<int, MapName>.FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<MapName> IRepository<int, MapName>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<MapName> IPaginator<MapName>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<MapName> IPaginator<MapName>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<MapName>> IPaginator<MapName>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<MapName>> IPaginator<MapName>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<MapName>> IPaginator<MapName>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<MapName>> IPaginator<MapName>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}