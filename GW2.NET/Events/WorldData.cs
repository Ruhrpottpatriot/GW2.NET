// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods to get basic world data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using GW2DotNET.Events.Models;
using GW2DotNET.Infrastructure;

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
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", language)
            };

            string jsonString = ApiCall.CallApi("world_names.json", arguments);

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
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", language)
            };

            string jsonString = ApiCall.CallApi("map_names.json", arguments);

            var maps = JArray.Parse(jsonString);

            return maps.Select(map => new World(int.Parse((string)map["id"]), (string)map["name"]));
        }
    }
}