// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the maps service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Maps.Contracts;

    /// <summary>Provides the default implementation of the maps service.</summary>
    public class MapService : IMapService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly MapSerializerSettings Settings = new MapSerializerSettings();

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int mapId)
        {
            return this.GetMap(mapId, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int mapId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapRequest { MapId = mapId, Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<MapCollectionResult>(Settings));

            // Apply patches
            foreach (var map in result.Maps)
            {
                // Patch missing map identifier
                map.Value.MapId = map.Key;

                // Patch missing language information
                map.Value.Language = language.TwoLetterISOLanguageName;

                // Patch missing continent identifiers
                foreach (var floor in map.Value.Floors)
                {
                    floor.ContinentId = map.Value.Continent.ContinentId;
                }
            }

            return result.Maps.Values.SingleOrDefault();
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId)
        {
            return this.GetMapAsync(mapId, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CancellationToken cancellationToken)
        {
            return this.GetMapAsync(mapId, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            return this.GetMapAsync(mapId, language, CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapRequest { MapId = mapId, Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<MapCollectionResult>(Settings), cancellationToken);
            var t2 = t1.ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Apply patches
                        foreach (var map in result.Maps)
                        {
                            // Patch missing map identifiers
                            map.Value.MapId = map.Key;

                            // Patch missing language information
                            map.Value.Language = language.TwoLetterISOLanguageName;

                            // Patch missing continent identifiers
                            foreach (var floor in map.Value.Floors)
                            {
                                floor.ContinentId  = map.Value.Continent.ContinentId;
                            }
                        }

                        return result.Maps.Values.SingleOrDefault();
                    }, 
                cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps()
        {
            return this.GetMaps(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapRequest { Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<MapCollectionResult>(Settings));

            // Apply patches
            foreach (var map in result.Maps)
            {
                // Patch missing map identifiers
                map.Value.MapId = map.Key;

                // Patch missing language information
                map.Value.Language = language.TwoLetterISOLanguageName;

                // Patch missing continent identifiers
                foreach (var floor in map.Value.Floors)
                {
                    floor.ContinentId = map.Value.Continent.ContinentId;
                }
            }

            return result.Maps.Values;
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync()
        {
            return this.GetMapsAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CancellationToken cancellationToken)
        {
            return this.GetMapsAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CultureInfo language)
        {
            return this.GetMapsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapRequest { Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<MapCollectionResult>(Settings), cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Apply patches
                        foreach (var map in result.Maps)
                        {
                            // Patch missing map identifiers
                            map.Value.MapId = map.Key;

                            // Patch missing language information
                            map.Value.Language = language.TwoLetterISOLanguageName;

                            // Patch missing continent identifiers
                            foreach (var floor in map.Value.Floors)
                            {
                                floor.ContinentId = map.Value.Continent.ContinentId;
                            }
                        }

                        return result;
                    }, 
                cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Map>>(task => task.Result.Maps.Values, cancellationToken);

            return t2;
        }
    }
}