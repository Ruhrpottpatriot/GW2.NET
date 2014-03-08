// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.DynamicEventsInformation.Status;

namespace RestSharp.Requests
{
    /// <summary>
    ///     Represents a request for a list of events and their status that match the given filters (if any).
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/events" /> for more information.
    /// </remarks>
    public class DynamicEventRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventRequest" /> class.
        /// </summary>
        public DynamicEventRequest()
            : base(Resources.Events)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventRequest" /> class.
        /// </summary>
        /// <param name="worldId">The world ID.</param>
        /// <param name="mapId">The map ID.</param>
        /// <param name="eventId">The event ID.</param>
        public DynamicEventRequest(int? worldId = null, int? mapId = null, Guid? eventId = null)
            : this()
        {
            if (worldId.HasValue)
            {
                this.AddParameter("world_id", worldId);
            }

            if (mapId.HasValue)
            {
                this.AddParameter("map_id", mapId);
            }

            if (eventId.HasValue)
            {
                this.AddParameter("event_id", eventId);
            }
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DynamicEventsResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<DynamicEventsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<DynamicEventsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<DynamicEventsResult>(serviceClient, cancellationToken);
        }
    }
}