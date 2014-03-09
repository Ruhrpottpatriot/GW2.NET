// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingIngredientCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of crafting ingredients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes
{
    using System.Collections.Generic;

    /// <summary>
    ///     Represents a collection of crafting ingredients.
    /// </summary>
    public class CraftingIngredientCollection : JsonList<CraftingIngredient>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CraftingIngredientCollection" /> class.
        /// </summary>
        public CraftingIngredientCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CraftingIngredientCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public CraftingIngredientCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CraftingIngredientCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public CraftingIngredientCollection(IEnumerable<CraftingIngredient> collection)
            : base(collection)
        {
        }

        #endregion
    }
}