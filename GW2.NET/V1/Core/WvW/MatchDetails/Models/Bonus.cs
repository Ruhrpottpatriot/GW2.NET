// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bonus.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.MatchDetails.Models
{
    /// <summary>
    /// Represents a World versus World map's bonus.
    /// </summary>
    public class Bonus : JsonObject
    {
        /// <summary>
        /// Gets or sets the team that holds the bonus.
        /// </summary>
        [JsonProperty("owner", Order = 1)]
        public TeamColor Owner { get; set; }

        /// <summary>
        /// Gets or sets the bonus type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public BonusType Type { get; set; }
    }
}