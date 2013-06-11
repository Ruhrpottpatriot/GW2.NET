// --------------------------------------------------------------------------------------------------------------------
// <copyright file="APICall.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ApiCall type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using RestSharp;

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>Contains static methods to call the guild wars 2 API.</summary>
    public static partial class ApiCall
    {
        /// <summary>
        /// The build number of the game.
        /// </summary>
        private static int build;

        /// <summary>
        /// Gets the build number of the game.
        /// </summary>
        public static int Build
        {
            get
            {
                if (build < 0)
                {
                    build = GetContent<Dictionary<string, int>>("build.json", null, Categories.Miscellaneous).Values.Single();
                }

                return build;
            }
        }

        /// <summary>Gets the latest build from the server.</summary>
        /// <returns>The latest build.</returns>
        public static int GetLatestBuild()
        {
            int latestBuild = GetContent<Dictionary<string, int>>("build.json", null, Categories.Miscellaneous).Values.Single();

            build = latestBuild;

            return latestBuild;
        }

        /// <summary>
        /// Calls the API and returns a CLI object of the specified type.
        /// </summary>
        /// <param name="apiMethod">The API method to call.</param>
        /// <param name="arguments">The arguments to supply to the method.</param>
        /// <param name="category">The category the method is in.</param>
        /// <typeparam name="T">The type to convert the raw API result into.</typeparam>
        /// <returns>An object converted to <see cref="T"/>.</returns>
        public static T GetContent<T>(string apiMethod, List<KeyValuePair<string, object>> arguments, Categories category)
        {
            var jsonResponse = GetJson(apiMethod, arguments, category);

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        /// <summary>
        /// Gets the JSON string from the API.
        /// </summary>
        /// <param name="apiMethod">The API method to call.</param>
        /// <param name="arguments">The arguments to supply to the method.</param>
        /// <param name="category">The category the method is in.</param>
        /// <returns>The JSON encoded <see cref="string"/>.</returns>
        private static string GetJson(string apiMethod, IEnumerable<KeyValuePair<string, object>> arguments, Categories category)
        {
            var client = SwitchApiLocation(category);

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

            return client.Execute(restRequest).Content;
        }

        /// <summary>
        /// Do a switch based on the place where the caller wants to go. 
        /// Simple solution to keep the call in one method and not two.
        /// </summary>
        /// <param name="category">
        /// The category of the api.
        /// </param>
        /// <returns>
        /// The <see cref="RestClient"/>.
        /// </returns>
        private static RestClient SwitchApiLocation(Categories category)
        {
            var client = new RestClient();

            switch (category)
            {
                case Categories.Items:
                    client = new RestClient("https://api.guildwars2.com/v1/");
                    break;
                case Categories.World:
                    client = new RestClient("https://api.guildwars2.com/v1/");
                    break;
                case Categories.WvW:
                    client = new RestClient("https://api.guildwars2.com/v1/wvw/");
                    break;
                case Categories.Guild:
                    client = new RestClient("https://api.guildwars2.com/v1/");
                    break;
                case Categories.Miscellaneous:
                    client = new RestClient("https://api.guildwars2.com/v1/");
                    break;
            }

            return client;
        }
    }
}