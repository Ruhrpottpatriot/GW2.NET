// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base interface for HTTP clients targeting the Guild Wars 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the base interface for HTTP clients targeting the Guild Wars 2 API.</summary>
    public interface IServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns>The response.</returns>
        IServiceResponse<TResult> Send<TResult>(IServiceRequest serviceRequest) where TResult : class;

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns>The response.</returns>
        Task<IServiceResponse<TResult>> SendAsync<TResult>(IServiceRequest serviceRequest) where TResult : class;

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        Task<IServiceResponse<TResult>> SendAsync<TResult>(IServiceRequest serviceRequest, CancellationToken cancellationToken) where TResult : class;
    }
}