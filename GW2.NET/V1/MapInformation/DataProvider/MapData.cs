// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Maps.Models;

namespace GW2DotNET.V1.Maps.DataProvider
{
    /// <summary>The map data.</summary>
    public class MapData
    {
        /// <summary>The api manager.</summary>
        private readonly Gw2ApiManager apiManager;

        /// <summary>The continents.</summary>
        private IEnumerable<Continent> continents;

        /// <summary>The maps.</summary>
        private List<Map> maps;

        /// <summary>The map floors.</summary>
        private List<MapFloor> mapFloors;

        /// <summary>Initializes a new instance of the <see cref="MapData"/> class.</summary>
        /// <param name="apiManager">The api manager.</param>
        public MapData(Gw2ApiManager apiManager)
        {
            this.apiManager = apiManager;
        }

        /// <summary>Gets the continents.</summary>
        public IEnumerable<Continent> Continents
        {
            get
            {
                return this.continents ?? (this.continents = this.GetContinents());
            }
        }

        /// <summary>Gets the maps.</summary>
        public IEnumerable<Map> Maps
        {
            get
            {
                return this.maps ?? (this.maps = this.GetMaps());
            }
        }

        /// <summary>Gets the map floors.</summary>
        public IEnumerable<MapFloor> MapFloors
        {
            get
            {
                return this.mapFloors ?? (this.mapFloors = GetMapFloors());
            }
        }


        /// <summary>The get continents.</summary>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        private IEnumerable<Continent> GetContinents()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.apiManager.Language)
            };

            return ApiCall.GetContent<Dictionary<string, Dictionary<int, Continent>>>(
                    "continents.json", args, ApiCall.Categories.World)
                       .Values.First()
                       .Select(con => con.Value.ResolveId(con.Key));
        }

        /// <summary>The get maps.</summary>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        private List<Map> GetMaps()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.apiManager.Language)
            };

            return ApiCall.GetContent<Dictionary<string, Dictionary<int, Map>>>(
                "maps.json", args, ApiCall.Categories.World)
                .Values.First().Select(map => map.Value.ResolveId(map.Key).ResolveContinent(
                    this.apiManager.Continents.Single(cont => cont.Id == map.Value.ContinentId)))
                    .ToList();
        }

        /// <summary>The get map floors.</summary>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        private List<MapFloor> GetMapFloors(int continentId, int floor)
        {
            var mapFloorList = new List<MapFloor>();

            var args = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("continent_id", continentId), 
                    new KeyValuePair<string, object>("floor", floor),
                    new KeyValuePair<string, object>("lang", this.apiManager.Language)
                };

            var floorToReturn = ApiCall.GetContent<MapFloor>("map_floor.json", args, ApiCall.Categories.World);

            mapFloorList.Add(floorToReturn);

            return mapFloorList;
        }
    }
}
