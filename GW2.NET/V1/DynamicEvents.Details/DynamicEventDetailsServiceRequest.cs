// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for static details about dynamic events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.DynamicEvents.Details
{
    using System;

    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for static details about dynamic events.</summary>
    public class DynamicEventDetailsServiceRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private Guid? eventId;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsServiceRequest" /> class.</summary>
        public DynamicEventDetailsServiceRequest()
            : base(Services.EventDetails)
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
                this.FormData["event_id"] = (this.eventId = value).ToString();
            }
        }
    }
}