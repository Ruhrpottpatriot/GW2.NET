// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for service clients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for service clients.</summary>
    public interface IServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="request"/> is a null reference.</exception>
        /// <returns>An instance of the specified type.</returns>
        IResponse<TResult> Send<TResult>(IRequest request);

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="request"/> is a null reference.</exception>
        /// <returns>An instance of the specified type.</returns>
        Task<IResponse<TResult>> SendAsync<TResult>(IRequest request);

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="request"/> is a null reference.</exception>
        /// <returns>An instance of the specified type.</returns>
        Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, CancellationToken cancellationToken);
    }
}