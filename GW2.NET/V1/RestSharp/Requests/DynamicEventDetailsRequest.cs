// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details;

namespace GW2DotNET.V1.RestSharp.Requests
{
    /// <summary>
    ///     Represents a request for static details about dynamic events.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details" /> for more information.
    /// </remarks>
    public class DynamicEventDetailsRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventDetailsRequest" /> class.
        /// </summary>
        public DynamicEventDetailsRequest()
            : base(Resources.EventDetails)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventDetailsRequest" /> class.
        /// </summary>
        /// <param name="languageInfo">The output language.</param>
        public DynamicEventDetailsRequest(CultureInfo languageInfo)
            : base(Resources.EventDetails, languageInfo)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventDetailsRequest" /> class.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        public DynamicEventDetailsRequest(Guid eventId)
            : this()
        {
            this.AddParameter("event_id", eventId);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicEventDetailsRequest" /> class.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="languageInfo">The output language.</param>
        public DynamicEventDetailsRequest(Guid eventId, CultureInfo languageInfo)
            : this(languageInfo)
        {
            this.AddParameter("event_id", eventId);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DynamicEventDetailsResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<DynamicEventDetailsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventDetailsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<DynamicEventDetailsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventDetailsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<DynamicEventDetailsResult>(serviceClient, cancellationToken);
        }
    }
}