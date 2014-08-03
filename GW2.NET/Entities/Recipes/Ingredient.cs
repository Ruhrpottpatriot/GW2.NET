// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ingredient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a portion of crafting ingredients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.Recipes
{
    using System.Globalization;

    using GW2DotNET.Entities.Items;

    /// <summary>Represents a portion of crafting ingredients.</summary>
    public class Ingredient
    {
        /// <summary>Gets or sets the number of ingredients.</summary>
        public virtual int Count { get; set; }

        /// <summary>Gets or sets the ingredient.</summary>
        public virtual Item Item { get; set; }

        /// <summary>Gets or sets the ingredient identifier.</summary>
        public virtual int ItemId { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var item = this.Item;
            if (item == null)
            {
                return this.ItemId.ToString(NumberFormatInfo.InvariantInfo);
            }

            var count = this.Count;
            if (count > 1)
            {
                return string.Format("{0} ({1})", item, count);
            }

            return item.ToString();
        }
    }
}