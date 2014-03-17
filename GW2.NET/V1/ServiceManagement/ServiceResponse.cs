// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a plain .NET implementation of the  interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Net.Mime;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Core;
    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Errors;

    using Newtonsoft.Json;

    /// <summary>Provides a plain .NET implementation of the <see cref="IServiceResponse{TResult}"/> interface.</summary>
    /// <typeparam name="TResult">The type of the response content.</typeparam>
    public class ServiceResponse<TResult> : IServiceResponse<TResult>, IDisposable
        where TResult : class
    {
        /// <summary>Infrastructure. Stores a JSON result.</summary>
        private ErrorResult errorResult;

        /// <summary>Infrastructure. Stores a JSON result.</summary>
        private TResult result;

        /// <summary>Initializes a new instance of the <see cref="ServiceResponse{TResult}"/> class.</summary>
        /// <param name="webResponse">The <see cref="System.Net.HttpWebResponse"/></param>
        /// <param name="webException">The <see cref="System.Net.WebException"/>.</param>
        public ServiceResponse(HttpWebResponse webResponse, WebException webException = null)
        {
            Preconditions.EnsureNotNull(paramName: "webResponse", value: webResponse);

            this.WebResponse = webResponse;
            this.WebException = webException;
        }

        /// <summary>Gets a value indicating the Internet media type of the message content.</summary>
        public ContentType ContentType
        {
            get
            {
                return string.IsNullOrEmpty(this.WebResponse.ContentType) ? null : new ContentType(this.WebResponse.ContentType);
            }
        }

        /// <summary>Gets a value indicating whether is image response.</summary>
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
                return this.WebResponse.StatusCode;
            }
        }

        /// <summary>Gets or sets the web exception.</summary>
        private WebException WebException { get; set; }

        /// <summary>Gets or sets the web response.</summary>
        private HttpWebResponse WebResponse { get; set; }

        /// <summary>Gets the response content as an object of the specified type.</summary>
        /// <returns>Returns the response as an instance of the specified type.</returns>
        public TResult Deserialize()
        {
            if (!this.IsSuccessStatusCode)
            {
                // if the service returned an error code
                throw new InvalidOperationException("Unable to deserialize the response content: the service returned an error code.");
            }

            if (typeof(JsonObject).IsAssignableFrom(typeof(TResult)))
            {
                // if the expected result is a JSON object
                if (!this.IsJsonResponse)
                {
                    // if the service didn't include a JSON result object
                    throw new InvalidOperationException("Unable to deserialize the response content: the service did not return a JSON result.");
                }

                return this.result ?? (this.result = DeserializeJson<TResult>(this.WebResponse));
            }

            if (typeof(Image).IsAssignableFrom(typeof(TResult)))
            {
                // if the expected result is an image
                if (!this.IsImageResponse)
                {
                    // if the service didn't include an image result
                    throw new InvalidOperationException("Unable to deserialize the response content: the service did not return an image result.");
                }

                return this.result ?? (this.result = DeserializeImage(this.WebResponse));
            }

            throw new NotSupportedException("Unable to deserialize the response content: the type of 'TResult' is unsupported.");
        }

        /// <summary>Gets the error result if the request was unsuccessful.</summary>
        /// <returns>Return the error response as an instance of the <see cref="ErrorResult" /> class.</returns>
        public ErrorResult DeserializeError()
        {
            if (this.IsSuccessStatusCode)
            {
                // if the service returned a success code
                throw new InvalidOperationException();
            }

            if (!this.IsJsonResponse)
            {
                // if the service didn't include a JSON result object
                return this.errorResult ?? (this.errorResult = new ErrorResult { Text = this.WebException.Message });
            }

            return this.errorResult ?? (this.errorResult = DeserializeJson<ErrorResult>(this.WebResponse));
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this.WebResponse.Close();
        }

        /// <summary>Throws an exception if the service did not return a success code.</summary>
        /// <returns>Returns the current instance.</returns>
        public IServiceResponse<TResult> EnsureSuccessStatusCode()
        {
            if (this.IsSuccessStatusCode)
            {
                return this;
            }

            throw new ServiceException(this.DeserializeError(), this.WebException);
        }

        /// <summary>Infrastructure. Gets the response content.</summary>
        /// <param name="webResponse">The web response.</param>
        /// <returns>The response content.</returns>
        private static TResult DeserializeImage(WebResponse webResponse)
        {
            var stream = webResponse.GetResponseStream() ?? new MemoryStream();

            if (webResponse.Headers[HttpResponseHeader.ContentEncoding] == "gzip")
            {
                stream = new GZipStream(stream, CompressionMode.Decompress, false);
            }

            return (TResult)(object)Image.FromStream(stream);
        }

        /// <summary>Infrastructure. Gets the response content.</summary>
        /// <param name="webResponse">The web response.</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>The response content.</returns>
        private static T DeserializeJson<T>(WebResponse webResponse)
        {
            var stream = webResponse.GetResponseStream() ?? new MemoryStream();

            if (webResponse.Headers[HttpResponseHeader.ContentEncoding] == "gzip")
            {
                stream = new GZipStream(stream, CompressionMode.Decompress, false);
            }

            using (var streamReader = new StreamReader(stream))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.Create();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
    }
}