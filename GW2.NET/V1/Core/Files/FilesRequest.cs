// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;

namespace GW2DotNET.V1.Core.Files
{
    /// <summary>
    /// Represents a request for commonly requested in-game assets.
    /// The returned information can be used with the render service to retrieve assets.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/files"/> for more information.
    /// </remarks>
    public class FilesRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilesRequest"/> class.
        /// </summary>
        public FilesRequest()
            : base(new Uri(Resources.Files, UriKind.Relative))
        {
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="FilesResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="FilesResponse"/>.</returns>
        public IApiResponse<FilesResponse> GetResponse(IApiClient handler)
        {
            return base.GetResponse<FilesResponse>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="FilesResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="FilesResponse"/>.</returns>
        public Task<IApiResponse<FilesResponse>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<FilesResponse>(handler);
        }
    }
}
