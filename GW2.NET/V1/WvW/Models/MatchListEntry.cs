// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchListEntry.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchListEntry type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.WvW.Models
{
    /// <summary>
    /// Represents an entry in the <see cref="MatchList"/>.
    /// </summary>
    public class MatchListEntry
    {
        /// <summary>Initializes a new instance of the <see cref="MatchListEntry"/> class.</summary>
        /// <param name="matchId">The match id.</param>
        /// <param name="redWorldId">The red world id.</param>
        /// <param name="blueWorldId">The blue world id.</param>
        /// <param name="greenWorldId">The green world id.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        [JsonConstructor]
        public MatchListEntry(string matchId, int redWorldId, int blueWorldId, int greenWorldId, DateTime startTime, DateTime endTime)
        {
            this.EndTime = endTime;
            this.StartTime = startTime;
            this.GreenWorldId = greenWorldId;
            this.BlueWorldId = blueWorldId;
            this.RedWorldId = redWorldId;
            this.MatchId = matchId;
        }

        /// <summary>Gets the match id.</summary>
        [JsonProperty("wvw_match_id")]
        public string MatchId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the id of the red world.
        /// </summary>
        [JsonProperty("red_world_id")]
        public int RedWorldId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the id of the blue world.
        /// </summary>
        [JsonProperty("blue_world_id")]
        public int BlueWorldId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the id of the green world.
        /// </summary>
        [JsonProperty("green_world_id")]
        public int GreenWorldId
        {
            get;
            private set;
        }

        /// <summary>Gets the start time.</summary>
        [JsonProperty("start_time")]
        public DateTime StartTime
        {
            get;
            private set;
        }

        /// <summary>Gets the end time.</summary>
        [JsonProperty("end_time")]
        public DateTime EndTime
        {
            get;
            private set;
        }
    }
}
