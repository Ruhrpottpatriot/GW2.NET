// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApiRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides the base interface for HTTP requests targeting the Guild Wars 2 API.
    /// </summary>
    public interface IApiRequest
    {
        /// <summary>
        /// Sends this request to the specified API client and retrieves a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="handler">The HTTP client that sends the request over a network and returns a response.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        IApiResponse<TContent> GetResponse<TContent>(IApiClient handler) where TContent : JsonObject, new();

        /// <summary>
        /// Asynchronously sends this request to the specified API client and retrieves a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="handler">The HTTP client that sends the request over a network and returns a response.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        Task<IApiResponse<TContent>> GetResponseAsync<TContent>(IApiClient handler) where TContent : JsonObject, new();
    }
}