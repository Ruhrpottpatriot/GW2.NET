// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Recipes
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="RecipesRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes"/> for more information.
    /// </remarks>
    public class RecipesResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets the list of discovered recipes.
        /// </summary>
        [JsonProperty("recipes", Order = 0)]
        public IEnumerable<int> Recipes { get; set; }
    }
}