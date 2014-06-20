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
    using System.Globalization;
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

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IDynamicEventRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Set the 'world_id' parameter
            if (request.WorldId.HasValue)
            {
                restRequest.AddParameter("world_id", request.WorldId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'map_id' parameter
            if (request.MapId.HasValue)
            {
                restRequest.AddParameter("map_id", request.MapId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'event_id' parameter
            if (request.EventId.HasValue)
            {
                restRequest.AddParameter("event_id", request.EventId.Value.ToString());
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IGuildRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Set the 'guild_id' parameter
            if (request.GuildId.HasValue)
            {
                restRequest.AddParameter("guild_id", request.GuildId.Value.ToString());
            }

            // Set the 'guild_name' parameter
            if (request.GuildName != null)
            {
                restRequest.AddParameter("guild_name", request.GuildName);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IItemRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Set the 'item_id' parameter
            if (request.ItemId.HasValue)
            {
                restRequest.AddParameter("item_id", request.ItemId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IMapRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Set the 'map_id' parameter
            if (request.MapId.HasValue)
            {
                restRequest.AddParameter("map_id", request.MapId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IFloorRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Set the 'continent_id' parameter
            if (request.ContinentId.HasValue)
            {
                restRequest.AddParameter("continent_id", request.ContinentId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'floor' parameter
            if (request.Floor.HasValue)
            {
                restRequest.AddParameter("floor", request.Floor.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IMatchRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Set the 'match_id' parameter
            if (request.MatchId != null)
            {
                restRequest.AddParameter("match_id", request.MatchId);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(IRecipeRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Set the 'recipe_id' parameter
            if (request.RecipeId.HasValue)
            {
                restRequest.AddParameter("recipe_id", request.RecipeId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var restResponse = GetRestResponse(restRequest);
            return DeserializeResponse<TResult>(restResponse);
        }

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <typeparam name="TResult">The type of the response content.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public TResult Send<TResult>(ISkinRequest request)
        {
            var restRequest = new RestRequest(request.Resource);

            // Set the 'skin_id' parameter
            if (request.SkinId.HasValue)
            {
                restRequest.AddParameter("skin_id", request.SkinId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
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

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
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
            var restRequest = new RestRequest(request.Resource);

            // Set the 'world_id' parameter
            if (request.WorldId.HasValue)
            {
                restRequest.AddParameter("world_id", request.WorldId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'map_id' parameter
            if (request.MapId.HasValue)
            {
                restRequest.AddParameter("map_id", request.MapId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'event_id' parameter
            if (request.EventId.HasValue)
            {
                restRequest.AddParameter("event_id", request.EventId.Value.ToString());
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
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
            var restRequest = new RestRequest(request.Resource);

            // Set the 'guild_id' parameter
            if (request.GuildId.HasValue)
            {
                restRequest.AddParameter("guild_id", request.GuildId.Value.ToString());
            }

            // Set the 'guild_name' parameter
            if (request.GuildName != null)
            {
                restRequest.AddParameter("guild_name", request.GuildName);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
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
            var restRequest = new RestRequest(request.Resource);

            // Set the 'item_id' parameter
            if (request.ItemId.HasValue)
            {
                restRequest.AddParameter("item_id", request.ItemId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
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
            var restRequest = new RestRequest(request.Resource);

            // Set the 'map_id' parameter
            if (request.MapId.HasValue)
            {
                restRequest.AddParameter("map_id", request.MapId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
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
            var restRequest = new RestRequest(request.Resource);

            // Set the 'continent_id' parameter
            if (request.ContinentId.HasValue)
            {
                restRequest.AddParameter("continent_id", request.ContinentId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'floor' parameter
            if (request.Floor.HasValue)
            {
                restRequest.AddParameter("floor", request.Floor.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
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
            var restRequest = new RestRequest(request.Resource);

            // Set the 'match_id' parameter
            if (request.MatchId != null)
            {
                restRequest.AddParameter("match_id", request.MatchId);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
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
            var restRequest = new RestRequest(request.Resource);

            // Set the 'recipe_id' parameter
            if (request.RecipeId.HasValue)
            {
                restRequest.AddParameter("recipe_id", request.RecipeId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
            }

            // Handle the request
            var t1 = GetRestResponseAsync(restRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => DeserializeResponse<TResult>(task.Result), cancellationToken);

            return t2;
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
            var restRequest = new RestRequest(request.Resource);

            // Set the 'skin_id' parameter
            if (request.SkinId.HasValue)
            {
                restRequest.AddParameter("skin_id", request.SkinId.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            // Set the 'lang' parameter
            var language = TryGetLanguage(request);
            if (language != null)
            {
                restRequest.AddParameter("lang", language);
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
                var serializer = JsonSerializer.CreateDefault();
                return serializer.Deserialize<TResult>(jsonReader);
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
                var serializer = JsonSerializer.CreateDefault();
                var errorResult = serializer.Deserialize<ErrorResult>(jsonReader);
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
                            var serializer = JsonSerializer.CreateDefault();
                            var errorResult = serializer.Deserialize<ErrorResult>(jsonReader);
                            throw new ServiceException(null, errorResult);
                        }
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