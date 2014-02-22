// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.Continents.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Continents
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="ContinentsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/continents"/> for more information.
    /// </remarks>
    public class ContinentsResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets the collection of continents.
        /// </summary>
        [JsonProperty("continents", Order = 0)]
        public IDictionary<int, Continent> Continents { get; set; }
    }
}