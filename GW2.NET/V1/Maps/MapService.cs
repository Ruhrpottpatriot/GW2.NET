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
    using GW2DotNET.Maps;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Maps.Contracts;

    /// <summary>Provides the default implementation of the maps service.</summary>
    public class MapService : IMapService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map)
        {
            return this.GetMap(map, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapRequest { MapId = map, Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<MapCollectionContract>());
            return MapMapCollectionContract(response.Content, language).Values.SingleOrDefault();
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map)
        {
            return this.GetMapAsync(map, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CancellationToken cancellationToken)
        {
            return this.GetMapAsync(map, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            return this.GetMapAsync(map, language, CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapRequest { MapId = map, Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<MapCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapMapCollectionContract(response.Content, language).Values.SingleOrDefault();
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMaps()
        {
            return this.GetMaps(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMaps(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<MapCollectionContract>());
            return MapMapCollectionContract(response.Content, language);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync()
        {
            return this.GetMapsAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CancellationToken cancellationToken)
        {
            return this.GetMapsAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CultureInfo language)
        {
            return this.GetMapsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapRequest { Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<MapCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapMapCollectionContract(response.Content, language);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Map> MapMapCollectionContract(MapCollectionContract content, CultureInfo culture)
        {
            var values = new Dictionary<int, Map>(content.Maps.Count);
            foreach (var value in content.Maps.Select(MapMapContract))
            {
                value.Language = culture.TwoLetterISOLanguageName;
                values.Add(value.MapId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Map MapMapContract(KeyValuePair<string, MapContract> content)
        {
            return new Map
                       {
                           MapId = int.Parse(content.Key), 
                           MapName = content.Value.MapName, 
                           MinimumLevel = content.Value.MinimumLevel, 
                           MaximumLevel = content.Value.MaximumLevel, 
                           DefaultFloor = content.Value.DefaultFloor, 
                           Floors = content.Value.Floors, 
                           RegionId = content.Value.RegionId, 
                           RegionName = content.Value.RegionName, 
                           ContinentId = content.Value.ContinentId, 
                           ContinentName = content.Value.ContinentName, 
                           MapRectangle = MapRectangleContract(content.Value.MapRectangle), 
                           ContinentRectangle = MapRectangleContract(content.Value.ContinentRectangle)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Rectangle MapRectangleContract(int[][] content)
        {
            var nw = new Point2D(content[0][0], content[0][1]);
            var se = new Point2D(content[1][0], content[1][1]);
            return new Rectangle(nw, se);
        }
    }
}