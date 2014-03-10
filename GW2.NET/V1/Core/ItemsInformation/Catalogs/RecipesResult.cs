// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipesResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of recipe IDs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Catalogs
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Wraps a collection of recipe IDs.
    /// </summary>
    public class RecipesResult : JsonObject
    {
        /// <summary>
        ///     Gets or sets a collection of recipes.
        /// </summary>
        [JsonProperty("recipes", Order = 0)]
        public RecipeCollection Recipes { get; set; }
    }
}