// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingIngredient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of a recipe's ingredients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Recipes.Details.Contracts.Ingredients
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Contracts;

    /// <summary>Represents one of a recipe's ingredients.</summary>
    public class CraftingIngredient : JsonObject
    {
        /// <summary>Gets or sets the number of items required.</summary>
        [DataMember(Name = "count", Order = 1)]
        public int Count { get; set; }

        /// <summary>Gets or sets the required item.</summary>
        [DataMember(Name = "item_id", Order = 0)]
        public int ItemId { get; set; }
    }
}