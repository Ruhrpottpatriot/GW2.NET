// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GW2DotNET.V1.Core.Colors
{
    /// <summary>
    /// Represents a request for information regarding all dyes in the game.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/colors"/> for more information.
    /// </remarks>
    public class ColorsRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorsRequest"/> class.
        /// </summary>
        public ColorsRequest()
            : base(new Uri(Resources.Colors, UriKind.Relative))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorsRequest"/> class.
        /// </summary>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public ColorsRequest(CultureInfo language)
            : base(new Uri(Resources.Colors + "?lang={language}", UriKind.Relative))
        {
            this.AddUrlSegment("language", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="ColorsResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="ColorsResponse"/>.</returns>
        public IApiResponse<ColorsResponse> GetResponse(IApiClient handler)
        {
            return base.GetResponse<ColorsResponse>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="ColorsResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="ColorsResponse"/>.</returns>
        public Task<IApiResponse<ColorsResponse>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<ColorsResponse>(handler);
        }
    }
}