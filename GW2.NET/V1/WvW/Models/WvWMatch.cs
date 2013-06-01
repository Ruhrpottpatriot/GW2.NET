// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WvWMatch.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Match type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.WvW.Models
{
    /// <summary>
    /// Represents a world vs world match.
    /// </summary>
    public partial struct WvWMatch
    {
        /// <summary>
        /// The match id.
        /// </summary>
        private readonly string matchId;

        /// <summary>
        /// Initializes a new instance of the <see cref="WvWMatch"/> struct.
        /// </summary>
        /// <param name="matchId">
        /// The match id.
        /// </param>
        /// <param name="redWorld">
        /// The red world id.
        /// </param>
        /// <param name="blueWorld">
        /// The blue world id.
        /// </param>
        /// <param name="greenWorld">
        /// The green world id.
        /// </param>
        /// <param name="startTime">
        /// The start time of the match.
        /// </param>
        /// <param name="endTime">
        /// The end time of the match.
        /// </param>
        /// <param name="scores">
        /// The scores.
        /// </param>
        /// <param name="maps">
        /// The maps.
        /// </param>
        [JsonConstructor]
        public WvWMatch(string matchId, string redWorld, string blueWorld, string greenWorld, DateTime startTime, DateTime endTime, IEnumerable<int> scores, IEnumerable<WvWMap> maps)
            : this()
        {
            this.RedWorld = redWorld;
            this.BlueWorld = blueWorld;
            this.GreenWorld = greenWorld;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Scores = scores;
            this.Maps = maps;
            this.matchId = matchId;
        }

        /// <summary>
        /// Gets the match id.
        /// </summary>
        [JsonProperty("wvw_match_id")]
        public string MatchId
        {
            get
            {
                return this.matchId;
            }
        }

        /// <summary>
        /// Gets the red world id.
        /// </summary>
        [JsonProperty("red_world_id")]
        public string RedWorld
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the blue world id.
        /// </summary>
        [JsonProperty("blue_world_id")]
        public string BlueWorld
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the green world id.
        /// </summary>
        [JsonProperty("green_world_id")]
        public string GreenWorld
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the start time of the match.
        /// </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the end time of the match.
        /// </summary>
        [JsonProperty("end_time")]
        public DateTime EndTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the scores.
        /// </summary>
        [JsonProperty("scores")]
        public IEnumerable<int> Scores
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the maps.
        /// </summary>
        [JsonProperty("maps")]
        public IEnumerable<WvWMap> Maps
        {
            get;
            private set;
        }
    }
}
