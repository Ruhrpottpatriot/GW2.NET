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
    using System;

    /// <summary>
    /// Provides methods to get match data from the API.
    /// </summary>
    public class MatchData
    {
        /// <summary>
        /// We store the language string here to pass to the API
        /// </summary>
        private Languages language;

        /// <summary>
        /// Cache the world list here.
        /// </summary>
        private List<World> worldList;

        /// <summary>
        /// Cache the world dictionary here.
        /// </summary>
        private Dictionary<int, string> worldDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchData"/> class,
        /// which contains methods for interacting with
        /// WVW matches. Language is assumed to be "en".
        /// </summary>
        public MatchData()
        {
            this.language = Languages.en;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchData"/> class,
        /// which contains methods for interacting with
        /// WVW matches.
        /// </summary>
        /// <param name="language">Determines the language that world names are returned in</param>
        public MatchData(Languages language)
        {
            this.language = language;
        }

        /// <summary>
        /// Available languages
        /// </summary>
        public enum Languages
        {
            /// <summary>
            /// English language
            /// </summary>
            en,

            /// <summary>
            /// French language
            /// </summary>
            fr,

            /// <summary>
            /// German language
            /// </summary>
            de,

            /// <summary>
            /// Spanish language
            /// </summary>
            es
        }

        /// <summary>
        /// Gets or sets the language. Note that setting the
        /// language invalidates all cached objects.
        /// </summary>
        public Languages Language
        {
            get
            {
                return this.language;
            }

            set
            {
                this.worldList = null;

                this.worldDictionary = null;

                this.language = value;
            }
        }

        /// <summary>
        /// Gets all available worlds.
        /// This is purposely not exposed to callers. We only
        /// use this for resolving world IDs in the MatchDetails
        /// response.
        /// </summary>
        private List<World> Worlds
        {
            get
            {
                if (this.worldList == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("lang", this.Language.ToString())
                    };

                    this.worldList = ApiCall.CallApi<List<World>>("world_names.json", arguments);
                }

                return this.worldList;
            }
        }

        /// <summary>
        /// Gets a world name from a world ID.
        /// This is purposely not exposed to callers. We only
        /// use this for resolving world IDs in the MatchDetails
        /// response.
        /// </summary>
        private Dictionary<int, string> WorldDictionary
        {
            get
            {
                if (this.worldDictionary == null)
                {
                    this.worldDictionary = new Dictionary<int, string>();
                    foreach (var world in this.Worlds)
                    {
                        this.worldDictionary.Add(world.Id, world.Name);
                    }
                }

                return this.worldDictionary;
            }
        }

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

        /// <summary>
        /// Gets the details of the specified WVW match.
        /// </summary>
        /// <param name="matchID">The match ID string</param>
        /// <returns>MatchDetails object</returns>
        public MatchDetails GetMatchDetails(string matchID)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("match_id", matchID)
            };

            MatchDetails details = ApiCall.CallApi<MatchDetails>("wvw/match_details.json", arguments);
            return details;
        }
    }
}
