// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.Utilities;
using RestSharp;
using JsonObject = GW2DotNET.V1.Core.JsonObject;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Provides a RestSharp-specific implementation of the <see cref="IServiceRequest"/> interface.
    /// </summary>
    public abstract class ServiceRequest : RestRequest, IServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequest"/> class.
        /// </summary>
        /// <param name="resource">A relative URI that indicates the target endpoint.</param>
        protected ServiceRequest(Uri resource)
            : base(Preconditions.EnsureNotNull(paramName: "resource", value: resource))
        {
            if (resource.IsAbsoluteUri)
            {
                throw new ArgumentException("'resource' should be a relative path.");
            }
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public virtual IServiceResponse<TContent> GetResponse<TContent>(IServiceClient serviceClient) where TContent : JsonObject
        {
            return serviceClient.Send<TContent>(this);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public virtual Task<IServiceResponse<TContent>> GetResponseAsync<TContent>(IServiceClient serviceClient) where TContent : JsonObject
        {
            return serviceClient.SendAsync<TContent>(this);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public virtual Task<IServiceResponse<TContent>> GetResponseAsync<TContent>(IServiceClient serviceClient, CancellationToken cancellationToken) where TContent : JsonObject
        {
            return serviceClient.SendAsync<TContent>(this, cancellationToken);
        }
    }
}