// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for types that represent a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2DotNET.ChatLinks;
    using GW2DotNET.Entities.Items;

    /// <summary>Provides the base class for types that represent a crafting recipe.</summary>
    public abstract class Recipe : IEquatable<Recipe>
    {
        /// <summary>Gets or sets the recipe's build number.</summary>
        public virtual int BuildId { get; set; }

        /// <summary>Gets or sets the crafting disciplines that can learn the recipe.</summary>
        public virtual CraftingDisciplines CraftingDisciplines { get; set; }

        /// <summary>Gets or sets the recipe's flags.</summary>
        public virtual RecipeFlags Flags { get; set; }

        /// <summary>Gets or sets a collection of the required ingredients.</summary>
        public virtual ICollection<ItemStack> Ingredients { get; set; }

        /// <summary>Gets or sets the language.</summary>
        public virtual string Language { get; set; }

        /// <summary>Gets or sets the recipe's minimum rating.</summary>
        public virtual int MinimumRating { get; set; }

        /// <summary>Gets or sets the output item.</summary>
        public virtual Item OutputItem { get; set; }

        /// <summary>Gets or sets the amount of items produced.</summary>
        public virtual int OutputItemCount { get; set; }

        /// <summary>Gets or sets the output item identifier.</summary>
        public virtual int OutputItemId { get; set; }

        /// <summary>Gets or sets the recipe identifier.</summary>
        public virtual int RecipeId { get; set; }

        /// <summary>Gets or sets the time it takes to craft the recipe.</summary>
        public virtual TimeSpan TimeToCraft { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Recipe left, Recipe right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Recipe left, Recipe right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(Recipe other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.RecipeId == other.RecipeId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Recipe)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.RecipeId;
        }

        /// <summary>Gets a recipe chat link for this item recipe.</summary>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public virtual ChatLink GetRecipeChatLink()
        {
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            return new RecipeChatLink { RecipeId = this.RecipeId };
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var item = this.OutputItem;
            if (item == null)
            {
                return this.OutputItemId.ToString(NumberFormatInfo.InvariantInfo);
            }

            var count = this.OutputItemCount;
            if (count > 1)
            {
                return string.Format("{0} ({1})", item, count);
            }

            return item.ToString();
        }
    }
}