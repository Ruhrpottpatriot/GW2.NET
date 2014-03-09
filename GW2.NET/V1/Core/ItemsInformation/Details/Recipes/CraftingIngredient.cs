// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingIngredient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of a recipe's ingredients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents one of a recipe's ingredients.
    /// </summary>
    public class CraftingIngredient : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the number of items required.
        /// </summary>
        [JsonProperty("count", Order = 1)]
        public int Count { get; set; }

        /// <summary>
        ///     Gets or sets the required item.
        /// </summary>
        [JsonProperty("item_id", Order = 0)]
        public int ItemId { get; set; }

        #endregion
    }
}