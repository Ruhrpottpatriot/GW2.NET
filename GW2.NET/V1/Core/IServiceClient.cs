// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceClient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base interface for HTTP clients targeting the Guild Wars 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Provides the base interface for HTTP clients targeting the Guild Wars 2 API.
    /// </summary>
    public interface IServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns>The response.</returns>
        IServiceResponse<TContent> Send<TContent>(IServiceRequest serviceRequest) where TContent : JsonObject;

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns>The response.</returns>
        Task<IServiceResponse<TContent>> SendAsync<TContent>(IServiceRequest serviceRequest) where TContent : JsonObject;

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        Task<IServiceResponse<TContent>> SendAsync<TContent>(IServiceRequest serviceRequest, CancellationToken cancellationToken) where TContent : JsonObject;
    }
}