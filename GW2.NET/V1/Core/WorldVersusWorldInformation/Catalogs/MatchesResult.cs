// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchesResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs
{
    /// <summary>
    /// Wraps a collection of matches.
    /// </summary>
    public class MatchesResult : JsonObject
    {
        /// <summary>
        /// Gets or sets a collection of matches.
        /// </summary>
        [JsonProperty("wvw_matches", Order = 0)]
        public MatchCollection Matches { get; set; }
    }
}