// --------------------------------------------------------------------------------------------------------------------
// <copyright file="APICall.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ApiCall type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.Events.Models;

using Newtonsoft.Json;

using RestSharp;

namespace GW2DotNET.Infrastructure
{
    /// <summary>Contains static methods to call the guild wars 2 API.</summary>
    public static class ApiCall
    {
        /// <summary>
        /// Calls the API with the specified method and parameters.
        /// </summary>
        /// <param name="apiMethod">
        /// The method to execute on the API.
        /// </param>
        /// <param name="arguments">
        /// The arguments to add to the method.
        /// </param>
        /// <returns>
        /// A JSON encoded <see cref="string"/> containing the API response.
        /// </returns>
        public static string CallApi(string apiMethod, List<KeyValuePair<string, object>> arguments)
        {
            var client = new RestClient("https://api.guildwars2.com/v1/");

            var restRequest = new RestRequest(apiMethod, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            if (arguments != null)
            {
                foreach (var keyValuePair in arguments)
                {
                    restRequest.AddParameter(keyValuePair.Key, keyValuePair.Value);
                }
            }

            IRestResponse response = client.Execute(restRequest);

            return response.Content;
        }

        /// <summary>
        /// Calls the API with the specified method and parameters and deserializes the response with the type passed to the method.
        /// </summary>
        /// <param name="apiMethod">
        /// The API method to call.
        /// </param>
        /// <param name="arguments">
        /// The arguments that are passed as additional parameters to the method.
        /// </param>
        /// <typeparam name="T">
        /// The type to deserialize into.
        /// </typeparam>
        /// <returns>
        /// A deserialized object as an <see cref="IRestResponse"/>.
        /// </returns>
        public static IRestResponse<T> CallApi<T>(string apiMethod, List<KeyValuePair<string, object>> arguments) where T : new()
        {
            var client = new RestClient("https://api.guildwars2.com/v1/");

            var restRequest = new RestRequest(apiMethod, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            if (arguments != null)
            {
                foreach (var keyValuePair in arguments)
                {
                    restRequest.AddParameter(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return client.Execute<T>(restRequest);
        }

        public static T CallApiNew<T>(string apiMethod, List<KeyValuePair<string, object>> arguments) where T : new()
        {
            var client = new RestClient("https://api.guildwars2.com/v1/");

            var restRequest = new RestRequest(apiMethod, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            if (arguments != null)
            {
                foreach (var keyValuePair in arguments)
                {
                    restRequest.AddParameter(keyValuePair.Key, keyValuePair.Value);
                }
            }

            var requestResponse = client.Execute(restRequest).Content;

            return JsonConvert.DeserializeObject<T>(requestResponse);
        }


        /// <summary>
        /// Calls the world-vs-world API with the specified method and parameters.
        /// </summary>
        /// <param name="apiMethod">
        /// The method to execute on the API.
        /// </param>
        /// <param name="arguments">
        /// The arguments to add to the method.
        /// </param>
        /// <returns>
        /// A JSON encoded <see cref="string"/> containing the API response.
        /// </returns>
        public static string CallWvWApi(string apiMethod, List<KeyValuePair<string, object>> arguments)
        {
            var client = new RestClient("https://api.guildwars2.com/v1/wvw");

            var restRequest = new RestRequest(apiMethod, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            if (arguments != null)
            {
                foreach (var keyValuePair in arguments)
                {
                    restRequest.AddParameter(keyValuePair.Key, keyValuePair.Value);
                }
            }

            IRestResponse response = client.Execute(restRequest);

            return response.Content;
        }
    }
}