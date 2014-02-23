// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Match.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs
{
    /// <summary>
    /// Represents a World versus World match.
    /// </summary>
    public class Match : JsonObject
    {
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
    }
}