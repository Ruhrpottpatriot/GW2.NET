// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Subregion.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using RectangleConverter = GW2DotNET.V1.Core.Converters.RectangleConverter;

namespace GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions
{
    /// <summary>
    /// Represents a map and its details.
    /// </summary>
    public class Subregion : JsonObject
    {
        /// <summary>
        /// Gets or sets the dimensions of the map within the continent coordinate system.
        /// </summary>
        [JsonProperty("continent_rect", Order = 5)]
        [JsonConverter(typeof(RectangleConverter))]
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
        /// Gets or sets the map's name.
        /// </summary>
        [JsonProperty("name", Order = 0)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a collection of Points of Interest locations.
        /// </summary>
        [JsonProperty("points_of_interest", Order = 6)]
        public PointOfInterestCollection PointsOfInterest { get; set; }

        /// <summary>
        /// Gets or sets a collection of areas within the map.
        /// </summary>
        [JsonProperty("sectors", Order = 9)]
        public SectorCollection Sectors { get; set; }

        /// <summary>
        /// Gets or sets a collection of skill challenge locations.
        /// </summary>
        [JsonProperty("skill_challenges", Order = 8)]
        public SkillChallengeCollection SkillChallenges { get; set; }

        /// <summary>
        /// Gets or sets a collection of renown heart locations.
        /// </summary>
        [JsonProperty("tasks", Order = 7)]
        public RenownTaskCollection Tasks { get; set; }
    }
}