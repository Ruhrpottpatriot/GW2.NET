// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Status
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     Represents a dynamic event and its status.
    /// </summary>
    public class DynamicEvent : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the <see cref="Guid" /> identifying the event.
        /// </summary>
        [JsonProperty("event_id", Order = 2)]
        public Guid EventId { get; set; }

        /// <summary>
        ///     Gets or sets the map on which the event is running.
        /// </summary>
        [JsonProperty("map_id", Order = 1)]
        public int MapId { get; set; }

        /// <summary>
        ///     Gets or sets the current state of the event.
        /// </summary>
        [JsonProperty("state", Order = 3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DynamicEventState State { get; set; }

        /// <summary>
        ///     Gets or sets the world on which the event is running.
        /// </summary>
        [JsonProperty("world_id", Order = 0)]
        public int WorldId { get; set; }

        #endregion
    }
}