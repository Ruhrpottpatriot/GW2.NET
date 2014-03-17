// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of events and their status that match the given filters (if any).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    using System;

    using GW2DotNET.Extensions;

    /// <summary>Represents a request for a list of events and their status that match the given filters (if any).</summary>
    public class DynamicEventRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private Guid? eventId;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int? mapId;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int? worldId;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventRequest" /> class.</summary>
        public DynamicEventRequest()
            : base(Services.Events)
        {
        }

        /// <summary>Gets or sets the event filter.</summary>
        public Guid? EventId
        {
            get
            {
                return this.eventId;
            }

            set
            {
                this.Query["event_id"] = (this.eventId = value).ToString();
            }
        }

        /// <summary>Gets or sets the map filter.</summary>
        public int? MapId
        {
            get
            {
                return this.mapId;
            }

            set
            {
                this.Query["map_id"] = (this.mapId = value).ToStringInvariant();
            }
        }

        /// <summary>Gets or sets the world filter.</summary>
        public int? WorldId
        {
            get
            {
                return this.worldId;
            }

            set
            {
                this.Query["world_id"] = (this.worldId = value).ToStringInvariant();
            }
        }
    }
}