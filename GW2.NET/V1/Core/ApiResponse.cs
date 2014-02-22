// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
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
    public class ApiResponse<TContent> : RestResponse, IApiResponse<TContent> where TContent : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{TContent}"/> class using the specified <see cref="IRestResponse"/>.
        /// </summary>
        /// <param name="source">The source response object.</param>
        /// <remarks>Copy constructor.</remarks>
        internal ApiResponse(IRestResponse source)
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
        /// Gets the error response if the service returned an error status code.
        /// </summary>
        /// <returns>Return the error response as an instance of the <see cref="ApiException"/> class.</returns>
        public ErrorResponse DeserializeError()
        {
            if (this.IsSuccessStatusCode || !this.IsJsonResponse)
            { /* This method only makes sense when the response content is a JSON-formatted API error. */
                throw new InvalidOperationException("The service did not return an error response.");
            }

            return JsonConvert.DeserializeObject<ErrorResponse>(this.Content);
        }

        /// <summary>
        /// Gets the response content as an object of the specified type.
        /// </summary>
        /// <returns>Returns the response as an instance of the specified type.</returns>
        public TContent Deserialize()
        {
            if (!this.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("The service returned an error response.");
            }

            return JsonConvert.DeserializeObject<TContent>(this.Content);
        }

        /// <summary>
        /// Gets the response content as an object of the specified type using the specified <see cref="Newtonsoft.Json.JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="jsonSerializerSettings">The <see cref="Newtonsoft.Json.JsonSerializerSettings"/> used to de-serialize the object.  If this is null, default serialization settings will be is used.</param>
        /// <returns>Returns the response as an instance of the specified type.</returns>
        public TContent Deserialize(JsonSerializerSettings jsonSerializerSettings)
        {
            if (!this.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("The service returned an error response.");
            }

            return JsonConvert.DeserializeObject<TContent>(this.Content, jsonSerializerSettings);
        }

        /// <summary>
        /// Gets the response content as an object of the specified type using a collection of <see cref="Newtonsoft.Json.JsonConverter"/>.
        /// </summary>
        /// <param name="converters">The converters to use while de-serializing.</param>
        /// <returns>Returns the response as an instance of the specified type.</returns>
        public TContent Deserialize(params JsonConverter[] converters)
        {
            if (!this.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("The service returned an error response.");
            }

            return JsonConvert.DeserializeObject<TContent>(this.Content, converters);
        }

        /// <summary>
        /// Throws an exception if the service did not return a success status code.
        /// </summary>
        /// <returns>Returns the current instance.</returns>
        /// <remarks>The current instance is returned to allow chaining method calls.</remarks>
        public IApiResponse<TContent> EnsureSuccessStatusCode()
        {
            if (this.IsSuccessStatusCode)
            {
                return this;
            }

            throw new ApiException(this.DeserializeError(), this.ErrorException);
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