// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DyesDetailsResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ColorsInformation.Details
{
    /// <summary>
    /// Wraps a collection of dyes in the game.
    /// </summary>
    public class DyesDetailsResult : JsonObject
    {
        /// <summary>
        /// Gets or sets a collection of dyes in the game.
        /// </summary>
        [JsonProperty("colors", Order = 0)]
        public DyesDetails Colors { get; set; }
    }
}