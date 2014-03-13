// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentsResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of continents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Continents
{
    using GW2DotNET.V1.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    ///     Wraps a collection of continents.
    /// </summary>
    public class ContinentsResult : JsonObject
    {
        /// <summary>
        ///     Gets or sets a collection of continents.
        /// </summary>
        [JsonProperty("continents", Order = 0)]
        public ContinentCollection Continents { get; set; }
    }
}