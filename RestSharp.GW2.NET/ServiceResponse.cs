// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a RestSharp-specific implementation of the  interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Mime;

    using global::GW2DotNET.Utilities;

    using global::GW2DotNET.V1.Core.Errors;

    using global::GW2DotNET.V1.ServiceManagement;

    using RestSharp.GW2DotNET.ServiceResponses;

    /// <summary>Provides a RestSharp-specific implementation of the <see cref="IServiceResponse{TResult}"/> interface.</summary>
    /// <typeparam name="TResult">The type of the response content.</typeparam>
    public class ServiceResponse<TResult> : IServiceResponse<TResult>
        where TResult : class
    {
        /// <summary>Infrastructure. Stores the inner <see cref="IRestResponse" />.</summary>
        private readonly IRestResponse restResponse;

        /// <summary>Infrastructure. Stores a response's result.</summary>
        private TResult result;

        /// <summary>Initializes a new instance of the <see cref="ServiceResponse{TResult}"/> class.</summary>
        /// <param name="restResponse">The <see cref="IRestResponse"/>.</param>
        public ServiceResponse(IRestResponse restResponse)
        {
            Preconditions.EnsureNotNull(paramName: "restResponse", value: restResponse);

            this.restResponse = restResponse;
        }

        /// <summary>Gets a value indicating the Internet media type of the message content.</summary>
        public ContentType ContentType
        {
            get
            {
                if (string.IsNullOrEmpty(this.restResponse.ContentType))
                {
                    return null;
                }

                return new ContentType(this.restResponse.ContentType);
            }
        }

        /// <summary>Gets a value indicating whether the service returned an image response.</summary>
        public bool IsImageResponse
        {
            get
            {
                if (this.ContentType == null)
                {
                    return false;
                }

                return this.ContentType.MediaType.StartsWith("image", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>Gets a value indicating whether the service returned a JSON response.</summary>
        public bool IsJsonResponse
        {
            get
            {
                if (this.ContentType == null)
                {
                    return false;
                }

                return string.Equals(this.ContentType.MediaType, "application/json", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>Gets a value indicating whether the service returned a success status code.</summary>
        public bool IsSuccessStatusCode
        {
            get
            {
                var status = this.StatusCode;
                return status == HttpStatusCode.OK || ((int)status > 200 && (int)status < 300);
            }
        }

        /// <summary>Gets the status code.</summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                return this.restResponse.StatusCode;
            }
        }

        /// <summary>Gets the status description.</summary>
        public string StatusDescription
        {
            get
            {
                return this.restResponse.StatusDescription;
            }
        }

        /// <summary>Gets the response content as an instance of the specified type.</summary>
        /// <returns>The response content.</returns>
        public TResult Deserialize()
        {
            if (this.result != null)
            {
                return this.result;
            }

            using (var stream = new MemoryStream(this.restResponse.RawBytes))
            {
                return this.result = this.Deserialize(stream);
            }
        }

        /// <summary>Gets the error result if the request was unsuccessful.</summary>
        /// <returns>Return the error response as an instance of the <see cref="ErrorResult" /> class.</returns>
        public ErrorResult DeserializeError()
        {
            throw new NotSupportedException();
        }

        /// <summary>Throws an exception if the request did not return a success status code.</summary>
        /// <returns>Returns the current instance.</returns>
        /// <remarks>The current instance is returned to allow chaining method calls.</remarks>
        public IServiceResponse<TResult> EnsureSuccessStatusCode()
        {
            if (this.IsSuccessStatusCode)
            {
                return this;
            }

            var errorResponse = new ErrorResponse(this.restResponse);
            throw new ServiceException(errorResponse.Deserialize(), this.restResponse.ErrorException);
        }

        /// <summary>Gets the response content as an instance of the specified type.</summary>
        /// <param name="stream">The response stream.</param>
        /// <returns>The response content.</returns>
        protected virtual TResult Deserialize(Stream stream)
        {
            throw new NotSupportedException("Unable to deserialize the response content: the type of 'TResult' is unsupported.");
        }
    }
}