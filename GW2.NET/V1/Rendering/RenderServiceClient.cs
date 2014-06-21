// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a default implementation for the <see cref="IRenderServiceClient" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Rendering
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Contracts;

    using Newtonsoft.Json;

    /// <summary>Provides a default implementation for the <see cref="IRenderServiceClient" /> interface.</summary>
    public class RenderServiceClient : IRenderServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <returns>The response.</returns>
        public Image Send(IRenderRequest request)
        {
            // Build the resource URI
            var uri = BuildUri(request.FileSignature, request.FileId, request.ImageFormat);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <returns>The response.</returns>
        public Task<Image> SendAsync(IRenderRequest request)
        {
            return this.SendAsync(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<Image> SendAsync(IRenderRequest request, CancellationToken cancellationToken)
        {
            // Build the resource URI
            var uri = BuildUri(request.FileSignature, request.FileId, request.ImageFormat);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="UriBuilder"/> class.</summary>
        /// <param name="signature">The signature.</param>
        /// <param name="fileId">The file Id.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        private static Uri BuildUri(string signature, int fileId, string imageFormat)
        {
            var uriBuilder = new UriBuilder
                                 {
                                     Scheme = "https", 
                                     Host = "render.guildwars2.com", 
                                     Path = string.Format("/file/{0}/{1}.{2}", signature, fileId, imageFormat)
                                 };
            return uriBuilder.Uri;
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="HttpWebRequest"/> class.</summary>
        /// <param name="uri">The resource <see cref="Uri"/>.</param>
        /// <returns>The <see cref="HttpWebRequest"/>.</returns>
        private static HttpWebRequest CreateHttpWebRequest(Uri uri)
        {
            return (HttpWebRequest)WebRequest.Create(uri);
        }

        /// <summary>Infrastructure. Deserializes the response stream.</summary>
        /// <param name="response">The response.</param>
        /// <returns>An instance of <see cref="Image"/>.</returns>
        private static Image DeserializeResponse(HttpWebResponse response)
        {
            var stream = response.GetResponseStream() ?? new MemoryStream();

            // Deserialize the response content
            using (stream)
            {
                return Image.FromStream(stream);
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

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static Task<HttpWebResponse> GetHttpWebResponseAsync(HttpWebRequest webRequest, CancellationToken cancellationToken)
        {
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

                        // unhandled transport errors (if any) are propagated back to the calling thread when accessing task.Result
                        return (HttpWebResponse)task.Result;
                    }, 
                cancellationToken);
        }
    }
}