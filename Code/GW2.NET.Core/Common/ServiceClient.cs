// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a default implementation for the <see cref="IServiceClient" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common.Serializers;

    /// <summary>Provides a default implementation for the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Infrastructure. Holds a reference to the base URI.</summary>
        private readonly Uri baseUri;

        /// <summary>Infrastructure. Holds a reference to a serializer factory.</summary>
        private readonly ISerializerFactory errorSerializerFactory;

        /// <summary>Infrastructure. Holds a reference to a serializer factory.</summary>
        private readonly ISerializerFactory successSerializerFactory;

        private readonly IConverter<Stream, Stream> gzipInflator;

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="successSerializerFactory">The serializer factory.</param>
        /// <param name="errorSerializerFactory">The error serializer Factory.</param>
        /// <param name="gzipInflator">The GZIP inflator.</param>
        public ServiceClient(Uri baseUri, ISerializerFactory successSerializerFactory, ISerializerFactory errorSerializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Contract.Requires(baseUri != null);
            Contract.Requires(baseUri.IsAbsoluteUri);
            Contract.Requires(successSerializerFactory != null);
            Contract.Requires(errorSerializerFactory != null);
            Contract.Requires(gzipInflator != null);
            Contract.Ensures(this.baseUri.IsAbsoluteUri);
            this.baseUri = baseUri;
            this.successSerializerFactory = successSerializerFactory;
            this.errorSerializerFactory = errorSerializerFactory;
            this.gzipInflator = gzipInflator;
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
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
            var uri = BuildUri(this.baseUri, request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                if (!response.StatusCode.IsSuccessStatusCode())
                {
                    OnError(response, this.errorSerializerFactory, this.gzipInflator);
                }

                return OnSuccess<TResult>(response, this.successSerializerFactory, this.gzipInflator);
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
            var uri = BuildUri(this.baseUri, request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                {
                    using (var response = task.Result)
                    {
                        if (!response.StatusCode.IsSuccessStatusCode())
                        {
                            OnError(response, this.errorSerializerFactory, this.gzipInflator);
                        }

                        return OnSuccess<TResult>(response, this.successSerializerFactory, this.gzipInflator);
                    }
                },
                cancellationToken);
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="UriBuilder"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="resource">The resource name.</param>
        /// <param name="formData">The form data.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
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
        private static TResult DeserializeResponse<TResult>(HttpWebResponse response, ISerializerFactory serializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);

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
                    stream = gzipInflator.Convert(stream);
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
            Contract.Ensures(Contract.Result<HttpWebResponse>() != null);

            try
            {
                return GetHttpWebResponseAsync(webRequest, CancellationToken.None).Result;
            }
            catch (AggregateException ex)
            {
                var innerException = ex.GetBaseException();
                throw new WebException(innerException.Message, innerException);
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static Task<HttpWebResponse> GetHttpWebResponseAsync(HttpWebRequest webRequest, CancellationToken cancellationToken)
        {
            Contract.Requires(webRequest != null);
            return Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, null).ContinueWith(
                task =>
                {
                    // Handle protocol errors
                    // TODO: should we wrap timeouts in a System.TimeoutException?
                    if (task.IsFaulted)
                    {
                        var exception = task.Exception.GetBaseException() as WebException;
                        if (exception != null && exception.Response != null)
                        {
                            // Get the response
                            var errorResponse = exception.Response;

                            // Return the response
                            return (HttpWebResponse)errorResponse;
                        }
                    }

                    // Get the response
                    // unhandled transport errors (if any) are propagated back to the calling thread when accessing task.Result
                    var webResponse = task.Result;

                    // Return the response
                    return (HttpWebResponse)webResponse;
                },
                cancellationToken);
        }

        /// <summary>Infrastructure. Post-processes a response object.</summary>
        /// <param name="response">The raw response.</param>
        /// <param name="serializerFactory">The response content serializer factory.</param>
        /// <param name="gzipInflator">The GZIP inflator.</param>
        private static void OnError(HttpWebResponse response, ISerializerFactory serializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);

            // Get the response content
            var errorResult = DeserializeResponse<ErrorResult>(response, serializerFactory, gzipInflator);

            // Get the error description, or null if none was returned
            var errorMessage = errorResult != null ? errorResult.Text : null;

            // Throw an exception
            throw new ServiceException(errorMessage);
        }

        /// <summary>Infrastructure. Post-processes a response object.</summary>
        /// <param name="response">The raw response.</param>
        /// <param name="serializerFactory">The response content serializer factory.</param>
        /// <param name="gzipInflator">The GZIP inflator.</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>A processed response object.</returns>
        private static IResponse<T> OnSuccess<T>(HttpWebResponse response, ISerializerFactory serializerFactory, IConverter<Stream, Stream> gzipInflator)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);
            Contract.Ensures(Contract.Result<IResponse<T>>() != null);
            Contract.Ensures(Contract.Result<IResponse<T>>().ExtensionData != null);

            // Create a new generic response object
            var value = new Response<T>();

            // Set the deserialized response content
            value.Content = DeserializeResponse<T>(response, serializerFactory, gzipInflator);

            // Set the 'Date' header
            var date = response.Headers["Date"];
            if (date != null)
            {
                value.Date = DateTimeOffset.Parse(date);
            }

            // Set the 'Content-Language' header
            var contentLanguage = response.Headers["Content-Language"];
            if (contentLanguage != null)
            {
                value.Culture = new CultureInfo(contentLanguage);
            }

            // Set the 'X'-tension headers
            foreach (var key in response.Headers.AllKeys.Where(key => key.StartsWith("X-", StringComparison.Ordinal)))
            {
                value.ExtensionData[key] = response.Headers[key];
            }

            // Return the response object
            return value;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.baseUri != null);
            Contract.Invariant(this.successSerializerFactory != null);
            Contract.Invariant(this.errorSerializerFactory != null);
        }
    }
}