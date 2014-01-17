// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.Events
{
    /// <summary>
    /// Represents a dynamic event and its status.
    /// </summary>
    public partial class DynamicEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEvent"/> class.
        /// </summary>
        public DynamicEvent()
        {
        }

        /// <summary>
        /// Gets or sets the world on which the event is running.
        /// </summary>
        [JsonProperty("world_id")]
        public int WorldId { get; set; }

        /// <summary>
        /// Gets or sets the map on which the event is running.
        /// </summary>
        [JsonProperty("map_id")]
        public int MapId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Guid"/> identifying the event.
        /// </summary>
        [JsonProperty("event_id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid EventId { get; set; }

        /// <summary>
        /// Gets or sets the current state of the event.
        /// </summary>
        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EventState State { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
