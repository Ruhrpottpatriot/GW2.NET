// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base interface for HTTP requests targeting the Guild Wars 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Provides the base interface for HTTP requests targeting the Guild Wars 2 API.
    /// </summary>
    public interface IServiceRequest
    {
        #region Public Methods and Operators

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        IServiceResponse<TContent> GetResponse<TContent>(IServiceClient serviceClient) where TContent : JsonObject;

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        Task<IServiceResponse<TContent>> GetResponseAsync<TContent>(IServiceClient serviceClient) where TContent : JsonObject;

        /// <summary>Sends the current request and returns a response.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        Task<IServiceResponse<TContent>> GetResponseAsync<TContent>(IServiceClient serviceClient, CancellationToken cancellationToken)
            where TContent : JsonObject;

        #endregion
    }
}