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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Maps;
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
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetMap(map, culture);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map, CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapRequest { MapId = map, Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<MapCollectionContract>());
            if (response.Content == null || response.Content.Maps == null)
            {
                return null;
            }

            return MapMapCollectionContract(response.Content, language).Values.SingleOrDefault();
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetMapAsync(map, culture, CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CancellationToken cancellationToken)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetMapAsync(map, culture, cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CultureInfo language)
        {
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
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

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
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetMaps(culture);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMaps(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<MapCollectionContract>());
            if (response.Content == null || response.Content.Maps == null)
            {
                return new Dictionary<int, Map>(0);
            }

            return MapMapCollectionContract(response.Content, language);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync()
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetMapsAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CancellationToken cancellationToken)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetMapsAsync(culture, cancellationToken);
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
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

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
            Contract.Requires(content != null);
            Contract.Requires(content.Maps != null);
            Contract.Requires(culture != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Map>>() != null);
            var values = new Dictionary<int, Map>(content.Maps.Count);
            foreach (var value in content.Maps.Select(MapMapContract))
            {
                Contract.Assume(value != null);
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
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Ensures(Contract.Result<Map>() != null);

            // Create a new map object
            var value = new Map();

            // Set the map identifier
            if (content.Key != null)
            {
                value.MapId = int.Parse(content.Key);
            }

            // Set the name of the map
            if (content.Value.MapName != null)
            {
                value.MapName = content.Value.MapName;
            }

            // Set the minimum level
            value.MinimumLevel = content.Value.MinimumLevel;

            // Set the maximum level
            value.MaximumLevel = content.Value.MaximumLevel;

            // Set the default floor
            value.DefaultFloor = content.Value.DefaultFloor;

            // Set the available floors
            if (content.Value.Floors != null)
            {
                value.Floors = content.Value.Floors;
            }

            // Set the region identifier
            value.RegionId = content.Value.RegionId;

            // Set the name of the region
            if (content.Value.RegionName != null)
            {
                value.RegionName = content.Value.RegionName;
            }

            // Set the continent identifier
            value.ContinentId = content.Value.ContinentId;

            // Set the name of the continent
            if (content.Value.ContinentName != null)
            {
                value.ContinentName = content.Value.ContinentName;
            }

            // Set the dimensions of the map
            if (content.Value.MapRectangle != null && content.Value.MapRectangle.Length == 2 && content.Value.MapRectangle[0] != null
                && content.Value.MapRectangle[0].Length == 2 && content.Value.MapRectangle[1] != null && content.Value.MapRectangle[1].Length == 2)
            {
                value.MapRectangle = MapRectangleContract(content.Value.MapRectangle);
            }

            // Set the dimensions of the continent
            if (content.Value.ContinentRectangle != null && content.Value.ContinentRectangle.Length == 2 && content.Value.ContinentRectangle[0] != null
                && content.Value.ContinentRectangle[0].Length == 2 && content.Value.ContinentRectangle[1] != null
                && content.Value.ContinentRectangle[1].Length == 2)
            {
                value.ContinentRectangle = MapRectangleContract(content.Value.ContinentRectangle);
            }

            // Return the map object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Rectangle MapRectangleContract(double[][] content)
        {
            Contract.Requires(content != null && content.Length == 2);
            Contract.Requires(content[0] != null && content[0].Length == 2);
            Contract.Requires(content[1] != null && content[1].Length == 2);
            var nw = new Point2D(content[0][0], content[0][1]);
            var se = new Point2D(content[1][0], content[1][1]);
            return new Rectangle(nw, se);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}