// --------------------------------------------------------------------------------------------------------------------
// <copyright file="APICall.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ApiCall type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Net;

using RestSharp;

namespace GW2DotNET.Infrastructure
{
    public static class ApiCall
    {
        /// <summary>
        /// Calls the api with the specified method and parameters.
        /// </summary>
        /// <param name="apiMethod">The method to execute on the api.</param>
        /// <param name="arguments"> The arguments to add to the method.</param>
        /// <returns>A json encoded <see cref="string"/> containing the api response.</returns>
        public static string CallApi(string apiMethod, List<KeyValuePair<string, object>> arguments)
        {
            RestClient client = new RestClient("https://api.guildwars2.com/v1");

            RestRequest restRequest = new RestRequest(apiMethod, Method.GET);

            restRequest.RequestFormat = DataFormat.Json;

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
