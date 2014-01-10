// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiClient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using RestSharp;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides a RestSharp-specific implementation of the IApiClient interface.
    /// </summary>
    public class ApiClient : IApiClient
    {
        /// <summary>
        /// Infrastructure. Stores the inner <see cref="IRestClient"/>.
        /// </summary>
        protected readonly IRestClient InnerClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class using the specified base URL.
        /// </summary>
        /// <param name="baseUrl">An absolute URI that represents the base URL for all API endpoints.</param>
        public ApiClient(Uri baseUrl)
        {
            if (baseUrl == null)
            {
                throw new ArgumentNullException("baseUrl");
            }

            if (!baseUrl.IsAbsoluteUri)
            {
                throw new ArgumentException("'baseUrl' cannot be a relative URI.");
            }

            this.InnerClient = new RestClient(baseUrl.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class using the specified <see cref="IRestClient"/>.
        /// </summary>
        /// <param name="innerClient">The inner client object.</param>
        internal ApiClient(IRestClient innerClient)
        {
            if (innerClient == null)
            {
                throw new ArgumentNullException("innerClient");
            }

            this.InnerClient = innerClient;
        }

        /// <summary>
        /// Factory method. Creates a new instance of the <see cref="ApiClient"/> class that targets the specified API version.
        /// </summary>
        /// <param name="apiVersion">The target API version.</param>
        /// <returns>Returns an instance of <see cref="ApiClient"/>.</returns>
        public static IApiClient Create(Version apiVersion)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException("apiVersion");
            }

            return new ApiClient(new Uri(string.Format("https://api.guildwars2.com/v{0}/", apiVersion.Major)));
        }

        /// <summary>
        /// Sends an <see cref="ApiRequest"/> and returns an <see cref="ApiResponse{TContent}"/> whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public IApiResponse<TResponse> Send<TResponse>(IApiRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (!(request is ApiRequest))
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendImplementation<TResponse>(request as ApiRequest);
        }

        /// <summary>
        /// Asynchronously sends an <see cref="ApiRequest"/> and returns an <see cref="ApiResponse{TContent}"/> whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public Task<IApiResponse<TResponse>> SendAsync<TResponse>(IApiRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (!(request is ApiRequest))
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendAsyncImplementation<TResponse>(request as ApiRequest);
        }

        /// <summary>
        /// Infrastructure. Implementation details for 'Send'.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        private IApiResponse<TResponse> SendImplementation<TResponse>(ApiRequest request)
        {
            IRestResponse response = this.InnerClient.Execute(request.InnerRequest);
            return new ApiResponse<TResponse>(response);
        }

        /// <summary>
        /// Infrastructure. Implementation details for 'SendAsync'.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        private Task<IApiResponse<TResponse>> SendAsyncImplementation<TResponse>(ApiRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            this.InnerClient.ExecuteAsync(
                request.InnerRequest,
                response =>
                {
                    try
                    {
                        tcs.SetResult(response);
                    }
                    catch (Exception exception)
                    {
                        tcs.SetException(exception);
                    }
                });
            return tcs.Task.ContinueWith<IApiResponse<TResponse>>(response =>
            {
                return new ApiResponse<TResponse>(response.Result);
            });
        }
    }
}
