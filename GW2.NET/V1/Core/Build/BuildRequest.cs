// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;

namespace GW2DotNET.V1.Core.Build
{
    /// <summary>
    /// Represents a request for the current build ID of the game.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/build"/> for more information.
    /// </remarks>
    public class BuildRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildRequest"/> class.
        /// </summary>
        public BuildRequest()
            : base(new Uri(Resources.Build, UriKind.Relative))
        {
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="BuildResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="BuildResponse"/>.</returns>
        public IApiResponse<BuildResponse> GetResponse(IApiClient handler)
        {
            return base.GetResponse<BuildResponse>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="BuildResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="BuildResponse"/>.</returns>
        public Task<IApiResponse<BuildResponse>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<BuildResponse>(handler);
        }
    }
}