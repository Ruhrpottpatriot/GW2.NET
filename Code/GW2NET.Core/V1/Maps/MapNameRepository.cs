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
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;
    using GW2NET.V1.Maps.Json;
    using GW2NET.V1.Maps.Json.Converters;

    /// <summary>Represents a repository that retrieves data from the /v1/map_names.json interface.</summary>
    public class MapNameRepository : IRepository<int, MapName>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<MapNameDataContract, MapName> converterForMapName;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapNameRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapNameRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForMapName())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapNameRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForMapName">The converter for <see cref="MapName"/>.</param>
        internal MapNameRepository(IServiceClient serviceClient, IConverter<MapNameDataContract, MapName> converterForMapName)
        {
            this.serviceClient = serviceClient;
            this.converterForMapName = converterForMapName;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<int> Discover()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<int>> DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="MapName"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="MapName"/> with the specified identifier.</returns>
        public MapName Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="MapName"/>.</summary>
        /// <returns>A collection of every <see cref="MapName"/>.</returns>
        public IDictionaryRange<int, MapName> FindAll()
        {
            var request = new MapNameRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ICollection<MapNameDataContract>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, MapName>(0);
            }

            var mapNames = new DictionaryRange<int, MapName>(response.Content.Count);
            foreach (var mapName in response.Content.Select(this.converterForMapName.Convert))
            {
                mapName.Culture = request.Culture;
                mapNames.Add(mapName.MapId, mapName);
            }

            return mapNames;
        }

        /// <summary>Finds every <see cref="MapName"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="MapName"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, MapName> FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="MapName"/>.</summary>
        /// <returns>A collection of every <see cref="MapName"/>.</returns>
        public Task<IDictionaryRange<int, MapName>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="MapName"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="MapName"/></returns>
        public Task<IDictionaryRange<int, MapName>> FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new MapNameRequest { Culture = this.Culture };
            return this.serviceClient.SendAsync<ICollection<MapNameDataContract>>(request, cancellationToken).ContinueWith<IDictionaryRange<int, MapName>>(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return new DictionaryRange<int, MapName>(0);
                }

                var mapNames = new DictionaryRange<int, MapName>(response.Content.Count);
                foreach (var mapName in response.Content.Select(this.converterForMapName.Convert))
                {
                    mapName.Culture = request.Culture;
                    mapNames.Add(mapName.MapId, mapName);
                }

                return mapNames;
            }, cancellationToken);
        }

        /// <summary>Finds every <see cref="MapName"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="MapName"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, MapName>> FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="MapName"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="MapName"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, MapName>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="MapName"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="MapName"/> with the specified identifier.</returns>
        public Task<MapName> FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="MapName"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="MapName"/> with the specified identifier.</returns>
        public Task<MapName> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<MapName> FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<MapName> FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<MapName>> FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<MapName>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<MapName>> FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<MapName>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForMapName != null);
        }
    }
}