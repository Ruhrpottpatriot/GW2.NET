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
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
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

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        public ServiceClient(Uri baseUri)
        {
            Contract.Requires(baseUri != null);
            Contract.Requires(baseUri.IsAbsoluteUri);
            Contract.Ensures(this.baseUri.IsAbsoluteUri);
            this.baseUri = baseUri;
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public IResponse<TResult> Send<TResult>(IRequest request, ISerializer<TResult> serializer)
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
                return PostProcess(response, serializer);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, ISerializer<TResult> serializer)
        {
            return this.SendAsync(request, serializer, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, ISerializer<TResult> serializer, CancellationToken cancellationToken)
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
                            return PostProcess(response, serializer);
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
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");

            // Return the request object
            return request;
        }

        /// <summary>Infrastructure. Deserializes the response stream.</summary>
        /// <param name="serializer">The serialization engine.</param>
        /// <param name="response">The response.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private static TResult DeserializeResponse<TResult>(ISerializer<TResult> serializer, HttpWebResponse response)
        {
            Contract.Requires(serializer != null);
            Contract.Requires(response != null);

            // Get the response content
            var stream = response.GetResponseStream();

            // Ensure that there is response content
            if (stream == null)
            {
                return default(TResult);
            }

            Contract.Assume(response.Headers != null);

            // Ensure that we are operating on decompressed data
            var contentEncoding = response.Headers[HttpResponseHeader.ContentEncoding];
            if (contentEncoding != null)
            {
                var compressed = contentEncoding.Equals("gzip", StringComparison.OrdinalIgnoreCase);
                if (compressed)
                {
                    stream = new GZipStream(stream, CompressionMode.Decompress);
                }
            }

            Contract.Assume(stream.CanRead);

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
                // Get the response
                var webResponse = webRequest.GetResponse();

                // Provide a hint to the static checker
                Contract.Assume(webResponse != null);

                // Return the response
                return (HttpWebResponse)webResponse;
            }
            catch (WebException exception)
            {
                // Simply rethrow in case of transport errors (e.g. timeout)
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    // TODO: should we wrap timeouts in a System.TimeoutException?
                    throw;
                }

                // Wrap the exception in a ServiceException, then throw
                using (var response = exception.Response)
                {
                    var errorResult = new JsonSerializer<ErrorResult>().Deserialize(response.GetResponseStream());
                    throw new ServiceException(errorResult.Text, exception);
                }
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
                        if (task.IsFaulted && task.Exception != null)
                        {
                            var exception = task.Exception.GetBaseException() as WebException;

                            // Handle only protocol errors
                            if (exception != null && exception.Status == WebExceptionStatus.ProtocolError)
                            {
                                // Wrap the exception in a ServiceException, then throw
                                using (var response = exception.Response)
                                {
                                    var errorResult = new JsonSerializer<ErrorResult>().Deserialize(response.GetResponseStream());
                                    throw new ServiceException(errorResult.Text, exception);
                                }
                            }
                        }

                        // unhandled transport errors (if any) are propagated back to the calling thread when accessing task.Result
                        // TODO: should we wrap timeouts in a System.TimeoutException?
                        return (HttpWebResponse)task.Result;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Post-processes a response object.</summary>
        /// <param name="response">The raw response.</param>
        /// <param name="serializer">The response content serializer.</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>A processed response object.</returns>
        private static IResponse<T> PostProcess<T>(HttpWebResponse response, ISerializer<T> serializer)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializer != null);
            Contract.Ensures(Contract.Result<IResponse<T>>() != null);

            // Create a new generic response object
            var value = new Response<T>();

            // Set the deserialized response content
            value.Content = DeserializeResponse(serializer, response);

            // Set the 'Date' header
            value.LastModified = response.LastModified;

            // Set the 'Content-Language' header
            Contract.Assume(response.Headers != null);
            var contentLanguage = response.Headers["Content-Language"];
            if (contentLanguage != null)
            {
                value.Culture = CultureInfo.GetCultureInfo(contentLanguage);
            }

            // Set the 'X'-tension headers
            var extensionData = new Dictionary<string, string>();
            foreach (var key in response.Headers.AllKeys.Where(key => key.StartsWith("X-", StringComparison.OrdinalIgnoreCase)))
            {
                extensionData[key] = response.Headers[key];
            }

            value.ExtensionData = extensionData;

            // Return the response object
            return value;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.baseUri != null);
        }
    }
}