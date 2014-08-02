// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IngredientContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a portion of crafting ingredients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a portion of crafting ingredients.</summary>
    [DataContract]
    public sealed class IngredientContract
    {
        /// <summary>Gets or sets the number of ingredients.</summary>
        [DataMember(Name = "count", Order = 1)]
        public string Count { get; set; }

        /// <summary>Gets or sets the ingredient identifier.</summary>
        [DataMember(Name = "item_id", Order = 0)]
        public string ItemId { get; set; }
    }
}