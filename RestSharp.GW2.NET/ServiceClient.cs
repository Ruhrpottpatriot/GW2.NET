// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a RestSharp-specific implementation of the  interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET
{
    using System;
    using System.Drawing;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.Utilities;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.Common;

    using RestSharp.GW2DotNET.ServiceResponses;

    /// <summary>Provides a RestSharp-specific implementation of the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Infrastructure. Stores the inner <see cref="IRestClient" />.</summary>
        private readonly IRestClient innerRestClient;

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="baseUrl">An absolute URI that represents the base URL for all API endpoints.</param>
        public ServiceClient(Uri baseUrl)
        {
            Preconditions.EnsureNotNull(paramName: "baseUrl", value: baseUrl);
            Preconditions.Ensure(baseUrl.IsAbsoluteUri, paramName: "baseUrl", message: "'baseUrl' cannot be a relative URI.");

            this.innerRestClient = new RestClient(baseUrl.ToString());
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="restClient">The inner <see cref="IRestClient"/>.</param>
        public ServiceClient(IRestClient restClient)
        {
            Preconditions.EnsureNotNull(paramName: "restClient", value: restClient);

            this.innerRestClient = restClient;
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
        /// <param name="serviceRequest">The service request.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<TResult> Send<TResult>(IServiceRequest serviceRequest) where TResult : class
        {
            Preconditions.EnsureNotNull(paramName: "serviceRequest", value: serviceRequest);

            return this.SendImplementation<TResult>(serviceRequest);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<TResult>> SendAsync<TResult>(IServiceRequest serviceRequest) where TResult : class
        {
            return this.SendAsync<TResult>(serviceRequest, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<TResult>> SendAsync<TResult>(IServiceRequest serviceRequest, CancellationToken cancellationToken) where TResult : class
        {
            Preconditions.EnsureNotNull(paramName: "serviceRequest", value: serviceRequest);

            return this.SendAsyncImplementation<TResult>(serviceRequest, cancellationToken);
        }

        /// <summary>Infrastructure. Creates a new instance of the <see cref="RestRequest"/> class.</summary>
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <returns>The <see cref="RestRequest"/>.</returns>
        private RestRequest CreateRestRequest(IServiceRequest serviceRequest)
        {
            var uriBuilder = new UriBuilder(this.innerRestClient.BaseUrl)
                                 {
                                     Path = serviceRequest.ResourceUri.ToString(), 
                                     Query = serviceRequest.GetQueryString()
                                 };

            return new RestRequest(uriBuilder.Uri.PathAndQuery);
        }

        /// <summary>Infrastructure. Implementation details for 'SendAsync'.</summary>
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>The <see cref="IServiceResponse{TResult}"/>.</returns>
        private Task<IServiceResponse<TResult>> SendAsyncImplementation<TResult>(IServiceRequest serviceRequest, CancellationToken cancellationToken)
            where TResult : class
        {
            var request = this.CreateRestRequest(serviceRequest);
            return this.innerRestClient.ExecuteTaskAsync(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;

                        if (response.ResponseStatus != ResponseStatus.Completed)
                        {
                            throw response.ErrorException;
                        }

                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            var serviceResponse = new ErrorResponse(response);
                            throw new ServiceException(serviceResponse.Deserialize(), response.ErrorException);
                        }

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
        /// <param name="serviceRequest">The <see cref="IServiceRequest"/>.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>The <see cref="IServiceResponse{TResult}"/>.</returns>
        private IServiceResponse<TResult> SendImplementation<TResult>(IServiceRequest serviceRequest) where TResult : class
        {
            var request = this.CreateRestRequest(serviceRequest);
            var response = this.innerRestClient.Execute(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw response.ErrorException;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var serviceResponse = new ErrorResponse(response);
                throw new ServiceException(serviceResponse.Deserialize(), response.ErrorException);
            }

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
    }
}