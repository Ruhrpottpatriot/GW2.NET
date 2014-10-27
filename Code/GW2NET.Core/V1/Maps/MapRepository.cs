// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/maps.json interface.
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

    /// <summary>Represents a repository that retrieves data from the /v1/maps.json interface.</summary>
    public class MapRepository : IRepository<int, Map>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<MapCollectionDataContract, ICollection<Map>> converterForMapCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForMapCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForMapCollection">The converter for <see cref="ICollection{Map}"/>.</param>
        internal MapRepository(IServiceClient serviceClient, IConverter<MapCollectionDataContract, ICollection<Map>> converterForMapCollection)
        {
            this.serviceClient = serviceClient;
            this.converterForMapCollection = converterForMapCollection;
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

        /// <summary>Finds the <see cref="Map"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Map"/> with the specified identifier.</returns>
        public Map Find(int identifier)
        {
            var request = new MapRequest { MapId = identifier, Culture = this.Culture };
            var response = this.serviceClient.Send<MapCollectionDataContract>(request);
            if (response.Content == null || response.Content.Maps == null)
            {
                return null;
            }

            var map = this.converterForMapCollection.Convert(response.Content).SingleOrDefault();
            if (map != null)
            {
                map.Culture = request.Culture;
            }

            return map;
        }

        /// <summary>Finds every <see cref="Map"/>.</summary>
        /// <returns>A collection of every <see cref="Map"/>.</returns>
        public IDictionaryRange<int, Map> FindAll()
        {
            var request = new MapRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<MapCollectionDataContract>(request);
            if (response.Content == null || response.Content.Maps == null)
            {
                return null;
            }

            var values = this.converterForMapCollection.Convert(response.Content);
            var maps = new DictionaryRange<int, Map>(values.Count) { SubtotalCount = values.Count, TotalCount = values.Count };

            foreach (var map in values)
            {
                map.Culture = request.Culture;
                maps.Add(map.MapId, map);
            }

            return maps;
        }

        /// <summary>Finds every <see cref="Map"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Map"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<int, Map> FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Map"/>.</summary>
        /// <returns>A collection of every <see cref="Map"/>.</returns>
        public Task<IDictionaryRange<int, Map>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <summary>Finds every <see cref="Map"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Map"/></returns>
        public Task<IDictionaryRange<int, Map>> FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new MapRequest { Culture = this.Culture };
            return this.serviceClient.SendAsync<MapCollectionDataContract>(request, cancellationToken).ContinueWith<IDictionaryRange<int, Map>>(task =>
            {
                var response = task.Result;
                if (response.Content == null || response.Content.Maps == null)
                {
                    return null;
                }

                var values = this.converterForMapCollection.Convert(response.Content);
                var maps = new DictionaryRange<int, Map>(values.Count) { SubtotalCount = values.Count, TotalCount = values.Count };

                foreach (var map in values)
                {
                    map.Culture = request.Culture;
                    maps.Add(map.MapId, map);
                }

                return maps;
            }, cancellationToken);
        }

        /// <summary>Finds every <see cref="Map"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Map"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Map>> FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Map"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Map"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<int, Map>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Map"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Map"/> with the specified identifier.</returns>
        public Task<Map> FindAsync(int identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="Map"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Map"/> with the specified identifier.</returns>
        public Task<Map> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            var request = new MapRequest { MapId = identifier, Culture = this.Culture };
            return this.serviceClient.SendAsync<MapCollectionDataContract>(request, cancellationToken).ContinueWith<Map>(task =>
            {
                var response = task.Result;
                if (response.Content == null || response.Content.Maps == null)
                {
                    return null;
                }

                var map = this.converterForMapCollection.Convert(response.Content).SingleOrDefault();
                if (map != null)
                {
                    map.Culture = request.Culture;
                }

                return map;
            }, cancellationToken);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Map> FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<Map> FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Map>> FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Map>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Map>> FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<Map>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForMapCollection != null);
        }
    }
}