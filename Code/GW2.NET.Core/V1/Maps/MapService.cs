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
    using GW2DotNET.Entities.Maps;
    using GW2DotNET.V1.Maps.Json;

    /// <summary>Provides the default implementation of the maps service.</summary>
    public class MapService : IMapService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapService(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            Contract.EndContractBlock();

            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IDictionary<int, Continent> GetContinents()
        {
            var request = new ContinentDetailsRequest();
            var response = this.serviceClient.Send<ContinentCollectionContract>(request);
            if (response.Content == null || response.Content.Continents == null)
            {
                return new Dictionary<int, Continent>(0);
            }

            return ConvertContinentCollectionContract(response.Content);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync()
        {
            return this.GetContinentsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentDetailsRequest();
            return this.serviceClient.SendAsync<ContinentCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Continents == null)
                        {
                            return new Dictionary<int, Continent>(0);
                        }

                        return ConvertContinentCollectionContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map)
        {
            var culture = new CultureInfo("en");
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

            var request = new MapDetailsRequest { MapId = map, Culture = language };
            var response = this.serviceClient.Send<MapCollectionContract>(request);
            if (response.Content == null || response.Content.Maps == null)
            {
                return null;
            }

            var value = ConvertMapCollectionContract(response.Content).Values.SingleOrDefault();
            if (value != null)
            {
                value.Locale = response.Culture ?? language;
            }

            return value;
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map)
        {
            var culture = new CultureInfo("en");
            return this.GetMapAsync(map, culture, CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
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

            var request = new MapDetailsRequest { MapId = map, Culture = language };
            return this.serviceClient.SendAsync<MapCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Maps == null)
                        {
                            return null;
                        }

                        var value = ConvertMapCollectionContract(response.Content).Values.SingleOrDefault();
                        if (value != null)
                        {
                            value.Locale = response.Culture ?? language;
                        }

                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continent, int floor)
        {
            var culture = new CultureInfo("en");
            return this.GetMapFloor(continent, floor, culture);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continent, int floor, CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapFloorRequest { ContinentId = continent, Floor = floor, Culture = language };
            var response = this.serviceClient.Send<FloorContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertFloorContract(response.Content);
            value.ContinentId = continent;
            value.FloorId = floor;
            value.Locale = response.Culture ?? language;
            return value;
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor)
        {
            var culture = new CultureInfo("en");
            return this.GetMapFloorAsync(continent, floor, culture, CancellationToken.None);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetMapFloorAsync(continent, floor, culture, cancellationToken);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language)
        {
            return this.GetMapFloorAsync(continent, floor, language, CancellationToken.None);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapFloorRequest { ContinentId = continent, Floor = floor, Culture = language };
            return this.serviceClient.SendAsync<FloorContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        var value = ConvertFloorContract(response.Content);
                        value.ContinentId = continent;
                        value.FloorId = floor;
                        value.Locale = response.Culture ?? language;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames()
        {
            var culture = new CultureInfo("en");
            return this.GetMapNames(culture);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapNameRequest { Culture = language };
            var response = this.serviceClient.Send<ICollection<MapNameContract>>(request);
            if (response.Content == null)
            {
                return new Dictionary<int, Map>(0);
            }

            var values = ConvertMapNameContractCollection(response.Content);
            var locale = response.Culture ?? language;
            foreach (var value in values.Values)
            {
                value.Locale = locale;
            }

            return values;
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync()
        {
            var culture = new CultureInfo("en");
            return this.GetMapNamesAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetMapNamesAsync(culture, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language)
        {
            return this.GetMapNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapNameRequest { Culture = language };
            return this.serviceClient.SendAsync<ICollection<MapNameContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response == null)
                        {
                            return new Dictionary<int, Map>(0);
                        }

                        var values = ConvertMapNameContractCollection(response.Content);
                        var locale = response.Culture ?? language;
                        foreach (var value in values.Values)
                        {
                            value.Locale = locale;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMaps()
        {
            var culture = new CultureInfo("en");
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

            var request = new MapDetailsRequest { Culture = language };
            var response = this.serviceClient.Send<MapCollectionContract>(request);
            if (response.Content == null || response.Content.Maps == null)
            {
                return new Dictionary<int, Map>(0);
            }

            var values = ConvertMapCollectionContract(response.Content);
            var locale = response.Culture ?? language;
            foreach (var value in values.Values)
            {
                value.Locale = locale;
            }

            return values;
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync()
        {
            var culture = new CultureInfo("en");
            return this.GetMapsAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
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

            var request = new MapDetailsRequest { Culture = language };
            return this.serviceClient.SendAsync<MapCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Maps == null)
                        {
                            return new Dictionary<int, Map>(0);
                        }

                        var values = ConvertMapCollectionContract(response.Content);
                        var locale = response.Culture ?? language;
                        foreach (var value in values.Values)
                        {
                            value.Locale = locale;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Continent> ConvertContinentCollectionContract(ContinentCollectionContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Continents != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Continent>>() != null);
            var values = new Dictionary<int, Continent>(content.Continents.Count);
            foreach (var value in content.Continents.Select(ConvertContinentContract).Where(value => value != null))
            {
                Contract.Assume(value != null);
                values.Add(value.ContinentId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Continent ConvertContinentContract(KeyValuePair<string, ContinentContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Requires(content.Value.ContinentDimensions != null);
            Contract.Requires(content.Value.ContinentDimensions.Length == 2);
            return new Continent
                       {
                           ContinentId = int.Parse(content.Key), 
                           Name = content.Value.Name, 
                           ContinentDimensions = MapSize2DContract(content.Value.ContinentDimensions), 
                           MinimumZoom = content.Value.MinimumZoom, 
                           MaximumZoom = content.Value.MaximumZoom, 
                           FloorIds = content.Value.Floors
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Floor ConvertFloorContract(FloorContract content)
        {
            Contract.Requires(content != null);

            // Create a new floor object
            var value = new Floor();

            // Set the texture dimensions
            if (content.TextureDimensions != null && content.TextureDimensions.Length == 2)
            {
                value.TextureDimensions = MapSize2DContract(content.TextureDimensions);
            }

            // Set the clamped view dimensions
            if (content.ClampedView != null && content.ClampedView.Length == 2 && content.ClampedView[0] != null && content.ClampedView[0].Length == 2
                && content.ClampedView[1] != null && content.ClampedView[1].Length == 2)
            {
                value.ClampedView = ConvertRectangleContract(content.ClampedView);
            }

            // Set the regions
            if (content.Regions != null)
            {
                value.Regions = ConvertRegionContractCollection(content.Regions);
            }

            // Return the floor object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Map> ConvertMapCollectionContract(MapCollectionContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Maps != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Map>>() != null);
            var values = new Dictionary<int, Map>(content.Maps.Count);
            foreach (var value in content.Maps.Select(ConvertMapContract))
            {
                Contract.Assume(value != null);
                values.Add(value.MapId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Map ConvertMapContract(KeyValuePair<string, MapContract> content)
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
                value.MapRectangle = ConvertRectangleContract(content.Value.MapRectangle);
            }

            // Set the dimensions of the continent
            if (content.Value.ContinentRectangle != null && content.Value.ContinentRectangle.Length == 2 && content.Value.ContinentRectangle[0] != null
                && content.Value.ContinentRectangle[0].Length == 2 && content.Value.ContinentRectangle[1] != null
                && content.Value.ContinentRectangle[1].Length == 2)
            {
                value.ContinentRectangle = ConvertRectangleContract(content.Value.ContinentRectangle);
            }

            // Return the map object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Map ConvertMapNameContract(MapNameContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Map>() != null);

            // Create a new map object
            var value = new Map();

            // Set the map identifier
            if (content.Id != null)
            {
                value.MapId = int.Parse(content.Id);
            }

            // Set the name of the map
            if (content.Name != null)
            {
                value.MapName = content.Name;
            }

            // Return the map object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Map> ConvertMapNameContractCollection(ICollection<MapNameContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Map>>() != null);
            var values = new Dictionary<int, Map>(content.Count);
            foreach (var value in content.Select(ConvertMapNameContract))
            {
                Contract.Assume(value != null);
                values.Add(value.MapId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static PointOfInterest ConvertPointOfInterestContract(PointOfInterestContract content)
        {
            Contract.Requires(content != null);
            var value = (PointOfInterest)Activator.CreateInstance(GetPointOfInterestType(content));
            value.PointOfInterestId = content.PointOfInterestId;
            value.Name = content.Name;
            value.Floor = content.Floor;
            if (content.Coordinates != null && content.Coordinates.Length == 2)
            {
                value.Coordinates = MapPoint2DContract(content.Coordinates);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<PointOfInterest> ConvertPointOfInterestContractCollection(ICollection<PointOfInterestContract> content)
        {
            Contract.Requires(content != null);
            var values = new List<PointOfInterest>(content.Count);
            values.AddRange(content.Select(ConvertPointOfInterestContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Rectangle ConvertRectangleContract(double[][] content)
        {
            Contract.Requires(content != null && content.Length == 2);
            Contract.Requires(content[0] != null && content[0].Length == 2);
            Contract.Requires(content[1] != null && content[1].Length == 2);
            var nw = MapPoint2DContract(content[0]);
            var se = MapPoint2DContract(content[1]);
            return new Rectangle(nw, se);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Region ConvertRegionContract(KeyValuePair<string, RegionContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Ensures(Contract.Result<Region>() != null);

            // Create a new region object
            var value = new Region();

            // Set the region identifier
            value.RegionId = int.Parse(content.Key);

            // Set the name of the region
            if (content.Value.Name != null)
            {
                value.Name = content.Value.Name;
            }

            // Set the position of the region label
            if (content.Value.LabelCoordinates != null && content.Value.LabelCoordinates.Length == 2)
            {
                value.LabelCoordinates = MapPoint2DContract(content.Value.LabelCoordinates);
            }

            // Set the maps
            if (content.Value.Maps != null)
            {
                value.Maps = ConvertSubregionContractCollection(content.Value.Maps);
            }

            // Return the region object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Region> ConvertRegionContractCollection(IDictionary<string, RegionContract> content)
        {
            Contract.Requires(content != null);
            var values = new Dictionary<int, Region>(content.Count);
            foreach (var value in content.Select(ConvertRegionContract))
            {
                Contract.Assume(value != null);
                values.Add(value.RegionId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static RenownTask ConvertRenownTaskContract(RenownTaskContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Coordinates != null);
            Contract.Requires(content.Coordinates.Length == 2);
            return new RenownTask
                       {
                           TaskId = content.TaskId, 
                           Objective = content.Objective, 
                           Level = content.Level, 
                           Coordinates = MapPoint2DContract(content.Coordinates)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<RenownTask> ConvertRenownTaskContractCollection(ICollection<RenownTaskContract> content)
        {
            Contract.Requires(content != null);
            var values = new List<RenownTask>(content.Count);
            values.AddRange(content.Select(ConvertRenownTaskContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Sector ConvertSectorContract(SectorContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Coordinates != null);
            Contract.Requires(content.Coordinates.Length == 2);
            return new Sector { SectorId = content.SectorId, Name = content.Name, Level = content.Level, Coordinates = MapPoint2DContract(content.Coordinates) };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<Sector> ConvertSectorContractCollection(ICollection<SectorContract> content)
        {
            Contract.Requires(content != null);
            var values = new List<Sector>(content.Count);
            values.AddRange(content.Select(ConvertSectorContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static SkillChallenge ConvertSkillChallengeContract(SkillChallengeContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Coordinates != null);
            Contract.Requires(content.Coordinates.Length == 2);
            return new SkillChallenge { Coordinates = MapPoint2DContract(content.Coordinates) };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<SkillChallenge> ConvertSkillChallengeContractCollection(ICollection<SkillChallengeContract> content)
        {
            Contract.Requires(content != null);
            var values = new List<SkillChallenge>(content.Count);
            values.AddRange(content.Select(ConvertSkillChallengeContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Subregion ConvertSubregionContract(KeyValuePair<string, SubregionContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Ensures(Contract.Result<Subregion>() != null);

            // Create a new map object
            var value = new Subregion();

            // Set the map identifier
            value.MapId = int.Parse(content.Key);

            // Set the name of the map
            if (content.Value.Name != null)
            {
                value.Name = content.Value.Name;
            }

            // Set the minimum level
            value.MinimumLevel = content.Value.MinimumLevel;

            // Set the maximum level
            value.MaximumLevel = content.Value.MaximumLevel;

            // Set the default floor
            value.DefaultFloor = content.Value.DefaultFloor;

            // Set the map dimensions
            if (content.Value.MapRectangle != null && content.Value.MapRectangle.Length == 2 && content.Value.MapRectangle[0] != null
                && content.Value.MapRectangle[0].Length == 2 && content.Value.MapRectangle[1] != null && content.Value.MapRectangle[1].Length == 2)
            {
                value.MapRectangle = ConvertRectangleContract(content.Value.MapRectangle);
            }

            // Set the continent dimensions
            if (content.Value.ContinentRectangle != null && content.Value.ContinentRectangle.Length == 2 && content.Value.ContinentRectangle[0] != null
                && content.Value.ContinentRectangle[0].Length == 2 && content.Value.ContinentRectangle[1] != null
                && content.Value.ContinentRectangle[1].Length == 2)
            {
                value.ContinentRectangle = ConvertRectangleContract(content.Value.ContinentRectangle);
            }

            // Set the points of interest
            if (content.Value.PointsOfInterest != null)
            {
                value.PointsOfInterest = ConvertPointOfInterestContractCollection(content.Value.PointsOfInterest);
            }

            // Set the renown tasks
            if (content.Value.Tasks != null)
            {
                value.Tasks = ConvertRenownTaskContractCollection(content.Value.Tasks);
            }

            // Set the skill challenges
            if (content.Value.SkillChallenges != null)
            {
                value.SkillChallenges = ConvertSkillChallengeContractCollection(content.Value.SkillChallenges);
            }

            // Set the sectors
            if (content.Value.Sectors != null)
            {
                value.Sectors = ConvertSectorContractCollection(content.Value.Sectors);
            }

            // Return the map object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Subregion> ConvertSubregionContractCollection(IDictionary<string, SubregionContract> content)
        {
            Contract.Requires(content != null);
            var values = new Dictionary<int, Subregion>(content.Count);
            foreach (var value in content.Select(ConvertSubregionContract))
            {
                Contract.Assume(value != null);
                values.Add(value.MapId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetPointOfInterestType(PointOfInterestContract content)
        {
            Contract.Requires(content != null);
            switch (content.Type)
            {
                case "unlock":
                    return typeof(Dungeon);
                case "landmark":
                    return typeof(Landmark);
                case "vista":
                    return typeof(Vista);
                case "waypoint":
                    return typeof(Waypoint);
                default:
                    return typeof(UnknownPointOfInterest);
            }
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Point2D MapPoint2DContract(double[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 2);
            return new Point2D(content[0], content[1]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Size2D MapSize2DContract(double[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 2);
            return new Size2D(content[0], content[1]);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}