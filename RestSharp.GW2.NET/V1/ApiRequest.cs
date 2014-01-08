// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;

namespace RestSharp.GW2DotNET.V1
{
    /// <summary>
    /// Provides a RestSharp-specific implementation of the IApiRequest interface.
    /// </summary>
    public abstract class ApiRequest : IApiRequest
    {
        /// <summary>
        /// Infrastructure. Stores the inner <see cref="IRestRequest"/>.
        /// </summary>
        internal readonly IRestRequest InnerRequest;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class using the specified <see cref="IRestRequest"/>.
        /// </summary>
        /// <param name="innerRequest">The inner request object.</param>
        internal ApiRequest(IRestRequest innerRequest)
        {
            this.InnerRequest = innerRequest;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        protected ApiRequest()
            : this(new RestRequest())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class using the specified resource path.
        /// </summary>
        /// <param name="resource">A relative URI that indicates the target endpoint.</param>
        protected ApiRequest(Uri resource)
            : this(new RestRequest(resource))
        {
            if (resource.IsAbsoluteUri)
            {
                throw new ArgumentException("'resource' should be a relative path.");
            }
        }

        #endregion

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response content.</typeparam>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an <see cref="ApiResponse"/>.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public virtual IApiResponse<TResponse> GetResponse<TResponse>(IApiClient handler)
        {
            return handler.Send<TResponse>(this);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response content.</typeparam>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an <see cref="ApiResponse"/>.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public virtual Task<IApiResponse<TResponse>> GetResponseAsync<TResponse>(IApiClient handler)
        {
            return handler.SendAsync<TResponse>(this);
        }
    }
}
