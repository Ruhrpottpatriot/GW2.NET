// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a plain .NET implementation of the <see cref="IServiceResponse{TResult}" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Common
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Net.Mime;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common.ServiceResponses;

    /// <summary>Provides a plain .NET implementation of the <see cref="IServiceResponse{TResult}"/> interface.</summary>
    /// <typeparam name="TResult">The type of the response content.</typeparam>
    public class ServiceResponse<TResult> : IServiceResponse<TResult>, IDisposable
        where TResult : class
    {
        /// <summary>Infrastructure. Stores the inner <see cref="HttpWebResponse" />.</summary>
        private readonly HttpWebResponse webResponse;

        /// <summary>Infrastructure. Stores a response's result.</summary>
        private TResult result;

        /// <summary>Initializes a new instance of the <see cref="ServiceResponse{TResult}"/> class.</summary>
        /// <param name="webResponse">The <see cref="System.Net.HttpWebResponse"/>.</param>
        public ServiceResponse(HttpWebResponse webResponse)
        {
            Preconditions.EnsureNotNull(paramName: "webResponse", value: webResponse);

            this.webResponse = webResponse;
        }

        /// <summary>Gets a value indicating the Internet media type of the message content.</summary>
        public ContentType ContentType
        {
            get
            {
                if (string.IsNullOrEmpty(this.webResponse.ContentType))
                {
                    return null;
                }

                return new ContentType(this.webResponse.ContentType);
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

        /// <summary>Gets the status code.</summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                return this.webResponse.StatusCode;
            }
        }

        /// <summary>Gets the status description.</summary>
        public string StatusDescription
        {
            get
            {
                return this.webResponse.StatusDescription;
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

            Stream stream;

            using (stream = this.webResponse.GetResponseStream() ?? new MemoryStream())
            {
                if (this.webResponse.Headers[HttpResponseHeader.ContentEncoding] == "gzip")
                {
                    stream = new GZipStream(stream, CompressionMode.Decompress, false);
                }

                return this.result = this.Deserialize(stream);
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this.webResponse.Close();
        }

        /// <summary>Throws an exception if the service did not return a success code.</summary>
        /// <returns>Returns the current instance.</returns>
        public IServiceResponse<TResult> EnsureSuccessStatusCode()
        {
            if (this.StatusCode.IsSuccessStatusCode())
            {
                return this;
            }

            var errorResponse = new ErrorResponse(this.webResponse);
            throw new ServiceException(errorResponse.Deserialize());
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