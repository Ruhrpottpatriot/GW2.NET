// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using RectangleConverter = GW2DotNET.V1.Core.Converters.RectangleConverter;

namespace GW2DotNET.V1.Core.MapsInformation.Details
{
    /// <summary>
    /// Represents a map and its details, including details about floor and translation data on how to translate between world coordinates and map coordinates.
    /// </summary>
    public class MapDetails : JsonObject
    {
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
        [JsonConverter(typeof(RectangleConverter))]
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
        [JsonConverter(typeof(RectangleConverter))]
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
    }
}