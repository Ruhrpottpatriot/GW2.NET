// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details
{
    /// <summary>
    /// Represents details about a specific dynamic event.
    /// </summary>
    public class DynamicEventDetails : JsonObject
    {
        /// <summary>
        /// Gets or sets additional flags.
        /// </summary>
        [JsonProperty("flags", Order = 3)]
        public DynamicEventFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the event level.
        /// </summary>
        [JsonProperty("level", Order = 1)]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the location of the event.
        /// </summary>
        [JsonProperty("location", Order = 4)]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the map where the event takes place.
        /// </summary>
        [JsonProperty("map_id", Order = 2)]
        public int MapId { get; set; }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        [JsonProperty("name", Order = 0)]
        public string Name { get; set; }
    }
}