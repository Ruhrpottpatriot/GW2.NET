// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a plain .NET implementation of the  interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;
    using System.Drawing;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common.ServiceResponses;
    using GW2DotNET.V1.Common.Types;

    /// <summary>Provides a plain .NET implementation of the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Infrastructure. Stores the base URL.</summary>
        private readonly Uri baseUrl;

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class using the specified base URL and JSON de-serializer.</summary>
        /// <param name="baseUrl">An absolute URI that represents the base URL for all API endpoints.</param>
        public ServiceClient(Uri baseUrl)
        {
            Preconditions.EnsureNotNull(paramName: "baseUrl", value: baseUrl);
            Preconditions.Ensure(baseUrl.IsAbsoluteUri, paramName: "baseUrl", message: "'baseUrl' cannot be a relative URI.");

            this.baseUrl = baseUrl;
        }

        /// <summary>Gets the base URL.</summary>
        public Uri BaseUrl
        {
            get
            {
                return this.baseUrl;
            }
        }

        /// <summary>Factory method. Creates a new instance of the <see cref="ServiceClient" /> class.</summary>
        /// <returns>A new instance of the <see cref="ServiceClient" /> class.</returns>
        public static IServiceClient DataServiceClient()
        {
            return new ServiceClient(new Uri(Services.DataServiceUrl));
        }

        /// <summary>Factory method. Creates a new instance of the <see cref="ServiceClient" /> class.</summary>
        /// <returns>A new instance of the <see cref="ServiceClient" /> class.</returns>
        public static IServiceClient RenderServiceClient()
        {
            return new ServiceClient(new Uri(Services.RenderServiceUrl));
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <returns>The <see cref="IServiceResponse{TResult}"/>.</returns>
        public IServiceResponse<TResult> Send<TResult>(IServiceRequest serviceRequest) where TResult : class
        {
            Preconditions.EnsureNotNull(paramName: "serviceRequest", value: serviceRequest);

            return this.SendImplementation<TResult>(serviceRequest);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <returns>The <see cref="IServiceResponse{TResult}"/>.</returns>
        public Task<IServiceResponse<TResult>> SendAsync<TResult>(IServiceRequest serviceRequest) where TResult : class
        {
            return this.SendAsync<TResult>(serviceRequest, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="IServiceResponse{TResult}"/>.</returns>
        public Task<IServiceResponse<TResult>> SendAsync<TResult>(IServiceRequest serviceRequest, CancellationToken cancellationToken) where TResult : class
        {
            Preconditions.EnsureNotNull(paramName: "serviceRequest", value: serviceRequest);

            return this.SendAsyncImplementation<TResult>(serviceRequest, cancellationToken);
        }

        /// <summary>Infrastructure. Creates a new instance of the <see cref="System.Net.WebRequest"/> class.</summary>
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <returns>The <see cref="System.Net.WebRequest"/>.</returns>
        private WebRequest CreateWebRequest(IServiceRequest serviceRequest)
        {
            var uriBuilder = new UriBuilder(this.BaseUrl) { Path = serviceRequest.ResourceUri.ToString(), Query = serviceRequest.GetQueryString() };

            var request = (HttpWebRequest)WebRequest.Create(uriBuilder.ToString());
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");

            return request;
        }

        /// <summary>Infrastructure. Implementation details for 'SendAsync'.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="IServiceResponse{TResult}"/>.</returns>
        private Task<IServiceResponse<TResult>> SendAsyncImplementation<TResult>(IServiceRequest serviceRequest, CancellationToken cancellationToken)
            where TResult : class
        {
            var request = this.CreateWebRequest(serviceRequest);

            return Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null).ContinueWith<IServiceResponse<TResult>>(
                task =>
                    {
                        HttpWebResponse response;
                        if (task.IsFaulted && task.Exception != null)
                        {
                            // catch WebException exception
                            var exception = task.Exception.GetBaseException() as WebException;
                            if (exception != null && exception.Status == WebExceptionStatus.ProtocolError)
                            {
                                response = (HttpWebResponse)exception.Response;
                                var serviceResponse = new ErrorResponse(response);

                                throw new ServiceException(serviceResponse.Deserialize(), exception);
                            }
                        }

                        // unhandled exceptions at this point (if any) are propagated back to the calling thread automatically
                        response = (HttpWebResponse)task.Result;

                        if (typeof(JsonObject).IsAssignableFrom(typeof(TResult)))
                        {
                            return new JsonResponse<TResult>(response);
                        }

                        if (typeof(Image).IsAssignableFrom(typeof(TResult)))
                        {
                            return (IServiceResponse<TResult>)new ImageResponse(response);
                        }

                        if (typeof(string) == typeof(TResult))
                        {
                            return (IServiceResponse<TResult>)new TextResponse(response);
                        }

                        return new ServiceResponse<TResult>(response);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Implementation details for 'Send'.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <returns>The <see cref="IServiceResponse{TResult}"/>.</returns>
        private IServiceResponse<TResult> SendImplementation<TResult>(IServiceRequest serviceRequest) where TResult : class
        {
            var request = this.CreateWebRequest(serviceRequest);

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                if (typeof(JsonObject).IsAssignableFrom(typeof(TResult)))
                {
                    return new JsonResponse<TResult>(response);
                }

                if (typeof(Image).IsAssignableFrom(typeof(TResult)))
                {
                    return (IServiceResponse<TResult>)new ImageResponse(response);
                }

                if (typeof(string) == typeof(TResult))
                {
                    return (IServiceResponse<TResult>)new TextResponse(response);
                }

                return new ServiceResponse<TResult>(response);
            }
            catch (WebException exception)
            {
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    throw;
                }

                var response = (HttpWebResponse)exception.Response;
                var serviceResponse = new ErrorResponse(response);

                throw new ServiceException(serviceResponse.Deserialize(), exception);
            }
        }
    }
}