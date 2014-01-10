// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Net;
using GW2DotNET.V1.Core;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides a RestSharp-specific implementation of the IApiResponse interface.
    /// </summary>
    /// <typeparam name="TContent">The type of the response content.</typeparam>
    public class ApiResponse<TContent> : IApiResponse<TContent>
    {
        /// <summary>
        /// Infrastructure. Stores the inner <see cref="IRestResponse"/>.
        /// </summary>
        protected readonly IRestResponse InnerResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{TContent}"/> class using the specified <see cref="IRestResponse"/>.
        /// </summary>
        /// <param name="innerResponse">The inner response object.</param>
        internal ApiResponse(IRestResponse innerResponse)
        {
            this.InnerResponse = innerResponse;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ApiRequest"/> returned a success status code.
        /// </summary>
        public bool IsSuccessStatusCode
        {
            get
            {
                return this.InnerResponse.StatusCode == HttpStatusCode.OK;
            }
        }

        /// <summary>
        /// Throws an exception if the request did not return a success status code.
        /// </summary>
        /// <returns>Returns the current instance.</returns>
        /// <remarks>The current instance is returned to allow chaining method calls.</remarks>
        /// <example>
        /// <code>
        /// <![CDATA[var responseContent = request.GetResponse<ObjectType>.EnsureSuccessStatusCode().DeserializeObject();]]>
        /// </code>
        /// </example>
        public IApiResponse<TContent> EnsureSuccessStatusCode()
        {
            if (this.IsSuccessStatusCode)
            {
                return this;
            }

            var apiException = this.DeserializeError();
            if (this.InnerResponse.StatusCode == HttpStatusCode.InternalServerError)
            { /* HTTP status 500 (typically) indicates missing or invalid arguments */
                throw new ArgumentException(apiException.Message, apiException);
            }
            else
            { /* Unknown error */
                throw apiException;
            }
        }

        /// <summary>
        /// Gets the response content as an object of the specified type.
        /// </summary>
        /// <returns>Returns an instance of the specified type that represents the response.</returns>
        public TContent DeserializeObject()
        {
            return JsonConvert.DeserializeObject<TContent>(this.InnerResponse.Content);
        }

        /// <summary>
        /// Gets the error result if the request was unsuccessful.
        /// </summary>
        /// <returns>Return an instance of <see cref="ApiException"/> that represents the request error.</returns>
        public ApiException DeserializeError()
        {
            if (this.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }

            var errorDetails = JsonConvert.DeserializeAnonymousType(
                this.InnerResponse.Content,
                new /* anonymous object */
                {
                    /*int*/
                    error = 0,
                    /*int*/
                    product = 0,
                    /*int*/
                    module = 0,
                    /*int*/
                    line = 0,
                    /*string*/
                    text = string.Empty
                });
            return new ApiException(
                errorDetails.error,
                errorDetails.product,
                errorDetails.module,
                errorDetails.line,
                errorDetails.text,
                this.InnerResponse.ErrorException);
        }
    }
}
