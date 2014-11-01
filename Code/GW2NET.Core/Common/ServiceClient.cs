// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a default implementation for the <see cref="IServiceClient" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common.Serializers;

    /// <summary>Provides a default implementation for the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Infrastructure. Holds a reference to the base URI.</summary>
        private readonly Uri baseUri;

        /// <summary>Infrastructure. Holds a reference to a serializer factory.</summary>
        private readonly ISerializerFactory errorSerializerFactory;

        /// <summary>Infrastructure. Holds a reference to a GZIP inflator.</summary>
        private readonly IConverter<Stream, Stream> gzipInflator;

        /// <summary>Infrastructure. Holds a reference to a serializer factory.</summary>
        private readonly ISerializerFactory successSerializerFactory;

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="successSerializerFactory">The serializer factory.</param>
        /// <param name="errorSerializerFactory">The error serializer Factory.</param>
        /// <param name="gzipInflator">The GZIP inflator.</param>
        public ServiceClient(
            Uri baseUri,
            ISerializerFactory successSerializerFactory,
            ISerializerFactory errorSerializerFactory,
            IConverter<Stream, Stream> gzipInflator)
        {
            Contract.Requires(baseUri != null);
            Contract.Requires(successSerializerFactory != null);
            Contract.Requires(errorSerializerFactory != null);
            Contract.Requires(gzipInflator != null);
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
                var resource = string.Format(request.Resource, request.GetPathSegments().Cast<object>().ToArray());
                uri = BuildUri(this.baseUri, resource, formData);
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
                var httpWebRequest = CreateHttpWebRequest(uri);
                using (var response = GetHttpWebResponse(httpWebRequest))
                {
                    Contract.Assume(response != null);
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
        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, CancellationToken cancellationToken)
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
                var resource = string.Format(request.Resource, request.GetPathSegments().Cast<object>().ToArray());
                uri = BuildUri(this.baseUri, resource, formData);
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
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                {
                    using (var response = task.Result)
                    {
                        try
                        {
                            return this.OnResponse<TResult>(response);
                        }
                        catch (ServiceException exception)
                        {
                            // Set the cause of this exception
                            exception.Request = request;

                            // Rethrow
                            throw;
                        }
                    }
                },
                cancellationToken);
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="UriBuilder"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="resource">The resource name.</param>
        /// <param name="formData">The form data.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        /// <exception cref="FormatException">One or more query parameters violate the format for a valid URI as defined by RFC 2396.</exception>
        private static Uri BuildUri(Uri baseUri, string resource, UrlEncodedForm formData)
        {
            Contract.Requires(baseUri != null);
            Contract.Requires(formData != null);
            var uriBuilder = new UriBuilder(baseUri) { Path = resource, Query = formData.GetQueryString() };
            return uriBuilder.Uri;
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="HttpWebRequest"/> class.</summary>
        /// <param name="uri">The resource <see cref="Uri"/>.</param>
        /// <returns>The <see cref="HttpWebRequest"/>.</returns>
        private static HttpWebRequest CreateHttpWebRequest(Uri uri)
        {
            Contract.Requires(uri != null);
            Contract.Ensures(Contract.Result<HttpWebRequest>() != null);

            // Create a new request object for the specified resource
            var request = (HttpWebRequest)WebRequest.Create(uri);

            // Provide some hints to the static contracts checker
            Contract.Assume(request != null);
            Contract.Assume(request.Headers != null);

            // Set 'Accept-Encoding' to 'gzip'
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";

            // Return the request object
            return request;
        }

        /// <summary>Infrastructure. Deserializes the response stream.</summary>
        /// <param name="response">The response.</param>
        /// <param name="serializerFactory">The serializer factory.</param>
        /// <param name="gzipInflator">The GZIP inflator.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private static TResult DeserializeResponse<TResult>(
            HttpWebResponse response,
            ISerializerFactory serializerFactory,
            IConverter<Stream, Stream> gzipInflator)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);
            Contract.Requires(gzipInflator != null);

            // Get the response content
            var stream = response.GetResponseStream();

            // Ensure that there is response content
            if (stream == null)
            {
                return default(TResult);
            }

            Contract.Assume(response.Headers != null);

            // Ensure that we are operating on decompressed data
            var contentEncoding = response.Headers["Content-Encoding"];
            if (contentEncoding != null)
            {
                var compressed = contentEncoding.Equals("gzip", StringComparison.OrdinalIgnoreCase);
                if (compressed)
                {
                    var uncompressed = gzipInflator.Convert(stream);
                    if (uncompressed != null)
                    {
                        stream = uncompressed;
                    }
                }
            }

            Contract.Assume(stream.CanRead);

            // Create a serializer
            var serializer = serializerFactory.GetSerializer<TResult>();

            // Deserialize the response content
            return serializer.Deserialize(stream);
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static HttpWebResponse GetHttpWebResponse(HttpWebRequest webRequest)
        {
            Contract.Requires(webRequest != null);

            try
            {
                return GetHttpWebResponseAsync(webRequest, CancellationToken.None).Result;
            }
            catch (AggregateException ex)
            {
                throw ex.GetBaseException();
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The request could not be fulfilled.</exception>
        private static Task<HttpWebResponse> GetHttpWebResponseAsync(HttpWebRequest webRequest, CancellationToken cancellationToken)
        {
            Contract.Requires(webRequest != null);
            Contract.Ensures(Contract.Result<Task<HttpWebResponse>>() != null);
            cancellationToken.Register(webRequest.Abort);
            var tcs = new TaskCompletionSource<HttpWebResponse>();
            try
            {
                webRequest.BeginGetResponse(
                    ar =>
                    {
                        try
                        {
                            tcs.SetResult((HttpWebResponse)webRequest.EndGetResponse(ar));
                        }
                        catch (WebException webException)
                        {
                            if (webException.Response != null)
                            {
                                tcs.SetResult((HttpWebResponse)webException.Response);
                            }
                            else
                            {
                                tcs.SetException(new ServiceException("An error occurred while sending the request. See the inner exception for details.", webException));
                            }
                        }
                        catch (Exception exception)
                        {
                            tcs.SetException(exception);
                        }
                    },
                    null);
            }
            catch (WebException webException)
            {
                if (webException.Status == WebExceptionStatus.RequestCanceled)
                {
                    tcs.SetCanceled();
                }
                else
                {
                    tcs.SetException(webException);
                }
            }

            var task = tcs.Task;
            Contract.Assume(task != null);
            return task;
        }

        /// <summary>Infrastructure. Throws an exception for error responses.</summary>
        /// <param name="response">The error response.</param>
        /// <param name="serializerFactory">The factory class that provides the serialization engine for the response.</param>
        /// <param name="gzipInflator">The GZIP inflator that decompresses the response.</param>
        /// <exception cref="ServiceException">The exception that represents the error.</exception>
        private static void OnError(HttpWebResponse response, ISerializerFactory serializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);
            Contract.Requires(gzipInflator != null);

            string message;


            var contentType = response.ContentType;

            // Get the most specific error description that is available
            if (contentType != null && contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
            {
                // Get the response content
                var errorResult = DeserializeResponse<ErrorResult>(response, serializerFactory, gzipInflator);

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

        /// <summary>Infrastructure. Creates a response object for success responses.</summary>
        /// <param name="response">The success response.</param>
        /// <param name="serializerFactory">The factory class that provides the serialization engine for the response.</param>
        /// <param name="gzipInflator">The GZIP inflator that decompresses the response.</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>The object that represents the response.</returns>
        private static IResponse<T> OnSuccess<T>(HttpWebResponse response, ISerializerFactory serializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);
            Contract.Requires(gzipInflator != null);
            Contract.Ensures(Contract.Result<IResponse<T>>() != null);
            Contract.Ensures(Contract.Result<IResponse<T>>().ExtensionData != null);

            // Create a new generic response object
            var value = new Response<T>();

            // Set the deserialized response content
            value.Content = DeserializeResponse<T>(response, serializerFactory, gzipInflator);

            var headers = response.Headers;
            Contract.Assume(headers != null);

            // Set the 'Date' header
            var date = headers["Date"];
            if (date != null)
            {
                value.Date = DateTimeOffset.Parse(date);
            }

            // Set the 'Content-Language' header
            var contentLanguage = headers["Content-Language"];
            if (contentLanguage != null)
            {
                value.Culture = new CultureInfo(contentLanguage);
            }

            // Set the 'X'-tension headers
            var headerKeys = headers.AllKeys;
            Contract.Assume(headerKeys != null);
            foreach (var key in headerKeys)
            {
                if (key == null)
                {
                    continue;
                }

                if (key.StartsWith("X-", StringComparison.Ordinal))
                {
                    value.ExtensionData[key] = headers[key];
                }
            }

            // Return the response object
            return value;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.baseUri != null);
            Contract.Invariant(this.gzipInflator != null);
            Contract.Invariant(this.successSerializerFactory != null);
            Contract.Invariant(this.errorSerializerFactory != null);
        }

        /// <summary>Infrastructure. Handles a response.</summary>
        /// <param name="response">The response to handle.</param>
        /// <typeparam name="TResult">The type of the response content</typeparam>
        /// <returns>The response as an instance of <see cref="IResponse{TResult}"/>.</returns>
        /// <exception cref="ServiceException">The request could not be fulfilled.</exception>
        private IResponse<TResult> OnResponse<TResult>(HttpWebResponse response)
        {
            Contract.Requires(response != null);
            Contract.Ensures(Contract.Result<IResponse<TResult>>() != null);
            try
            {
                if (!response.StatusCode.IsSuccessStatusCode())
                {
                    OnError(response, this.errorSerializerFactory, this.gzipInflator);
                }

                return OnSuccess<TResult>(response, this.successSerializerFactory, this.gzipInflator);
            }
            catch (SerializationException serializationException)
            {
                throw new ServiceException("An error occurred while deserializing response data. See the inner exception for details", serializationException);
            }
        }
    }
}