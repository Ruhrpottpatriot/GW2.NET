// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiClient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core.Converters;
using RestSharp;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides a RestSharp-specific implementation of the <see cref="IApiClient"/> interface.
    /// </summary>
    public class ApiClient : RestClient, IApiClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class using the specified base URL.
        /// </summary>
        /// <param name="baseUrl">An absolute URI that represents the base URL for all API endpoints.</param>
        public ApiClient(Uri baseUrl)
            : base(Preconditions.EnsureNotNull(paramName: "baseUrl", value: baseUrl).ToString())
        {
            if (!baseUrl.IsAbsoluteUri)
            {
                throw new ArgumentException("'baseUrl' cannot be a relative URI.");
            }

            this.AddHandler("application/json", new JsonDeserializer());
        }

        /// <summary>
        /// Factory method. Creates a new instance of the <see cref="ApiClient"/> class that targets the specified API version.
        /// </summary>
        /// <param name="apiVersion">The target API version.</param>
        /// <returns>Returns an instance of <see cref="ApiClient"/>.</returns>
        public static IApiClient Create(Version apiVersion)
        {
            Preconditions.EnsureNotNull(paramName: "apiVersion", value: apiVersion);

            return new ApiClient(new Uri(string.Format("https://api.guildwars2.com/v{0}/", apiVersion.Major)));
        }

        /// <summary>
        /// Sends an <see cref="ApiRequest"/> and returns an <see cref="ApiResponse{TContent}"/> whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public IApiResponse<TContent> Send<TContent>(IApiRequest request) where TContent : new()
        {
            Preconditions.EnsureNotNull(paramName: "request", value: request);
            if (!(request is IRestRequest))
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendImplementation<TContent>(request as IRestRequest);
        }

        /// <summary>
        /// Asynchronously sends an <see cref="ApiRequest"/> and returns an <see cref="ApiResponse{TContent}"/> whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public Task<IApiResponse<TContent>> SendAsync<TContent>(IApiRequest request) where TContent : new()
        {
            Preconditions.EnsureNotNull(paramName: "request", value: request);
            if (!(request is ApiRequest))
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendAsyncImplementation<TContent>(request as IRestRequest);
        }

        /// <summary>
        /// Executes the specified request and deserializes the response content.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            return new ApiResponse<T>(base.Execute<T>(request));
        }

        /// <summary>
        /// Executes the specified request asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response.</returns>
        public override Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
        {
            return base.ExecuteTaskAsync(request)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<dynamic>((IRestResponse<dynamic>)x.Result) as IRestResponse;
                });
        }

        /// <summary>
        /// Executes the specified request asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response.</returns>
        public override Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token)
        {
            return base.ExecuteTaskAsync(request, token)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<dynamic>((IRestResponse<dynamic>)x.Result) as IRestResponse;
                },
                token);
        }

        /// <summary>
        /// Executes the specified request asynchronously and deserializes the response content.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public override Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
        {
            return base.ExecuteTaskAsync<T>(request)
                .ContinueWith<IRestResponse<T>>(
                x =>
                {
                    return new ApiResponse<T>(x.Result);
                });
        }

        /// <summary>
        /// Executes the specified request asynchronously and deserializes the response content.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public override Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken token)
        {
            return base.ExecuteTaskAsync<T>(request, token)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<T>(x.Result) as IRestResponse<T>;
                },
                token);
        }

        /// <summary>
        /// Executes the specified GET-style request asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public override Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request)
        {
            return base.ExecuteGetTaskAsync(request)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<dynamic>((IRestResponse<dynamic>)x.Result) as IRestResponse;
                });
        }

        /// <summary>
        /// Executes the specified GET-style request asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response.</returns>
        public override Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request, CancellationToken token)
        {
            return base.ExecuteGetTaskAsync(request, token)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<dynamic>((IRestResponse<dynamic>)x.Result) as IRestResponse;
                },
                token);
        }

        /// <summary>
        /// Executes the specified GET-style request asynchronously and deserializes the response content.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public override Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request)
        {
            return base.ExecuteGetTaskAsync<T>(request)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<T>(x.Result) as IRestResponse<T>;
                });
        }

        /// <summary>
        /// Executes the specified GET-style request asynchronously and deserializes the response content.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public override Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request, CancellationToken token)
        {
            return base.ExecuteGetTaskAsync<T>(request, token)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<T>(x.Result) as IRestResponse<T>;
                },
                token);
        }

        /// <summary>
        /// Executes the specified POST-style request asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response.</returns>
        public override Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request)
        {
            return base.ExecutePostTaskAsync(request)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<dynamic>((IRestResponse<dynamic>)x.Result) as IRestResponse;
                });
        }

        /// <summary>
        /// Executes the specified POST-style request asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response.</returns>
        public override Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request, CancellationToken token)
        {
            return base.ExecutePostTaskAsync(request, token)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<dynamic>((IRestResponse<dynamic>)x.Result) as IRestResponse;
                },
                token);
        }

        /// <summary>
        /// Executes the specified POST-style request asynchronously and deserializes the response content.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public override Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request)
        {
            return base.ExecutePostTaskAsync<T>(request)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<T>(x.Result) as IRestResponse<T>;
                });
        }

        /// <summary>
        /// Executes the specified POST-style request asynchronously and deserializes the response content.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="IRestRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public override Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request, CancellationToken token)
        {
            return base.ExecutePostTaskAsync<T>(request, token)
                .ContinueWith(
                x =>
                {
                    return new ApiResponse<T>(x.Result) as IRestResponse<T>;
                },
                token);
        }

        /// <summary>
        /// Infrastructure. Implementation details for 'Send'.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        private IApiResponse<TContent> SendImplementation<TContent>(IRestRequest request) where TContent : new()
        {
            return this.Execute<TContent>(request) as IApiResponse<TContent>;
        }

        /// <summary>
        /// Infrastructure. Implementation details for 'SendAsync'.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        private Task<IApiResponse<TContent>> SendAsyncImplementation<TContent>(IRestRequest request) where TContent : new()
        {
            return this.ExecuteTaskAsync<TContent>(request)
                .ContinueWith(x => x as IApiResponse<TContent>);
        }

        /// <summary>
        /// Infrastructure. Implementation details for 'SendAsync'.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ApiRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        private Task<IApiResponse<TContent>> SendAsyncImplementation<TContent>(IRestRequest request, CancellationToken token) where TContent : new()
        {
            return this.ExecuteTaskAsync<TContent>(request, token)
                .ContinueWith(x => x as IApiResponse<TContent>);
        }
    }
}