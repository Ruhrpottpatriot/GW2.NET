// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ingredient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a portion of crafting ingredients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts;

    /// <summary>Represents a portion of crafting ingredients.</summary>
    public class Ingredient : ServiceContract
    {
        /// <summary>Gets or sets the number of ingredients.</summary>
        [DataMember(Name = "count")]
        public virtual int Count { get; set; }

        /// <summary>Gets or sets the ingredient.</summary>
        public virtual Item Item { get; set; }

        /// <summary>Gets or sets the ingredient's identifier.</summary>
        [DataMember(Name = "item_id")]
        public virtual int ItemId { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var item = this.Item;
            if (item != null)
            {
                return string.Format("{0}x {1}", this.Count, item.Name);
            }

            return base.ToString();
        }
    }
}