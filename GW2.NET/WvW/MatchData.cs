// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.Events;
using GW2DotNET.Events.Models;
using GW2DotNET.Infrastructure;
using GW2DotNET.WvW.Models;

using Newtonsoft.Json.Linq;

namespace GW2DotNET.WvW
{
    /// <summary>
    /// Provides methods to get match data from the API.
    /// </summary>
    public class MatchData
    {
        /// <summary>
        /// Gets a list of matches from the API With their corresponding world.
        /// </summary>
        /// <returns>An <see cref="IEnumerable"/> with all the matches currently running.</returns>
        public IList<Match> GetMatches()
        {
            var jsonString = ApiCall.CallWvWApi("matches.json", null);

            var matches = (JArray)JObject.Parse(jsonString)["wvw_matches"];

            var matchList = new List<Match>();

            foreach (var match in matches)
            {
                int redWorldId = int.Parse((string)match["red_world_id"]);
                int blueWorldId = int.Parse((string)match["blue_world_id"]);
                int greenWorldId = int.Parse((string)match["green_world_id"]);

                World redWorld = new World(redWorldId, WorldData.Instance.WorldDictionary[redWorldId]);
                World blueWorld = new World(blueWorldId, WorldData.Instance.WorldDictionary[blueWorldId]);
                World greenWorld = new World(greenWorldId, WorldData.Instance.WorldDictionary[greenWorldId]);

                matchList.Add(new Match((string)match["wvw_match_id"], redWorld, blueWorld, greenWorld));
            }

            return matchList;
        }
    }
}
