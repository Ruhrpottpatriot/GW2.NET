// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using JsonRectangleConverter = GW2DotNET.V1.Core.Converters.RectangleConverter;

namespace GW2DotNET.V1.Core.MapFloor.Models
{
    /// <summary>
    /// Represents detailed information about a map.
    /// </summary>
    public class Map : JsonObject
    {
        /// <summary>
        /// Gets or sets the dimensions of the map within the continent coordinate system.
        /// </summary>
        [JsonProperty("continent_rect", Order = 5)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle ContinentRectangle { get; set; }

        /// <summary>
        /// Gets or sets the default floor of this map.
        /// </summary>
        [JsonProperty("default_floor", Order = 3)]
        public int DefaultFloor { get; set; }

        /// <summary>
        /// Gets or sets the dimensions of the map.
        /// </summary>
        [JsonProperty("map_rect", Order = 4)]
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
        /// Gets or sets the map's name.
        /// </summary>
        [JsonProperty("name", Order = 0)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of Points of Interest.
        /// </summary>
        [JsonProperty("points_of_interest", Order = 6)]
        public IEnumerable<PointOfInterest> PointsOfInterest { get; set; }

        /// <summary>
        /// Gets or sets a list of areas within the map.
        /// </summary>
        [JsonProperty("sectors", Order = 9)]
        public IEnumerable<Sector> Sectors { get; set; }

        /// <summary>
        /// Gets or sets a list of skill challenges.
        /// </summary>
        [JsonProperty("skill_challenges", Order = 8)]
        public IEnumerable<SkillChallenge> SkillChallenges { get; set; }

        /// <summary>
        /// Gets or sets a list of renown hearts.
        /// </summary>
        [JsonProperty("tasks", Order = 7)]
        public IEnumerable<Task> Tasks { get; set; }
    }
}