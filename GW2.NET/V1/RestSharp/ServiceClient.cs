// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.Utilities;
using RestSharp;
using JsonObject = GW2DotNET.V1.Core.JsonObject;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Provides a RestSharp-specific implementation of the <see cref="IServiceClient"/> interface.
    /// </summary>
    public class ServiceClient : RestClient, IServiceClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClient"/> class using the specified base URL and JSON de-serializer.
        /// </summary>
        /// <param name="baseUrl">An absolute URI that represents the base URL for all API endpoints.</param>
        public ServiceClient(Uri baseUrl)
            : base(Preconditions.EnsureNotNull(paramName: "baseUrl", value: baseUrl).ToString())
        {
            if (!baseUrl.IsAbsoluteUri)
            {
                throw new ArgumentException("'baseUrl' cannot be a relative URI.");
            }
        }

        /// <summary>
        /// Factory method. Creates a new instance of the <see cref="ServiceClient"/> class.
        /// </summary>
        /// <returns>Returns an instance of <see cref="ServiceClient"/>.</returns>
        public static IServiceClient Create()
        {
            return new ServiceClient(new Uri(string.Format(Resources.BaseUrl, 1)));
        }

        /// <summary>
        /// Factory method. Creates a new instance of the <see cref="ServiceClient"/> class that targets the specified API version.
        /// </summary>
        /// <param name="apiVersion">The target API version.</param>
        /// <returns>Returns an instance of <see cref="ServiceClient"/>.</returns>
        public static IServiceClient Create(Version apiVersion)
        {
            Preconditions.EnsureNotNull(paramName: "apiVersion", value: apiVersion);

            return new ServiceClient(new Uri(string.Format(Resources.BaseUrl, apiVersion.Major)));
        }

        /// <summary>
        /// Sends an <see cref="ServiceRequest"/> and returns an <see cref="ServiceResponse{TContent}"/> whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public IServiceResponse<TContent> Send<TContent>(IServiceRequest request) where TContent : JsonObject
        {
            Preconditions.EnsureNotNull(paramName: "request", value: request);
            if (!(request is IRestRequest))
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendImplementation<TContent>(request as IRestRequest);
        }

        /// <summary>
        /// Asynchronously sends an <see cref="ServiceRequest"/> and returns an <see cref="ServiceResponse{TContent}"/> whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public Task<IServiceResponse<TContent>> SendAsync<TContent>(IServiceRequest request) where TContent : JsonObject
        {
            Preconditions.EnsureNotNull(paramName: "request", value: request);
            if (!(request is ServiceRequest))
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendAsyncImplementation<TContent>(request as IRestRequest);
        }

        /// <summary>
        /// Asynchronously sends an <see cref="ServiceRequest"/> and returns an <see cref="ServiceResponse{TContent}"/> whose content can be mapped to the specified type.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        public Task<IServiceResponse<TContent>> SendAsync<TContent>(IServiceRequest request, CancellationToken token) where TContent : JsonObject
        {
            Preconditions.EnsureNotNull(paramName: "request", value: request);
            if (!(request is ServiceRequest))
            { /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendAsyncImplementation<TContent>(request as IRestRequest, token);
        }

        /// <summary>
        /// Infrastructure. Implementation details for 'SendAsync'.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        private Task<IServiceResponse<TContent>> SendAsyncImplementation<TContent>(IRestRequest request) where TContent : JsonObject
        {
            return this.ExecuteTaskAsync(request)
                .ContinueWith<IServiceResponse<TContent>>(
                x => new ServiceResponse<TContent>(x.Result));
        }

        /// <summary>
        /// Infrastructure. Implementation details for 'SendAsync'.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <param name="token">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        private Task<IServiceResponse<TContent>> SendAsyncImplementation<TContent>(IRestRequest request, CancellationToken token) where TContent : JsonObject
        {
            return this.ExecuteTaskAsync(request, token)
                .ContinueWith<IServiceResponse<TContent>>(
                x => new ServiceResponse<TContent>(x.Result),
                token);
        }

        /// <summary>
        /// Infrastructure. Implementation details for 'Send'.
        /// </summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="request">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <returns>Returns the response content as an instance of the specified type.</returns>
        private IServiceResponse<TContent> SendImplementation<TContent>(IRestRequest request) where TContent : JsonObject
        {
            return new ServiceResponse<TContent>(this.Execute(request));
        }
    }
}