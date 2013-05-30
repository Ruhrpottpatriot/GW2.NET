// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Match.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Match type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.V1.World.Models;

using Newtonsoft.Json;

namespace GW2DotNET.V1.WvW.Models
{
    public struct WvWMatch
    {
        private readonly string matchId;

        [JsonConstructor]
        public WvWMatch(string matchId, string redWorld, string blueWorld, string greenWorld, IEnumerable<int> scores, IEnumerable<WvWMap> maps)
            : this()
        {
            this.RedWorld = redWorld;
            this.BlueWorld = blueWorld;
            this.GreenWorld = greenWorld;
            this.Scores = scores;
            this.Maps = maps;
            this.matchId = matchId;
        }

        [JsonProperty("wvw_match_id")]
        public string MatchId
        {
            get
            {
                return this.matchId;
            }
        }

        [JsonProperty("red_world_id")]
        public string RedWorld { get; private set; }

        [JsonProperty("blue_world_id")]
        public string BlueWorld { get; private set; }

        [JsonProperty("green_world_id")]
        public string GreenWorld { get; private set; }

        [JsonProperty("scores")]
        public IEnumerable<int> Scores { get; private set; }

        [JsonProperty("maps")]
        public IEnumerable<WvWMap> Maps { get; private set; }

        public struct WvWMap
        {
            public WvWMap(Type mapType, IEnumerable<int> scores, IEnumerable<Objective> objectives)
                : this()
            {
                this.MapType = mapType;
                this.Scores = scores;
                this.Objectives = objectives;
            }

            [JsonProperty("type")]
            public Type MapType { get; private set; }

            [JsonProperty("scores")]
            public IEnumerable<int> Scores { get; private set; }

            [JsonProperty("objectives")]
            public IEnumerable<Objective> Objectives { get; private set; }

            public struct Objective
            {
                [JsonConstructor]
                public Objective(int id, string owner, string ownerGuild)
                    : this()
                {
                    this.Id = id;
                    this.Owner = owner;
                    this.OwnerGuild = ownerGuild;
                }

                [JsonProperty("id")]
                public int Id { get; private set; }

                [JsonProperty("owner")]
                public string Owner { get; private set; }

                [JsonProperty("owner_guild")]
                public string OwnerGuild { get; private set; }
            }

            public enum Type
            {
                RedHome,
                BlueHome,
                GreenHome,
                Center
            }
        }
    }
}
