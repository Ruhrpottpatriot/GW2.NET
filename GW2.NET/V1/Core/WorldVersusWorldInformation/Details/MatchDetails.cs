// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a World versus World match.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Details
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a World versus World match.
    /// </summary>
    public class MatchDetails : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the list of maps.
        /// </summary>
        [JsonProperty("maps", Order = 2)]
        public CompetitiveMapCollection Maps { get; set; }

        /// <summary>
        ///     Gets or sets the match's ID.
        /// </summary>
        [JsonProperty("match_id", Order = 0)]
        public string MatchId { get; set; }

        /// <summary>
        ///     Gets or sets the total scores.
        /// </summary>
        [JsonProperty("scores", Order = 1)]
        public Scoreboard Scores { get; set; }

        #endregion
    }
}