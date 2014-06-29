// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of events and their status that match the given filters (if any).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for a list of events and their status that match the given filters (if any).</summary>
    public class DynamicEventRequest : IDynamicEventRequest
    {
        /// <summary>Gets or sets the event identifier.</summary>
        public Guid? EventId { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        public int? MapId { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return Services.Events;
            }
        }

        /// <summary>Gets or sets the world identifier.</summary>
        public int? WorldId { get; set; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            // Get the 'world_id' parameter
            if (this.WorldId.HasValue)
            {
                yield return new KeyValuePair<string, string>("world_id", this.WorldId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Get the 'map_id' parameter
            if (this.MapId.HasValue)
            {
                yield return new KeyValuePair<string, string>("map_id", this.MapId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Get the 'event_id' parameter
            if (this.EventId.HasValue)
            {
                yield return new KeyValuePair<string, string>("event_id", this.EventId.Value.ToString());
            }
        }
    }
}