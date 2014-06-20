// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a default implementation for the <see cref="IServiceClient" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Contracts;
    using GW2DotNET.Utilities;

    using Newtonsoft.Json;

    /// <summary>Provides a default implementation for the <see cref="IServiceClient" /> interface.</summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>A collection of the specified type.</returns>
        public TResult Send<TResult>(IRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(1);

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IDynamicEventRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(4);

            // Set the 'world_id' parameter
            if (request.WorldId.HasValue)
            {
                formData["world_id"] = request.WorldId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'map_id' parameter
            if (request.MapId.HasValue)
            {
                formData["map_id"] = request.MapId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'event_id' parameter
            if (request.EventId.HasValue)
            {
                formData["event_id"] = request.EventId.Value.ToString();
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IGuildRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'guild_id' parameter
            if (request.GuildId.HasValue)
            {
                formData["guild_id"] = request.GuildId.Value.ToString();
            }

            // Set the 'guild_name' parameter
            if (request.GuildName != null)
            {
                formData["guild_name"] = request.GuildName;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IItemRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'item_id' parameter
            if (request.ItemId.HasValue)
            {
                formData["item_id"] = request.ItemId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IMapRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'map_id' parameter
            if (request.MapId.HasValue)
            {
                formData["map_id"] = request.MapId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IFloorRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(3);

            // Set the 'continent_id' parameter
            if (request.ContinentId.HasValue)
            {
                formData["continent_id"] = request.ContinentId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'floor' parameter
            if (request.Floor.HasValue)
            {
                formData["floor"] = request.Floor.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IMatchRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(1);

            // Set the 'match_id' parameter
            if (request.MatchId != null)
            {
                formData["match_id"] = request.MatchId;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IRecipeRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'recipe_id' parameter
            if (request.RecipeId.HasValue)
            {
                formData["recipe_id"] = request.RecipeId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(ISkinRequest request)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'skin_id' parameter
            if (request.SkinId.HasValue)
            {
                formData["skin_id"] = request.SkinId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            using (var response = GetHttpWebResponse(httpWebRequest))
            {
                return DeserializeResponse<TResult>(response);
            }
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
            // Translate the request to form data
            var formData = new UrlEncodedForm(1);

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IDynamicEventRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IDynamicEventRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(4);

            // Set the 'world_id' parameter
            if (request.WorldId.HasValue)
            {
                formData["world_id"] = request.WorldId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'map_id' parameter
            if (request.MapId.HasValue)
            {
                formData["map_id"] = request.MapId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'event_id' parameter
            if (request.EventId.HasValue)
            {
                formData["event_id"] = request.EventId.Value.ToString();
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IGuildRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IGuildRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'guild_id' parameter
            if (request.GuildId.HasValue)
            {
                formData["guild_id"] = request.GuildId.Value.ToString();
            }

            // Set the 'guild_name' parameter
            if (request.GuildName != null)
            {
                formData["guild_name"] = request.GuildName;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IItemRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IItemRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'item_id' parameter
            if (request.ItemId.HasValue)
            {
                formData["item_id"] = request.ItemId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IMapRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IMapRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'map_id' parameter
            if (request.MapId.HasValue)
            {
                formData["map_id"] = request.MapId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IFloorRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IFloorRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(3);

            // Set the 'continent_id' parameter
            if (request.ContinentId.HasValue)
            {
                formData["continent_id"] = request.ContinentId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'floor' parameter
            if (request.Floor.HasValue)
            {
                formData["floor"] = request.Floor.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IMatchRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IMatchRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(1);

            // Set the 'match_id' parameter
            if (request.MatchId != null)
            {
                formData["match_id"] = request.MatchId;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IRecipeRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(IRecipeRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'recipe_id' parameter
            if (request.RecipeId.HasValue)
            {
                formData["recipe_id"] = request.RecipeId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(ISkinRequest request)
        {
            return this.SendAsync<TResult>(request, CancellationToken.None);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public Task<TResult> SendAsync<TResult>(ISkinRequest request, CancellationToken cancellationToken)
        {
            // Translate the request to form data
            var formData = new UrlEncodedForm(2);

            // Set the 'skin_id' parameter
            if (request.SkinId.HasValue)
            {
                formData["skin_id"] = request.SkinId.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                formData["lang"] = language;
            }

            // Build the resource URI
            var uri = BuildUri(request.Resource, formData);

            // Handle the request
            var httpWebRequest = CreateHttpWebRequest(uri);
            return GetHttpWebResponseAsync(httpWebRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        using (var response = task.Result)
                        {
                            return DeserializeResponse<TResult>(response);
                        }
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="UriBuilder"/> class.</summary>
        /// <param name="resource">The resource name.</param>
        /// <param name="formData">The form data.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        private static Uri BuildUri(string resource, UrlEncodedForm formData)
        {
            var uriBuilder = new UriBuilder { Scheme = "https", Host = "api.guildwars2.com", Path = resource, Query = formData.GetQueryString() };
            return uriBuilder.Uri;
        }

        /// <summary>Infrastructure. Creates and configures a new instance of the <see cref="HttpWebRequest"/> class.</summary>
        /// <param name="uri">The resource <see cref="Uri"/>.</param>
        /// <returns>The <see cref="HttpWebRequest"/>.</returns>
        private static HttpWebRequest CreateHttpWebRequest(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            return request;
        }

        /// <summary>Infrastructure. Deserializes the response stream.</summary>
        /// <param name="response">The response.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private static TResult DeserializeResponse<TResult>(HttpWebResponse response)
        {
            var stream = response.GetResponseStream() ?? new MemoryStream();

            // Ensure that we are operating on decompressed data
            var contentEncoding = response.Headers[HttpResponseHeader.ContentEncoding];
            if (contentEncoding != null)
            {
                var compressed = contentEncoding.Equals("gzip", StringComparison.OrdinalIgnoreCase);
                if (compressed)
                {
                    stream = new GZipStream(stream, CompressionMode.Decompress);
                }
            }

            // Deserialize the response content
            using (stream)
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = JsonSerializer.CreateDefault();
                return serializer.Deserialize<TResult>(jsonReader);
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static HttpWebResponse GetHttpWebResponse(HttpWebRequest webRequest)
        {
            try
            {
                return (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException exception)
            {
                // Simply rethrow in case of transport errors (e.g. timeout)
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    throw;
                }

                // Wrap the exception in a ServiceException, then throw
                using (var response = exception.Response)
                using (var stream = response.GetResponseStream())
                using (var streamReader = new StreamReader(stream ?? new MemoryStream()))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.CreateDefault();
                    var errorResult = serializer.Deserialize<ErrorResult>(jsonReader);
                    throw new ServiceException(null, errorResult, exception);
                }
            }
        }

        /// <summary>Infrastructure. Sends a web request and gets the response.</summary>
        /// <param name="webRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        /// <exception cref="ServiceException">The exception that is thrown when an API error occurs.</exception>
        private static Task<HttpWebResponse> GetHttpWebResponseAsync(HttpWebRequest webRequest, CancellationToken cancellationToken)
        {
            return Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, null).ContinueWith(
                task =>
                    {
                        if (task.IsFaulted && task.Exception != null)
                        {
                            var exception = task.Exception.GetBaseException() as WebException;

                            // Handle only protocol errors
                            if (exception != null && exception.Status == WebExceptionStatus.ProtocolError)
                            {
                                // Wrap the exception in a ServiceException, then throw
                                using (var response = exception.Response)
                                using (var stream = response.GetResponseStream())
                                using (var streamReader = new StreamReader(stream ?? new MemoryStream()))
                                using (var jsonReader = new JsonTextReader(streamReader))
                                {
                                    var serializer = JsonSerializer.CreateDefault();
                                    var errorResult = serializer.Deserialize<ErrorResult>(jsonReader);
                                    throw new ServiceException(null, errorResult, exception);
                                }
                            }
                        }

                        // unhandled transport errors (if any) are propagated back to the calling thread when accessing task.Result
                        return (HttpWebResponse)task.Result;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Gets the language.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The language if applicable; otherwise null.</returns>
        private static string TryGetLanguage(IRequest request)
        {
            var localizableRequest = request as ILocalizable;
            if (localizableRequest == null || localizableRequest.Culture == null)
            {
                return null;
            }

            return localizableRequest.Culture.TwoLetterISOLanguageName;
        }
    }
}