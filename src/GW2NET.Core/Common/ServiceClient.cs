﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a default implementation for the <see cref="IServiceClient" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Runtime.ExceptionServices;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common.Serializers;

    /// <summary>Provides a default implementation for the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        private readonly Uri baseUri;

        private readonly ISerializerFactory errorSerializerFactory;

        private readonly IConverter<Stream, Stream> gzipInflator;

        private readonly ISerializerFactory successSerializerFactory;

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="successSerializerFactory">The serializer factory.</param>
        /// <param name="errorSerializerFactory">The error serializer Factory.</param>
        /// <param name="gzipInflator">The GZIP inflator.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="baseUri"/> or <paramref name="successSerializerFactory"/> or <paramref name="errorSerializerFactory"/> or <paramref name="gzipInflator"/> is a null reference.</exception>
        public ServiceClient(Uri baseUri, ISerializerFactory successSerializerFactory, ISerializerFactory errorSerializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }

            if (successSerializerFactory == null)
            {
                throw new ArgumentNullException("successSerializerFactory");
            }

            if (errorSerializerFactory == null)
            {
                throw new ArgumentNullException("errorSerializerFactory");
            }

            if (gzipInflator == null)
            {
                throw new ArgumentNullException("gzipInflator");
            }

            this.baseUri = baseUri;
            this.successSerializerFactory = successSerializerFactory;
            this.errorSerializerFactory = errorSerializerFactory;
            this.gzipInflator = gzipInflator;
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <exception cref="ServiceException">The service responded with an error code.</exception>
        /// <returns>An instance of the specified type.</returns>
        public IResponse<TResult> Send<TResult>(IRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm();
            foreach (var parameter in request.GetParameters())
            {
                formData[parameter.Key] = parameter.Value;
            }

            // Build the resource URI
            Uri uri;
            try
            {
                uri = this.BuildRequestUri(this.baseUri, request.Resource, formData);
            }
            catch (FormatException formatException)
            {
                // Caught when the given parameters would result in an invalid URI
                // Wrap the FormatException in a ServiceException
                throw new ServiceException("An error occurred while formatting the request URI. See the inner exception for details.", formatException)
                {
                    Request = request
                };
            }

            // Handle the request
            try
            {
                var httpWebRequest = this.CreateHttpWebRequest(uri);
                using (var response = this.GetHttpWebResponse(httpWebRequest))
                {
                    Debug.Assert(response != null, "response != null");
                    return this.OnResponse<TResult>(response);
                }
            }
            catch (ServiceException serviceException)
            {
                // Set the cause of this ServiceException
                serviceException.Request = request;

                // Rethrow
                throw;
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <exception cref="ServiceException">The service responded with an error code.</exception>
        /// <returns>An instance of the specified type.</returns>
        public async Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm();
            foreach (var parameter in request.GetParameters())
            {
                formData[parameter.Key] = parameter.Value;
            }

            // Build the resource URI
            Uri uri;
            try
            {
                uri = this.BuildRequestUri(this.baseUri, request.Resource, formData);
            }
            catch (FormatException formatException)
            {
                // Caught when the given parameters would result in an invalid URI
                // Wrap the FormatException in a ServiceException
                throw new ServiceException("An error occurred while formatting the request URI. See the inner exception for details.", formatException)
                {
                    Request = request
                };
            }

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            var httpWebResponse = await GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ConfigureAwait(false);
            using (httpWebResponse)
            {
                try
                {
                    return this.OnResponse<TResult>(httpWebResponse);
                }
                catch (ServiceException exception)
                {
                    // Set the cause of this exception
                    exception.Request = request;

                    // Rethrow
                    throw;
                }
            }
        }

        /// <summary>Creates and configures a new instance of the <see cref="UriBuilder"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="resource">The resource name.</param>
        /// <param name="formData">The form data.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        /// <exception cref="FormatException">One or more query parameters violate the format for a valid URI as defined by RFC 2396.</exception>
        protected virtual Uri BuildRequestUri(Uri baseUri, string resource, UrlEncodedForm formData)
        {
            Debug.Assert(baseUri != null, "baseUri != null");
            Debug.Assert(formData != null, "formData != null");
            var uriBuilder = new UriBuilder(baseUri)
            {
                Path = resource,
                Query = formData.GetQueryString()
            };
            return uriBuilder.Uri;
        }

        /// <summary>Creates and configures a new instance of the <see cref="HttpWebRequest"/> class.</summary>
        /// <param name="uri">The resource <see cref="Uri"/>.</param>
        /// <returns>The <see cref="HttpWebRequest"/>.</returns>
        protected virtual HttpWebRequest CreateHttpWebRequest(Uri uri)
        {
            Debug.Assert(uri != null, "uri != null");

            // Create a new request object for the specified resource
            var request = (HttpWebRequest)WebRequest.Create(uri);

            Debug.Assert(request != null, "request != null");
            Debug.Assert(request.Headers != null, "request.Headers != null");

            // Set 'Accept-Encoding' to 'gzip'
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";

            // Return the request object
            return request;
        }

        /// <summary>Deserializes the response stream.</summary>
        /// <param name="response">The response.</param>
        /// <param name="serializerFactory">The serializer factory.</param>
        /// <param name="gzipInflator">The GZIP inflator.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private TResult DeserializeResponse<TResult>(HttpWebResponse response, ISerializerFactory serializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Debug.Assert(response != null, "response != null");
            Debug.Assert(serializerFactory != null, "serializerFactory != null");
            Debug.Assert(gzipInflator != null, "gzipInflator != null");

            // Get the response content
            var stream = response.GetResponseStream();

            // Ensure that there is response content
            if (stream == null)
            {
                return default(TResult);
            }

            Debug.Assert(response != null, "response != null");
            Debug.Assert(response.Headers != null, "response.Headers != null");

            // Ensure that we are operating on decompressed data
            var contentEncoding = response.Headers["Content-Encoding"];
            if (contentEncoding != null)
            {
                var compressed = contentEncoding.Equals("gzip", StringComparison.OrdinalIgnoreCase);
                if (compressed)
                {
                    var uncompressed = gzipInflator.Convert(stream, null);
                    if (uncompressed != null)
                    {
                        stream = uncompressed;
                    }
                }
            }

            Debug.Assert(stream.CanRead, "stream.CanRead");

            // Create a serializer
            var serializer = serializerFactory.GetSerializer<TResult>();

            // Deserialize the response content
            return serializer.Deserialize(stream);
        }

        /// <summary>Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private HttpWebResponse GetHttpWebResponse(HttpWebRequest webRequest)
        {
            Debug.Assert(webRequest != null, "webRequest != null");
            HttpWebResponse httpWebResponse;
            var task = this.GetHttpWebResponseAsync(webRequest, CancellationToken.None);
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
            finally
            {
                httpWebResponse = task.Result;
            }

            return httpWebResponse;
        }

        /// <summary>Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The request could not be fulfilled.</exception>
        private async Task<HttpWebResponse> GetHttpWebResponseAsync(HttpWebRequest webRequest, CancellationToken cancellationToken)
        {
            Debug.Assert(webRequest != null, "webRequest != null");
            cancellationToken.Register(webRequest.Abort);

            try
            {
                return (HttpWebResponse)await webRequest.GetResponseAsync();
            }
            catch (WebException webException)
            {
                if (webException.Status == WebExceptionStatus.RequestCanceled)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return null;
                }
                else if (webException.Response != null)
                {
                    return (HttpWebResponse)webException.Response;
                }
                else
                {
                    throw new ServiceException("An error occurred while sending the request. See the inner exception for details.", webException);
                }
            }
        }

        /// <summary>Throws an exception for error responses.</summary>
        /// <param name="response">The error response.</param>
        /// <param name="serializerFactory">The factory class that provides the serialization engine for the response.</param>
        /// <param name="gzipInflator">The GZIP inflator that decompresses the response.</param>
        /// <exception cref="ServiceException">The exception that represents the error.</exception>
        private void OnError(HttpWebResponse response, ISerializerFactory serializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Debug.Assert(response != null, "response != null");
            Debug.Assert(serializerFactory != null, "serializerFactory != null");
            Debug.Assert(gzipInflator != null, "gzipInflator != null");
            string message;

            var contentType = response.ContentType;

            // Get the most specific error description that is available
            if (contentType != null && contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
            {
                // Get the response content
                var errorResult = this.DeserializeResponse<ErrorResult>(response, serializerFactory, gzipInflator);

                // Get the error description, or null if none was returned
                message = errorResult != null ? errorResult.Text : null;
            }
            else
            {
                message = response.StatusDescription;
            }

            // Throw an exception
            throw new ServiceException(message);
        }

        /// <summary>Creates a response object for success responses.</summary>
        /// <param name="response">The success response.</param>
        /// <param name="serializerFactory">The factory class that provides the serialization engine for the response.</param>
        /// <param name="gzipInflator">The GZIP inflator that decompresses the response.</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>The object that represents the response.</returns>
        private IResponse<T> OnSuccess<T>(HttpWebResponse response, ISerializerFactory serializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Debug.Assert(response != null, "response != null");
            Debug.Assert(response.Headers != null, "headers != null");
            Debug.Assert(serializerFactory != null, "serializerFactory != null");
            Debug.Assert(gzipInflator != null, "gzipInflator != null");

            // Create a new generic response object
            var value = new Response<T>();

            // Set the deserialized response content
            value.Content = this.DeserializeResponse<T>(response, serializerFactory, gzipInflator);

            // Set the 'Date' header
            var date = response.Headers["Date"];
            if (date != null)
            {
                value.Date = DateTimeOffset.Parse(date, DateTimeFormatInfo.InvariantInfo);
            }

            // Set the 'Content-Language' header
            var contentLanguage = response.Headers["Content-Language"];
            if (contentLanguage != null)
            {
                value.Culture = new CultureInfo(contentLanguage);
            }

            // Set the 'X'-tension headers
            foreach (var key in response.Headers.AllKeys)
            {
                if (key == null)
                {
                    continue;
                }

                if (key.StartsWith("X-", StringComparison.Ordinal))
                {
                    value.ExtensionData[key] = response.Headers[key];
                }
            }

            // Return the response object
            return value;
        }

        /// <summary>Handles a response.</summary>
        /// <param name="response">The response to handle.</param>
        /// <typeparam name="TResult">The type of the response content</typeparam>
        /// <returns>The response as an instance of <see cref="IResponse{TResult}"/>.</returns>
        /// <exception cref="ServiceException">The request could not be fulfilled.</exception>
        private IResponse<TResult> OnResponse<TResult>(HttpWebResponse response)
        {
            Debug.Assert(response != null, "response != null");
            try
            {
                if (!(((int)response.StatusCode >= 200) && ((int)response.StatusCode < 300)))
                {
                    this.OnError(response, this.errorSerializerFactory, this.gzipInflator);
                }

                return this.OnSuccess<TResult>(response, this.successSerializerFactory, this.gzipInflator);
            }
            catch (SerializationException serializationException)
            {
                throw new ServiceException("An error occurred while deserializing response data. See the inner exception for details", serializationException);
            }
        }
    }
}
