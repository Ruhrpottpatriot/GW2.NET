// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using RestSharp;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides a RestSharp-specific implementation of the <see cref="IApiRequest"/> interface.
    /// </summary>
    public abstract class ApiRequest : RestRequest, IApiRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        protected ApiRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class using the specified resource path.
        /// </summary>
        /// <param name="resource">A relative URI that indicates the target endpoint.</param>
        protected ApiRequest(Uri resource)
            : base(Preconditions.EnsureNotNull(paramName: "resource", value: resource))
        {
            if (resource.IsAbsoluteUri)
            {
                throw new ArgumentException("'resource' should be a relative path.");
            }
        }

        #endregion Constructors

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public virtual IApiResponse<TContent> GetResponse<TContent>(IApiClient handler) where TContent : JsonObject, new()
        {
            return handler.Send<TContent>(this);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public virtual Task<IApiResponse<TContent>> GetResponseAsync<TContent>(IApiClient handler) where TContent : JsonObject, new()
        {
            return handler.SendAsync<TContent>(this);
        }
    }
}