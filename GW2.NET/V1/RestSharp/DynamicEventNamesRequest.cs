// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.DynamicEventsInformation.Names;
using GW2DotNET.V1.Core.Utilities;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for a list of event names for the specified language.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names" /> for more information.
    /// </remarks>
    public class DynamicEventNamesRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventNamesRequest" /> class.
        /// </summary>
        public DynamicEventNamesRequest()
            : base(new Uri(Resources.EventNames, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEventNamesRequest" /> class.
        /// </summary>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages" />.</param>
        public DynamicEventNamesRequest(CultureInfo language)
            : base(new Uri(Resources.EventNames + "?lang={language}", UriKind.Relative))
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ServiceClient" /> and retrieves a response whose content is of type <see cref="DynamicEventNames" />.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient" /> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}" />.</param>
        /// <returns>Returns an instance of type <see cref="DynamicEventNames" />.</returns>
        public IServiceResponse<DynamicEventNames> GetResponse(IServiceClient handler)
        {
            return base.GetResponse<DynamicEventNames>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient" /> and retrieves a response whose content is of type <see cref="DynamicEventNames" />.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient" /> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}" />.</param>
        /// <returns>Returns an instance of type <see cref="DynamicEventNames" />.</returns>
        public Task<IServiceResponse<DynamicEventNames>> GetResponseAsync(IServiceClient handler)
        {
            return base.GetResponseAsync<DynamicEventNames>(handler);
        }
    }
}