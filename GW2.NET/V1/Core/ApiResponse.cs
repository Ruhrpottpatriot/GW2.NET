// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;
using Newtonsoft.Json;
using RestSharp;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides a RestSharp-specific implementation of the <see cref="IApiResponse{TContent}"/> interface.
    /// </summary>
    /// <typeparam name="TContent">The type of the response content.</typeparam>
    public class ApiResponse<TContent> : RestResponse<TContent>, IApiResponse<TContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{TContent}"/> class using the specified <see cref="IRestResponse{TContent}"/>.
        /// </summary>
        /// <param name="source">The source response object.</param>
        /// <remarks>Copy constructor.</remarks>
        [SuppressMessage("CSharp.Readability", "SA1100:DoNotPrefixCallsWithBaseUnlessLocalImplementationExists", Justification = "We want to set the properties on 'base', because 'this' might shadow their implementation.")]
        internal ApiResponse(IRestResponse<TContent> source)
        {
            this.Content = source.Content;
            this.ContentEncoding = source.ContentEncoding;
            this.ContentLength = source.ContentLength;
            base.ContentType = source.ContentType;
            this.ErrorException = source.ErrorException;
            this.ErrorMessage = source.ErrorMessage;
            this.RawBytes = source.RawBytes;
            this.ResponseStatus = source.ResponseStatus;
            this.ResponseUri = source.ResponseUri;
            this.Server = source.Server;
            this.StatusCode = source.StatusCode;
            this.StatusDescription = source.StatusDescription;
            this.Request = source.Request;
            this.Headers = source.Headers;
            this.Cookies = source.Cookies;
            this.Data = source.Data;
        }

        /// <summary>
        /// Gets a value indicating whether the service returned a success status code.
        /// </summary>
        public bool IsSuccessStatusCode
        {
            get
            {
                return this.StatusCode == HttpStatusCode.OK;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the service returned a JSON response.
        /// </summary>
        public bool IsJsonResponse
        {
            get
            {
                return string.Equals(this.ContentType.MediaType, "application/json", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Gets a value indicating the Internet media type of the message content.
        /// </summary>
        public new ContentType ContentType
        {
            get
            {
                return new ContentType(base.ContentType);
            }
        }

        /// <summary>
        /// Throws an exception if the service did not return a success status code.
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
            if (this.StatusCode == HttpStatusCode.InternalServerError)
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
        public TContent DeserializeResponse()
        {
            if (!this.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("The service returned an error response.");
            }

            return this.Data;
        }

        /// <summary>
        /// Gets the error result if the request was unsuccessful.
        /// </summary>
        /// <returns>Return an instance of <see cref="ApiException"/> that represents the request error.</returns>
        public ApiException DeserializeError()
        {
            if (this.IsSuccessStatusCode || !this.IsJsonResponse)
            { /* This method only makes sense when the response content is a JSON-formatted API error. */
                throw new InvalidOperationException("The service did not return an error response.");
            }

            /* Use an anonymous object to hold the error details. */
            var errorDetails = JsonConvert.DeserializeAnonymousType(
                value: this.Content,
                anonymousTypeObject: new /* object */
                {
                    /*int*/ error = 0,
                    /*int*/ product = 0,
                    /*int*/ module = 0,
                    /*int*/ line = 0,
                    /*string*/ text = string.Empty
                });

            /* Create a new exception using the values from the anonymous object. */
            return new ApiException(
                error: errorDetails.error,
                product: errorDetails.product,
                module: errorDetails.module,
                line: errorDetails.line,
                text: errorDetails.text,
                innerException: this.ErrorException);
        }

        /// <summary>
        /// Returns a string that represents the current response.
        /// </summary>
        /// <returns>Returns a JSON-formatted string.</returns>
        public override string ToString()
        {
            if (!this.IsJsonResponse)
            {
                return string.Empty;
            }

            return this.Content;
        }
    }
}
