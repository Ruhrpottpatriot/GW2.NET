// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using JsonRectangleConverter = GW2DotNET.V1.Core.Converters.RectangleConverter;

namespace GW2DotNET.V1.Core.Maps
{
    /// <summary>
    /// Represents detailed information about a map.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        public Map()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class using the specified values.
        /// </summary>
        /// <param name="mapName">The map name.</param>
        /// <param name="minimumLevel">The minimum level of this map.</param>
        /// <param name="maximumLevel">The maximum level of this map.</param>
        /// <param name="defaultFloor">The default floor of this map.</param>
        /// <param name="floors">The list of available floors for this map.</param>
        /// <param name="regionId">The ID of the region this map belongs to.</param>
        /// <param name="regionName">The name of the region this map belongs to.</param>
        /// <param name="continentId">The ID of the continent this map belongs to.</param>
        /// <param name="continentName">The name of the continent this map belongs to.</param>
        /// <param name="mapRectangle">The dimensions of the map.</param>
        /// <param name="continentRectangle">The dimensions of the map within the continent coordinate system.</param>
        public Map(string mapName, int minimumLevel, int maximumLevel, int defaultFloor, IEnumerable<int> floors, int regionId, string regionName, int continentId, string continentName, Rectangle mapRectangle, Rectangle continentRectangle)
        {
            this.MapName = mapName;
            this.MinimumLevel = minimumLevel;
            this.MaximumLevel = maximumLevel;
            this.DefaultFloor = defaultFloor;
            this.Floors = floors;
            this.RegionId = regionId;
            this.RegionName = regionName;
            this.ContinentId = continentId;
            this.ContinentName = continentName;
            this.MapRectangle = mapRectangle;
            this.ContinentRectangle = continentRectangle;
        }

        /// <summary>
        /// Gets or sets the ID of the continent this map belongs to.
        /// </summary>
        [JsonProperty("continent_id", Order = 7)]
        public int ContinentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the continent this map belongs to.
        /// </summary>
        [JsonProperty("continent_name", Order = 8)]
        public string ContinentName { get; set; }

        /// <summary>
        /// Gets or sets the dimensions of the map within the continent coordinate system.
        /// </summary>
        [JsonProperty("continent_rect", Order = 10)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle ContinentRectangle { get; set; }

        /// <summary>
        /// Gets or sets the default floor of this map.
        /// </summary>
        [JsonProperty("default_floor", Order = 3)]
        public int DefaultFloor { get; set; }

        /// <summary>
        /// Gets or sets a list of available floors for this map.
        /// </summary>
        [JsonProperty("floors", Order = 4)]
        public IEnumerable<int> Floors { get; set; }

        /// <summary>
        /// Gets or sets the map name.
        /// </summary>
        [JsonProperty("map_name", Order = 0)]
        public string MapName { get; set; }

        /// <summary>
        /// Gets or sets the dimensions of the map.
        /// </summary>
        [JsonProperty("map_rect", Order = 9)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle MapRectangle { get; set; }

        /// <summary>
        /// Gets or sets the maximum level of this map.
        /// </summary>
        [JsonProperty("max_level", Order = 2)]
        public int MaximumLevel { get; set; }

        /// <summary>
        /// Gets or sets the minimum level of this map.
        /// </summary>
        [JsonProperty("min_level", Order = 1)]
        public int MinimumLevel { get; set; }

        /// <summary>
        /// Gets or sets the ID of the region this map belongs to.
        /// </summary>
        [JsonProperty("region_id", Order = 5)]
        public int RegionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the region this map belongs to.
        /// </summary>
        [JsonProperty("region_name", Order = 6)]
        public string RegionName { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}