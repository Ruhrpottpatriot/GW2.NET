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
using GW2DotNET.V1.Core.Utilities;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for static details about dynamic events.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details"/> for more information.
    /// </remarks>
    public class DynamicEventDetailsRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventDetailsRequest"/> class.
        /// </summary>
        public DynamicEventDetailsRequest()
            : base(new Uri(Resources.EventDetails, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventDetailsRequest"/> class using the specified language.
        /// </summary>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public DynamicEventDetailsRequest(CultureInfo language)
            : base(new Uri(Resources.EventDetails + "?lang={language}", UriKind.Relative))
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventDetailsRequest"/> class using the specified event ID.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        public DynamicEventDetailsRequest(Guid eventId)
            : base(new Uri(Resources.EventDetails + "?event_id={event_id}", UriKind.Relative))
        {
            this.AddUrlSegment("event_id", eventId.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventDetailsRequest"/> class using the specified event ID and language.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public DynamicEventDetailsRequest(Guid eventId, CultureInfo language)
            : base(new Uri(Resources.EventDetails + "?event_id={event_id}&lang={language}", UriKind.Relative))
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("event_id", eventId.ToString());
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DynamicEventDetailsResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<DynamicEventDetailsResult>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventDetailsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<DynamicEventDetailsResult>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DynamicEventDetailsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<DynamicEventDetailsResult>(serviceClient, cancellationToken);
        }
    }
}