// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.Events.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Events
{
    /// <summary>
    /// Represents a response that is the result of an <see cref="EventsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/events"/> for more information.
    /// </remarks>
    public class EventsResponse : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventsResponse"/> class.
        /// </summary>
        public EventsResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsResponse"/> class using the specified list of events.
        /// </summary>
        /// <param name="events">The list of events.</param>
        public EventsResponse(IEnumerable<DynamicEvent> events)
        {
            this.Events = events;
        }

        /// <summary>
        /// Gets or sets a list of event details.
        /// </summary>
        [JsonProperty("events", Order = 0)]
        public IEnumerable<DynamicEvent> Events { get; set; }
    }
}