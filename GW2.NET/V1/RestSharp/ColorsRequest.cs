// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using GW2DotNET.V1.Core.Utilities;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for information regarding dyes in the game.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/colors"/> for more information.
    /// </remarks>
    public class ColorsRequest : ServiceRequest
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
        /// Sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="DyesDetailsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="DyesDetailsResult"/>.</returns>
        public IServiceResponse<DyesDetailsResult> GetResponse(IServiceClient handler)
        {
            return base.GetResponse<DyesDetailsResult>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="DyesDetailsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="DyesDetailsResult"/>.</returns>
        public Task<IServiceResponse<DyesDetailsResult>> GetResponseAsync(IServiceClient handler)
        {
            return base.GetResponseAsync<DyesDetailsResult>(handler);
        }
    }
}