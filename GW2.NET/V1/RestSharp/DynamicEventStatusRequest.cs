// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventStatusRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.DynamicEventsInformation.Status;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for a list of events and their status that match the given filters (if any).
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/events"/> for more information.
    /// </remarks>
    public class DynamicEventStatusRequest : ServiceRequest
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
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DynamicEventsResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<DynamicEventsResult>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<DynamicEventsResult>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<DynamicEventsResult>(serviceClient, cancellationToken);
        }
    }
}