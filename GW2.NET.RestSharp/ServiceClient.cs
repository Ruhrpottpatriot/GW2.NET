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
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;

    using global::RestSharp;

    /// <summary>Provides a RestSharp-specific implementation of the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Infrastructure. Holds a reference to a serializer factory.</summary>
        private readonly ISerializerFactory errorSerializerFactory;

        /// <summary>Infrastructure. Holds a reference to the inner <see cref="IRestClient" />.</summary>
        private readonly IRestClient restClient;

        /// <summary>Infrastructure. Holds a reference to a serializer factory.</summary>
        private readonly ISerializerFactory successSerializerFactory;

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="successSerializerFactory">The serializer factory.</param>
        /// <param name="errorSerializerFactory">The error Serializer Factory.</param>
        public ServiceClient(Uri baseUri, ISerializerFactory successSerializerFactory, ISerializerFactory errorSerializerFactory)
        {
            Contract.Requires(baseUri != null);
            Contract.Requires(baseUri.IsAbsoluteUri, "Parameter 'baseUri' must be an absolute URI.");
            Contract.Requires(successSerializerFactory != null);
            Contract.Requires(errorSerializerFactory != null);
            this.restClient = new RestClient(baseUri.ToString());
            this.successSerializerFactory = successSerializerFactory;
            this.errorSerializerFactory = errorSerializerFactory;
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="restClient">The <see cref="IRestClient"/>.</param>
        /// <param name="successSerializerFactory">The serializer factory.</param>
        /// <param name="errorSerializerFactory">The error Serializer Factory.</param>
        public ServiceClient(IRestClient restClient, ISerializerFactory successSerializerFactory, ISerializerFactory errorSerializerFactory)
        {
            Contract.Requires(restClient != null);
            Contract.Requires(successSerializerFactory != null);
            Contract.Requires(errorSerializerFactory != null);
            this.restClient = restClient;
            this.successSerializerFactory = successSerializerFactory;
            this.errorSerializerFactory = errorSerializerFactory;
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public IResponse<TResult> Send<TResult>(IRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Translate the request to form data
            foreach (var parameter in request.GetParameters())
            {
                restRequest.AddParameter(parameter.Key, parameter.Value);
            }

            // Handle the request
            var restResponse = GetRestResponse(this.restClient, restRequest);
            if (!restResponse.StatusCode.IsSuccessStatusCode())
            {
                OnError(restResponse, this.errorSerializerFactory);
            }

            return OnSuccess<TResult>(restResponse, this.successSerializerFactory);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, CancellationToken cancellationToken)
        {
            var restRequest = new RestRequest(request.Resource);

            // Translate the request to form data
            foreach (var parameter in request.GetParameters())
            {
                restRequest.AddParameter(parameter.Key, parameter.Value);
            }

            // Handle the request
            return GetRestResponseAsync(this.restClient, restRequest, cancellationToken).ContinueWith<IResponse<TResult>>(
                task =>
                    {
                        var restResponse = task.Result;
                        if (!restResponse.StatusCode.IsSuccessStatusCode())
                        {
                            OnError(restResponse, this.errorSerializerFactory);
                        }

                        return OnSuccess<TResult>(restResponse, this.successSerializerFactory);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Deserializes the response stream.</summary>
        /// <param name="response">The response.</param>
        /// <param name="serializerFactory">The serializer factory.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private static TResult DeserializeResponse<TResult>(IRestResponse response, ISerializerFactory serializerFactory)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);

            // Ensure that there is response content
            if (response.RawBytes == null)
            {
                return default(TResult);
            }

            // Get the response content
            var stream = new MemoryStream(response.RawBytes);

            // Create a serializer
            var serializer = serializerFactory.GetSerializer<TResult>();

            // Deserialize the response content
            return serializer.Deserialize(stream);
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="restClient">The <see cref="IRestClient"/>.</param>
        /// <param name="request">The <see cref="IRestRequest"/>.</param>
        /// <returns>The <see cref="IRestResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static IRestResponse GetRestResponse(IRestClient restClient, IRestRequest request)
        {
            Contract.Requires(restClient != null);
            Contract.Requires(request != null);
            Contract.Ensures(Contract.Result<IRestResponse>() != null);

            // Get the response
            var response = restClient.Execute(request);

            Contract.Assume(response != null);

            // Return the response
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return response;
            }

            // Rethrow transport errors
            throw response.ErrorException;
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="restClient">The <see cref="IRestClient"/>.</param>
        /// <param name="request">The <see cref="IRestRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="IRestResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static Task<IRestResponse> GetRestResponseAsync(IRestClient restClient, IRestRequest request, CancellationToken cancellationToken)
        {
            Contract.Requires(restClient != null);
            var t1 = restClient.ExecuteTaskAsync(request, cancellationToken);
            Contract.Assume(t1 != null);
            return t1.ContinueWith(
                task =>
                    {
                        // Get the response
                        var response = task.Result;

                        // Return the response
                        if (response.ResponseStatus == ResponseStatus.Completed)
                        {
                            return response;
                        }

                        // Rethrow transport errors
                        throw response.ErrorException;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Post-processes a response object.</summary>
        /// <param name="response">The raw response.</param>
        /// <param name="serializerFactory">The serializer factory.</param>
        private static void OnError(IRestResponse response, ISerializerFactory serializerFactory)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);

            // Get the response content
            var errorResult = DeserializeResponse<ErrorResult>(response, serializerFactory);

            // Get the error description, or null if none was returned
            var errorMessage = errorResult != null ? errorResult.Text : null;

            // Throw an exception
            throw new ServiceException(errorMessage);
        }

        /// <summary>Infrastructure. Post-processes a response object.</summary>
        /// <param name="response">The raw response.</param>
        /// <param name="serializerFactory">The serializer factory.</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>A processed response object.</returns>
        private static IResponse<T> OnSuccess<T>(IRestResponse response, ISerializerFactory serializerFactory)
        {
            Contract.Requires(response != null);
            Contract.Requires(serializerFactory != null);
            Contract.Ensures(Contract.Result<IResponse<T>>() != null);
            Contract.Ensures(Contract.Result<IResponse<T>>().ExtensionData != null);

            // Create a new generic response object
            var value = new Response<T>();

            // Set the deserialized response content
            value.Content = DeserializeResponse<T>(response, serializerFactory);

            Contract.Assume(response.Headers != null && Contract.ForAll(response.Headers, parameter => parameter != null));

            // Set the 'Date' header
            var date = response.Headers.SingleOrDefault(parameter => parameter.Name.Equals("Date", StringComparison.Ordinal));
            if (date != null)
            {
                value.Date = DateTimeOffset.Parse((string)date.Value);
            }

            // Set the 'Content-Language' header
            var culture = response.Headers.SingleOrDefault(parameter => parameter.Name.Equals("Content-Language", StringComparison.Ordinal));
            if (culture != null && culture.Value != null)
            {
                value.Culture = CultureInfo.GetCultureInfo((string)culture.Value);
            }

            // Set the 'X'-tension headers
            foreach (var parameter in response.Headers.Where(parameter => parameter.Name.StartsWith("X-", StringComparison.Ordinal)))
            {
                Contract.Assume(parameter != null);
                value.ExtensionData[parameter.Name] = (string)parameter.Value;
            }

            // Return the response object
            return value;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.restClient != null);
            Contract.Invariant(this.successSerializerFactory != null);
            Contract.Invariant(this.errorSerializerFactory != null);
        }
    }
}