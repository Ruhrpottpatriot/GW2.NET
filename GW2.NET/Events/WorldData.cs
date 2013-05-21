// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods to get basic world data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using GW2DotNET.Models;

using Newtonsoft.Json.Linq;

namespace GW2DotNET.Events
{
    /// <summary>
    /// Provides methods to get basic world data.
    /// </summary>
    public class WorldData
    {
        /// <summary>
        /// Gets all the available worlds.
        /// </summary>
        /// <param name="language">The language of the world names. This parameter is optional.</param>
        /// <returns>An <see cref="IEnumerable"/> which contains all worlds in the specified language.</returns>
        public IEnumerable<World> GetWorlds(string language = "en")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.guildwars2.com/v1/world_names.json?lang=" + language);

            request.Method = WebRequestMethods.Http.Get;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Accept = "application/json";

            string jsonString;

            using (var response = request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd();
                }
            }

            var worlds = JArray.Parse(jsonString);

            return worlds.Select(world => new World(int.Parse((string)world["id"]), (string)world["name"]));
        }

        /// <summary>
        /// Gets all the available maps on a world.
        /// </summary>
        /// <param name="language">The language of the map names. This parameter is optional.</param>
        /// <returns>An <see cref="IEnumerable"/> which contains all maps in the specified language.</returns>
        public IEnumerable<World> GetMaps(string language = "en")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.guildwars2.com/v1/world_names.json?lang=" + language);

            request.Method = WebRequestMethods.Http.Get;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Accept = "application/json";

            string jsonString;

            using (var response = request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd();
                }
            }

            var maps = JArray.Parse(jsonString);

            return maps.Select(map => new World(int.Parse((string)map["id"]), (string)map["name"]));
        }
    }
}