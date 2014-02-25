// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
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
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequest"/> class.
        /// </summary>
        protected ServiceRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequest"/> class using the specified resource path.
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

        #endregion Constructors

        /// <summary>
        /// Sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public virtual IServiceResponse<TContent> GetResponse<TContent>(IServiceClient handler) where TContent : JsonObject
        {
            return handler.Send<TContent>(this);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public virtual Task<IServiceResponse<TContent>> GetResponseAsync<TContent>(IServiceClient handler) where TContent : JsonObject
        {
            return handler.SendAsync<TContent>(this);
        }
    }
}