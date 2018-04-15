// <copyright file="ServiceClient.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;
    using Serializers;

    /// <summary>Provides a default implementation for the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Initializes a new instance of the <see cref="ServiceClient"/> class.</summary>
        /// <param name="logger">The logger</param>
        /// <param name="httpClient">The <see cref="HttpClient"/> used to make requests.</param>
        /// <param name="serializerFactory">The response serializer</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="httpClient"/> or <paramref name="serializerFactory"/> or <paramref name="logger"/> is a null reference.</exception>
        public ServiceClient(ILogger<ServiceClient> logger, HttpClient httpClient, ISerializerFactory serializerFactory)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.SerializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        public ILogger<ServiceClient> Logger { get; }

        public ISerializerFactory SerializerFactory { get; }

        public HttpClient HttpClient { get; }

        /// <inheritdoc />
        public Task<IApiData<TResult>> SendAsync<TResult>(HttpRequestMessage request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<IApiData<TResult>> SendAsync<TResult>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            this.Logger.LogInformation("Fetching data from the GW2 web api");
            var response = await this.HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            using (response)
            {
                try
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        this.OnError(response, this.SerializerFactory.GetSerializer<ErrorResult>());
                    }
                    else
                    {
                        return await this.OnSuccessAsync(response, this.SerializerFactory.GetSerializer<TResult>());
                    }
                }
                catch (ServiceException ex)
                {
                    ex.Request = request;
                    throw;
                }
            }

            throw new ServiceException("Unknown error");
        }

        /// <summary>Throws an exception for error responses.</summary>
        /// <param name="response">The error response.</param>
        /// <param name="serializer">The serialization engine for the response.</param>
        /// <exception cref="ServiceException">The exception that represents the error.</exception>
        private void OnError(HttpResponseMessage response, ISerializer<ErrorResult> serializer)
        {
            Debug.Assert(response != null, "response != null");
            Debug.Assert(serializer != null, "serializer != null");

            if (response == null)
            {
                throw new ServiceException("Unknown error");
            }

            if (!response.Content.Headers.ContentType.MediaType.Equals("application/json", StringComparison.OrdinalIgnoreCase))
            {
                throw new ServiceException(response.ReasonPhrase);
            }

            var errorResult = this.DeserializeResponseAsync(response.Content, serializer);
            if (errorResult == null)
            {
                throw new ServiceException("An error occoured but the error message was unavailable.");
            }

            throw new ServiceException(errorResult.Result.Text);
        }

        /// <summary>Creates a response object for success responses.</summary>
        /// <param name="response">The success response.</param>
        /// <param name="serializer">The serialization engine for the response.</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>The object that represents the response.</returns>
        private async Task<IApiData<T>> OnSuccessAsync<T>(HttpResponseMessage response, ISerializer<T> serializer)
        {
            Debug.Assert(response != null, "response != null");
            Debug.Assert(serializer != null, "serializer != null");

            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var value = new ApiData<T>();
            value.Content = await this.DeserializeResponseAsync(response.Content, serializer).ConfigureAwait(false);

            var date = response.Headers.Date;
            if (date != null)
            {
                value.Date = date.Value;
            }

            var language = response.Content.Headers.ContentLanguage.FirstOrDefault();
            value.Culture = language == null
                ? CultureInfo.InvariantCulture
                : new CultureInfo(language);

            // Set the 'X'-tension headers
            // ToDo: This seems odd. Look over it again
            foreach (var header in response.Headers)
            {
                if (string.IsNullOrEmpty(header.Key))
                {
                    continue;
                }

                if (header.Key.StartsWith("X-", StringComparison.Ordinal))
                {
                    value.ExtensionData[header.Key] = header.Value.FirstOrDefault();
                }
            }

            // Return the response object
            return value;
        }

        /// <summary>Deserializes the response stream.</summary>
        /// <param name="response">The response.</param>
        /// <param name="serializer">The deserializer</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private async Task<T> DeserializeResponseAsync<T>(HttpContent response, ISerializer<T> serializer)
        {
            if (response == null)
            {
                return default;
            }

            var contentStream = await response.ReadAsStreamAsync();
            if (contentStream == null)
            {
                return default;
            }

            return serializer.Deserialize(contentStream);
        }
    }
}