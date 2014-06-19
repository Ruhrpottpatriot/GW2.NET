// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a default implementation for the <see cref="IServiceClient" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;

    using GW2DotNET.Utilities;
    using GW2DotNET.V2.Common.Contracts;

    using Newtonsoft.Json;

    /// <summary>Provides a default implementation for the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        public TResult Send<TResult>(IRequest request)
        {
            // Build the resource URI
            var uriBuilder = BuildUriBuilder();
            uriBuilder.Path = string.Concat("/v2/", request.Resource);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uriBuilder.Uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IDetailsRequest request, CultureInfo culture = null)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm();

            // Set the 'lang' parameter
            if (culture != null)
            {
                formData["lang"] = culture.TwoLetterISOLanguageName;
            }

            // Build the resource URI
            var uriBuilder = BuildUriBuilder();
            uriBuilder.Path = string.Format("/v2/{0}/{1}", request.Resource, request.Identifier);
            uriBuilder.Query = formData.GetQueryString();

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uriBuilder.Uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        public TResult Send<TResult>(IBulkRequest request, CultureInfo culture = null)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm();

            // Set the 'ids' parameter
            if (request.Identifiers.Any())
            {
                formData["ids"] = string.Join(",", request.Identifiers);
            }
            else
            {
                formData["ids"] = "all";
            }

            // Set the 'lang' parameter
            if (culture != null)
            {
                formData["lang"] = culture.TwoLetterISOLanguageName;
            }

            // Build the resource URI
            var uriBuilder = BuildUriBuilder();
            uriBuilder.Path = string.Concat("/v2/", request.Resource);
            uriBuilder.Query = formData.GetQueryString();

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uriBuilder.Uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="culture">The culture.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        public TResult Send<TResult>(IPaginatedRequest request, CultureInfo culture = null)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm();

            // Set the 'page' parameter
            if (request.Page > 0)
            {
                formData.Add("page", request.Page.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'page_size' parameter
            if (request.PageSize != 10)
            {
                formData.Add("page_size", request.PageSize.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            if (culture != null)
            {
                formData.Add("lang", culture.TwoLetterISOLanguageName);
            }

            // Build the resource URI
            var uriBuilder = BuildUriBuilder();
            uriBuilder.Path = string.Concat("/v2/", request.Resource);
            uriBuilder.Query = formData.GetQueryString();

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uriBuilder.Uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="UriBuilder"/> class.</summary>
        /// <returns>The <see cref="UriBuilder"/>.</returns>
        private static UriBuilder BuildUriBuilder()
        {
            return new UriBuilder { Scheme = "https", Host = "api.guildwars2.com" };
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="HttpWebRequest"/> class.</summary>
        /// <param name="uri">The resource <see cref="Uri"/>.</param>
        /// <returns>The <see cref="HttpWebRequest"/>.</returns>
        private static HttpWebRequest CreateHttpWebRequest(Uri uri)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            return httpWebRequest;
        }

        /// <summary>Infrastructure. Deserializes the response stream.</summary>
        /// <param name="response">The response.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private static TResult DeserializeResponse<TResult>(HttpWebResponse response)
        {
            var stream = response.GetResponseStream();

            // Ensure that we are operating on decompressed data
            var compressed = response.Headers[HttpResponseHeader.ContentEncoding].Equals("gzip", StringComparison.OrdinalIgnoreCase);
            if (compressed)
            {
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            // Deserialize the response content
            using (stream)
            using (var streamReader = new StreamReader(stream ?? new MemoryStream()))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = JsonSerializer.CreateDefault();
                return serializer.Deserialize<TResult>(jsonReader);
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static HttpWebResponse GetHttpWebResponse(HttpWebRequest webRequest)
        {
            try
            {
                return (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException exception)
            {
                // Simply rethrow in case of transport errors (e.g. timeout)
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    throw;
                }

                // Wrap the exception in a ServiceException, then throw
                using (var response = exception.Response)
                using (var stream = response.GetResponseStream())
                using (var streamReader = new StreamReader(stream ?? new MemoryStream()))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.CreateDefault();
                    var errorResult = serializer.Deserialize<ErrorResult>(jsonReader);
                    throw new ServiceException(null, errorResult, exception);
                }
            }
        }
    }
}