// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceClient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides the base interface for HTTP clients targeting the Guild Wars 2 API.
    /// </summary>
    public interface IServiceClient
    {
        /// <summary>
        /// Send a request and return a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The service request that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        IServiceResponse<TContent> Send<TContent>(IServiceRequest request) where TContent : JsonObject;

        /// <summary>
        /// Asynchronously send a request and return a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The service request that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        Task<IServiceResponse<TContent>> SendAsync<TContent>(IServiceRequest request) where TContent : JsonObject;
    }
}