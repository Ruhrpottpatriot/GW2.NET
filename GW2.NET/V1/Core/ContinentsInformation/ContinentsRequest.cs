// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace GW2DotNET.V1.Core.ContinentsInformation
{
    /// <summary>
    /// Represents a request for static information about the continents.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/continents"/> for more information.
    /// </remarks>
    public class ContinentsRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContinentsRequest"/> class.
        /// </summary>
        public ContinentsRequest()
            : base(new Uri(Resources.Continents, UriKind.Relative))
        {
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="ContinentsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="ContinentsResult"/>.</returns>
        public IApiResponse<ContinentsResult> GetResponse(IApiClient handler)
        {
            return base.GetResponse<ContinentsResult>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="ContinentsResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="ContinentsResult"/>.</returns>
        public Task<IApiResponse<ContinentsResult>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<ContinentsResult>(handler);
        }
    }
}