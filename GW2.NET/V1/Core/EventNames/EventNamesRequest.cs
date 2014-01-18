// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GW2DotNET.V1.Core.EventNames
{
    /// <summary>
    /// Represents a request for a list of event names for the specified language.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names"/> for more information.
    /// </remarks>
    public class EventNamesRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventNamesRequest"/> class.
        /// </summary>
        public EventNamesRequest()
            : base(new Uri(Resources.EventNames, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventNamesRequest"/> class.
        /// </summary>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public EventNamesRequest(CultureInfo language)
            : base(new Uri(Resources.EventNames + "?lang={language}", UriKind.Relative))
        {
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="EventNamesResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="EventNamesResponse"/>.</returns>
        public IApiResponse<EventNamesResponse> GetResponse(IApiClient handler)
        {
            return base.GetResponse<EventNamesResponse>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="EventNamesResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="EventNamesResponse"/>.</returns>
        public Task<IApiResponse<EventNamesResponse>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<EventNamesResponse>(handler);
        }
    }
}