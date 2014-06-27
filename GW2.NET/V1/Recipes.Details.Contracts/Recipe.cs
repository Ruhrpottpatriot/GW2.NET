// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for types that represent a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Contracts;

    using Newtonsoft.Json;

    /// <summary>Provides the base class for types that represent a crafting recipe.</summary>
    public abstract class Recipe : ServiceContract, IEquatable<Recipe>, IComparable<Recipe>
    {
        /// <summary>Gets or sets the recipe's build number.</summary>
        [DataMember(Name = "build_id")]
        public virtual int BuildId { get; set; }

        /// <summary>Gets or sets the crafting disciplines that can use the recipe.</summary>
        [DataMember(Name = "disciplines")]
        public virtual CraftingDisciplines CraftingDisciplines { get; set; }

        /// <summary>Gets or sets the recipe's unlock type(s).</summary>
        [DataMember(Name = "flags")]
        public virtual RecipeUnlockTypes Flags { get; set; }

        /// <summary>Gets or sets a collection of the required ingredients.</summary>
        [DataMember(Name = "ingredients")]
        public virtual IngredientCollection Ingredients { get; set; }

        /// <summary>Gets or sets the language info.</summary>
        [DataMember(Name = "lang")]
        public virtual string Language { get; set; }

        /// <summary>Gets or sets the recipe's minimum rating.</summary>
        [DataMember(Name = "min_rating")]
        public virtual int MinimumRating { get; set; }

        /// <summary>Gets or sets the output item.</summary>
        [DataMember(Name = "output_item_id")]
        [JsonConverter(typeof(UnknownItemConverter))]
        public virtual Item OutputItem { get; set; }

        /// <summary>Gets or sets the amount of items produced.</summary>
        [DataMember(Name = "output_item_count")]
        public virtual int OutputItemCount { get; set; }

        /// <summary>Gets or sets the recipe's identifier.</summary>
        [DataMember(Name = "recipe_id")]
        public virtual int RecipeId { get; set; }

        /// <summary>Gets or sets the time it takes to craft the recipe.</summary>
        [DataMember(Name = "time_to_craft_ms")]
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

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than<paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Recipe other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.RecipeId.CompareTo(other.RecipeId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Recipe other)
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

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var outputItem = this.OutputItem;
            if (outputItem != null)
            {
                return string.Format("{0}x {1}", this.OutputItemCount, outputItem);
            }

            return this.RecipeId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}