// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its details, including details about floor and translation data on how to translate between
//   world coordinates and map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.MapsInformation.Details
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Converters;
    using GW2DotNET.V1.Core.MapsInformation.Common;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a map and its details, including details about floor and translation data on how to translate between
    ///     world coordinates and map coordinates.
    /// </summary>
    public class Map : JsonObject
    {
        /// <summary>
        ///     Gets or sets the ID of the continent this map belongs to.
        /// </summary>
        [JsonProperty("continent_id", Order = 8)]
        public int ContinentId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the continent this map belongs to.
        /// </summary>
        [JsonProperty("continent_name", Order = 9)]
        public string ContinentName { get; set; }

        /// <summary>
        ///     Gets or sets the dimensions of the map within the continent coordinate system.
        /// </summary>
        [JsonProperty("continent_rect", Order = 11)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle ContinentRectangle { get; set; }

        /// <summary>
        ///     Gets or sets the default floor of this map.
        /// </summary>
        [JsonProperty("default_floor", Order = 4)]
        public int DefaultFloor { get; set; }

        /// <summary>
        ///     Gets or sets a list of available floors for this map.
        /// </summary>
        [JsonProperty("floors", Order = 5)]
        public FloorCollection Floors { get; set; }

        /// <summary>
        ///     Gets or sets the map's ID.
        /// </summary>
        [JsonProperty("map_id", Order = 0)]
        public int MapId { get; set; }

        /// <summary>
        ///     Gets or sets the map name.
        /// </summary>
        [JsonProperty("map_name", Order = 1)]
        public string MapName { get; set; }

        /// <summary>
        ///     Gets or sets the dimensions of the map.
        /// </summary>
        [JsonProperty("map_rect", Order = 10)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle MapRectangle { get; set; }

        /// <summary>
        ///     Gets or sets the maximum level of this map.
        /// </summary>
        [JsonProperty("max_level", Order = 3)]
        public int MaximumLevel { get; set; }

        /// <summary>
        ///     Gets or sets the minimum level of this map.
        /// </summary>
        [JsonProperty("min_level", Order = 2)]
        public int MinimumLevel { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the region this map belongs to.
        /// </summary>
        [JsonProperty("region_id", Order = 6)]
        public int RegionId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the region this map belongs to.
        /// </summary>
        [JsonProperty("region_name", Order = 7)]
        public string RegionName { get; set; }
    }
}