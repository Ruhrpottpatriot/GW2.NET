// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingIngredients.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes
{
    /// <summary>
    /// Represents a collection of crafting ingredients.
    /// </summary>
    public class CraftingIngredients : JsonList<CraftingIngredient>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingIngredients"/> class.
        /// </summary>
        public CraftingIngredients()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingIngredients"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public CraftingIngredients(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingIngredients"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public CraftingIngredients(IEnumerable<CraftingIngredient> collection)
            : base(collection)
        {
        }
    }
}