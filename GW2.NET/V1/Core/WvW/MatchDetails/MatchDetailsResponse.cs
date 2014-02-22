// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.WvW.MatchDetails.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.MatchDetails
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="MatchDetailsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details"/> for more information.
    /// </remarks>
    public class MatchDetailsResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets the list of maps.
        /// </summary>
        [JsonProperty("maps", Order = 2)]
        public IEnumerable<Map> Maps { get; set; }

        /// <summary>
        /// Gets or sets the match's ID.
        /// </summary>
        [JsonProperty("match_id", Order = 0)]
        public string MatchId { get; set; }

        /// <summary>
        /// Gets or sets the total scores.
        /// </summary>
        [JsonProperty("scores", Order = 1)]
        public Scoreboard Scores { get; set; }
    }
}