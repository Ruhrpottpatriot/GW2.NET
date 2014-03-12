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
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.Utilities;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using RestSharp.GW2DotNET.Requests;

    /// <summary>
    ///     Provides a RestSharp-specific implementation of the <see cref="IServiceClient" /> interface.
    /// </summary>
    public class ServiceClient : RestClient, IServiceClient
    {
        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class using the specified base URL and JSON
        ///     de-serializer.</summary>
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
        ///     Factory method. Creates a new instance of the <see cref="ServiceClient" /> class.
        /// </summary>
        /// <returns>A new instance of the <see cref="ServiceClient" /> class.</returns>
        public static IServiceClient Create()
        {
            return new ServiceClient(new Uri(Services.DataServiceUrl));
        }

        /// <summary>Sends an <see cref="ServiceRequest"/> and returns an <see cref="ServiceResponse{TContent}"/> whose content can be
        ///     mapped to the specified type.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<TContent> Send<TContent>(IServiceRequest serviceRequest) where TContent : global::GW2DotNET.V1.Core.JsonObject
        {
            Preconditions.EnsureNotNull(paramName: "serviceRequest", value: serviceRequest);
            if (!(serviceRequest is IRestRequest))
            {
                /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendImplementation<TContent>(serviceRequest as IRestRequest);
        }

        /// <summary>Asynchronously sends an <see cref="ServiceRequest"/> and returns an <see cref="ServiceResponse{TContent}"/> whose
        ///     content can be mapped to the specified type.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<TContent>> SendAsync<TContent>(IServiceRequest serviceRequest) where TContent : global::GW2DotNET.V1.Core.JsonObject
        {
            return this.SendAsync<TContent>(serviceRequest, CancellationToken.None);
        }

        /// <summary>Asynchronously sends an <see cref="ServiceRequest"/> and returns an <see cref="ServiceResponse{TContent}"/> whose
        ///     content can be mapped to the specified type.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="serviceRequest">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<TContent>> SendAsync<TContent>(IServiceRequest serviceRequest, CancellationToken cancellationToken)
            where TContent : global::GW2DotNET.V1.Core.JsonObject
        {
            Preconditions.EnsureNotNull(paramName: "serviceRequest", value: serviceRequest);
            if (!(serviceRequest is ServiceRequest))
            {
                /* The specified request is of an incompatible type */
                throw new NotSupportedException("Incompatible request type");
            }

            return this.SendAsyncImplementation<TContent>(serviceRequest as IRestRequest, cancellationToken);
        }

        /// <summary>Infrastructure. Implementation details for 'SendAsync'.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="restRequest">The <see cref="ServiceRequest"/> that targets a specific API endpoint.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        private Task<IServiceResponse<TContent>> SendAsyncImplementation<TContent>(IRestRequest restRequest, CancellationToken cancellationToken)
            where TContent : global::GW2DotNET.V1.Core.JsonObject
        {
            Task<IRestResponse> t1 = this.ExecuteTaskAsync(restRequest, cancellationToken);

            Task<IServiceResponse<TContent>> t2 = t1.ContinueWith<IServiceResponse<TContent>>(
                task => new ServiceResponse<TContent>(task.Result), 
                cancellationToken, 
                TaskContinuationOptions.OnlyOnRanToCompletion, 
                TaskScheduler.Current);

            return t2;
        }

        /// <summary>Infrastructure. Implementation details for 'Send'.</summary>
        /// <typeparam name="TContent">The type of the response content.</typeparam>
        /// <param name="restRequest">The request</param>
        /// <returns>The response.</returns>
        private IServiceResponse<TContent> SendImplementation<TContent>(IRestRequest restRequest) where TContent : global::GW2DotNET.V1.Core.JsonObject
        {
            IRestResponse restResponse = this.Execute(restRequest);

            return new ServiceResponse<TContent>(restResponse);
        }
    }
}