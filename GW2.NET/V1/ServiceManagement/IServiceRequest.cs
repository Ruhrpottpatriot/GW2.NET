// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base interface for HTTP requests targeting the Guild Wars 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the base interface for HTTP requests targeting the Guild Wars 2 API.</summary>
    public interface IServiceRequest
    {
        /// <summary>Gets the query.</summary>
        IDictionary<string, string> Query { get; }

        /// <summary>Gets the resource URI.</summary>
        Uri ResourceUri { get; }

        /// <summary>Gets the query string.</summary>
        /// <returns>The query <see cref="string" />.</returns>
        string GetQueryString();

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        IServiceResponse<TResult> GetResponse<TResult>(IServiceClient serviceClient) where TResult : class;

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        Task<IServiceResponse<TResult>> GetResponseAsync<TResult>(IServiceClient serviceClient) where TResult : class;

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        Task<IServiceResponse<TResult>> GetResponseAsync<TResult>(IServiceClient serviceClient, CancellationToken cancellationToken) where TResult : class;
    }
}