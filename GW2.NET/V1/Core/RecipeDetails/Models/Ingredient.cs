// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ingredient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.RecipeDetails.Models
{
    /// <summary>
    /// Represents one of a recipe's ingredients.
    /// </summary>
    public class Ingredient : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        public Ingredient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The required item.</param>
        /// <param name="count">The number of items required.</param>
        public Ingredient(int itemId, int count)
        {
            this.ItemId = itemId;
            this.Count = count;
        }

        /// <summary>
        /// Gets or sets the number of items required.
        /// </summary>
        [JsonProperty("count", Order = 1)]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the required item.
        /// </summary>
        [JsonProperty("item_id", Order = 0)]
        public int ItemId { get; set; }
    }
}