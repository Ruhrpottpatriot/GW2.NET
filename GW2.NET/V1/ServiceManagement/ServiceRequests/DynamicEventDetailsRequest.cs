// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for static details about dynamic events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    using System;

    /// <summary>Represents a request for static details about dynamic events.</summary>
    public class DynamicEventDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private Guid? eventId;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsRequest"/> class.</summary>
        public DynamicEventDetailsRequest()
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
                this.Query["event_id"] = (this.eventId = value).ToString();
            }
        }
    }
}