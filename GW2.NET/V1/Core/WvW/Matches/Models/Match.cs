// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Match.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.Matches.Models
{
    /// <summary>
    /// Represents a World versus World match.
    /// </summary>
    public class Match
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Match"/> class.
        /// </summary>
        public Match()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Match"/> class using the specified values.
        /// </summary>
        /// <param name="matchId">The match's ID.</param>
        /// <param name="redWorldId">The red world's ID.</param>
        /// <param name="blueWorldId">The blue world's ID.</param>
        /// <param name="greenWorldId">The green world's ID.</param>
        /// <param name="startTime">The timestamp (UTC) of when the match started.</param>
        /// <param name="endTime">The timestamp (UTC) of when the match ends.</param>
        public Match(string matchId, int redWorldId, int blueWorldId, int greenWorldId, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            this.MatchId = matchId;
            this.RedWorldId = redWorldId;
            this.BlueWorldId = blueWorldId;
            this.GreenWorldId = greenWorldId;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        /// <summary>
        /// Gets or sets the blue world's ID.
        /// </summary>
        [JsonProperty("blue_world_id", Order = 2)]
        public int BlueWorldId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp (UTC) of when the match ends.
        /// </summary>
        [JsonProperty("end_time", Order = 5)]
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// Gets or sets the green world's ID.
        /// </summary>
        [JsonProperty("green_world_id", Order = 3)]
        public int GreenWorldId { get; set; }

        /// <summary>
        /// Gets or sets the match's ID.
        /// </summary>
        [JsonProperty("wvw_match_id", Order = 0)]
        public string MatchId { get; set; }

        /// <summary>
        /// Gets or sets the red world's ID.
        /// </summary>
        [JsonProperty("red_world_id", Order = 1)]
        public int RedWorldId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp (UTC) of when the match started.
        /// </summary>
        [JsonProperty("start_time", Order = 4)]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}