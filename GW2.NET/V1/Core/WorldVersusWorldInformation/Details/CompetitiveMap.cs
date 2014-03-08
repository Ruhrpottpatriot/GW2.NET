// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitiveMap.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Details
{
    /// <summary>
    ///     Represents a World versus World map.
    /// </summary>
    public class CompetitiveMap : JsonObject
    {
        /// <summary>
        ///     Gets or sets the map's bonuses.
        /// </summary>
        [JsonProperty("bonuses", Order = 3)]
        public MapBonusCollection Bonuses { get; set; }

        /// <summary>
        ///     Gets or sets the map's objectives.
        /// </summary>
        [JsonProperty("objectives", Order = 2)]
        public ObjectiveCollection Objectives { get; set; }

        /// <summary>
        ///     Gets or sets the map's scoreboard.
        /// </summary>
        [JsonProperty("scores", Order = 1)]
        public Scoreboard Scores { get; set; }

        /// <summary>
        ///     Gets or sets the map's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public CompetitiveMapType Type { get; set; }
    }
}