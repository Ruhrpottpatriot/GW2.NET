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
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Contracts;
    using GW2DotNET.Extensions;
    using GW2DotNET.V1.Common;

    using Newtonsoft.Json;

    using global::RestSharp;

    /// <summary>Provides a RestSharp-specific implementation of the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Infrastructure. Stores the inner <see cref="IRestClient" />.</summary>
        private static readonly IRestClient RestClient;

        /// <summary>Initializes static members of the <see cref="ServiceClient"/> class.</summary>
        static ServiceClient()
        {
            RestClient = new RestClient("https://api.guildwars2.com");
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Translate the request to form data
            foreach (var parameter in request.GetParameters())
            {
                restRequest.AddParameter(parameter.Key, parameter.Value);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IRequest request, CancellationToken cancellationToken)
        {
            var restRequest = new RestRequest(request.Resource);

            // Translate the request to form data
            foreach (var parameter in request.GetParameters())
            {
                restRequest.AddParameter(parameter.Key, parameter.Value);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
        }

        /// <summary>Infrastructure. Deserializes the response stream.</summary>
        /// <param name="response">The response.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private static TResult DeserializeResponse<TResult>(IRestResponse response)
        {
            // Deserialize the response content
            using (var stream = new MemoryStream(response.RawBytes))
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return JsonSerializer.CreateDefault().Deserialize<TResult>(jsonReader);
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="request">The <see cref="IRestRequest"/>.</param>
        /// <returns>The <see cref="IRestResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static IRestResponse GetRestResponse(IRestRequest request)
        {
            var response = RestClient.Execute(request);

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
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var errorResult = JsonSerializer.CreateDefault().Deserialize<ErrorResult>(jsonReader);
                throw new ServiceException(null, errorResult);
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="request">The <see cref="IRestRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="IRestResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static Task<IRestResponse> GetRestResponseAsync(IRestRequest request, CancellationToken cancellationToken)
        {
            return RestClient.ExecuteTaskAsync(request, cancellationToken).ContinueWith(
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
                        using (var streamReader = new StreamReader(stream))
                        using (var jsonReader = new JsonTextReader(streamReader))
                        {
                            var errorResult = JsonSerializer.CreateDefault().Deserialize<ErrorResult>(jsonReader);
                            throw new ServiceException(null, errorResult);
                        }
                    }, 
                cancellationToken);
        }
    }
}