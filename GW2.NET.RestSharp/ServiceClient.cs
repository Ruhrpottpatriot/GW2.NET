// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a RestSharp-specific implementation of the <see cref="IServiceClient" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.RestSharp
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Contracts;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;

    using global::RestSharp;

    /// <summary>Provides a RestSharp-specific implementation of the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Infrastructure. Holds a reference to the inner <see cref="IRestClient" />.</summary>
        private readonly IRestClient restClient;

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        public ServiceClient(Uri baseUri)
        {
            Preconditions.EnsureNotNull(paramName: "baseUri", value: baseUri);
            Preconditions.Ensure(baseUri.IsAbsoluteUri, "baseUri", "Parameter '{0}' must be an absolute URI.");
            this.restClient = new RestClient(baseUri.ToString());
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IRequest request, ISerializer<TResult> serializer)
        {
            var restRequest = new RestRequest(request.Resource);

            // Translate the request to form data
            foreach (var parameter in request.GetParameters())
            {
                restRequest.AddParameter(parameter.Key, parameter.Value);
            }

            // Handle the request
            var restResponse = GetRestResponse(this.restClient, restRequest);
            return DeserializeResponse(serializer, restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IRequest request, ISerializer<TResult> serializer)
        {
            return this.SendAsync(request, serializer, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="serializer">The serialization engine.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IRequest request, ISerializer<TResult> serializer, CancellationToken cancellationToken)
        {
            var restRequest = new RestRequest(request.Resource);

            // Translate the request to form data
            foreach (var parameter in request.GetParameters())
            {
                restRequest.AddParameter(parameter.Key, parameter.Value);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(this.restClient, restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse(serializer, task.Result), cancellationToken);

            return t2;
        }

        /// <summary>Infrastructure. Deserializes the response stream.</summary>
        /// <param name="serializer">The serialization engine.</param>
        /// <param name="response">The response.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private static TResult DeserializeResponse<TResult>(ISerializer<TResult> serializer, IRestResponse response)
        {
            // Deserialize the response content
            using (var stream = new MemoryStream(response.RawBytes))
            {
                return serializer.Deserialize(stream);
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="restClient">The <see cref="IRestClient"/>.</param>
        /// <param name="request">The <see cref="IRestRequest"/>.</param>
        /// <returns>The <see cref="IRestResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static IRestResponse GetRestResponse(IRestClient restClient, IRestRequest request)
        {
            var response = restClient.Execute(request);

            if (response.StatusCode.IsSuccessStatusCode())
            {
                return response;
            }

            // Simply rethrow in case of transport errors (e.g. timeout)
            if (response.ResponseStatus == ResponseStatus.Error)
            {
                throw response.ErrorException;
            }

            // Wrap protocol exceptions in a ServiceException, then throw
            using (var stream = new MemoryStream(response.RawBytes))
            {
                var errorResult = new JsonSerializer<ErrorResult>().Deserialize(stream);
                throw new ServiceException(null, errorResult);
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="restClient">The <see cref="IRestClient"/>.</param>
        /// <param name="request">The <see cref="IRestRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="IRestResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static Task<IRestResponse> GetRestResponseAsync(IRestClient restClient, IRestRequest request, CancellationToken cancellationToken)
        {
            return restClient.ExecuteTaskAsync(request, cancellationToken).ContinueWith(
                task =>
                {
                    var response = task.Result;

                    if (response.StatusCode.IsSuccessStatusCode())
                    {
                        return response;
                    }

                    // Simply rethrow in case of transport errors (e.g. timeout)
                    if (response.ResponseStatus == ResponseStatus.Error)
                    {
                        throw response.ErrorException;
                    }

                    // Wrap protocol exceptions in a ServiceException, then throw
                    using (var stream = new MemoryStream(response.RawBytes))
                    {
                        var errorResult = new JsonSerializer<ErrorResult>().Deserialize(stream);
                        throw new ServiceException(null, errorResult);
                    }
                },
                cancellationToken);
        }
    }
}