// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventStatusRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using GW2DotNET.V1.Core.DynamicEventsInformation.Status;

namespace GW2DotNET.V1.Core.DynamicEventsInformation
{
    /// <summary>
    /// Represents a request for a list of events and their status that match the given filters (if any).
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/events"/> for more information.
    /// </remarks>
    public class DynamicEventStatusRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventStatusRequest"/> class.
        /// </summary>
        public DynamicEventStatusRequest()
            : base(new Uri(Resources.Events, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventStatusRequest"/> class using the specified world, map and/or event IDs.
        /// </summary>
        /// <param name="worldId">The world ID.</param>
        /// <param name="mapId">The map ID.</param>
        /// <param name="eventId">The event ID.</param>
        public DynamicEventStatusRequest(int? worldId = null, int? mapId = null, Guid? eventId = null)
            : base(new Uri(Resources.Events + "?world_id={world_id}&map_id={map_id}&event_id={event_id}", UriKind.Relative))
        {
            this.AddUrlSegment("world_id", worldId.ToString());
            this.AddUrlSegment("map_id", mapId.ToString());
            this.AddUrlSegment("event_id", eventId.ToString());
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="DynamicEventsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="DynamicEventsResult"/>.</returns>
        public IApiResponse<DynamicEventsResult> GetResponse(IApiClient handler)
        {
            return base.GetResponse<DynamicEventsResult>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="DynamicEventsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="DynamicEventsResult"/>.</returns>
        public Task<IApiResponse<DynamicEventsResult>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<DynamicEventsResult>(handler);
        }
    }
}