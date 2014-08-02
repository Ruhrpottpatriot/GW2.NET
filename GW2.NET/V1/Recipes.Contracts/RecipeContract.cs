// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a crafting recipe.</summary>
    [DataContract]
    public sealed class RecipeContract
    {
        /// <summary>Gets or sets the crafting disciplines that can learn the recipe.</summary>
        [DataMember(Name = "disciplines", Order = 6)]
        public ICollection<string> CraftingDisciplines { get; set; }

        /// <summary>Gets or sets the recipe's flags.</summary>
        [DataMember(Name = "flags", Order = 7)]
        public ICollection<string> Flags { get; set; }

        /// <summary>Gets or sets a collection of the required ingredients.</summary>
        [DataMember(Name = "ingredients", Order = 8)]
        public ICollection<IngredientContract> Ingredients { get; set; }

        /// <summary>Gets or sets the recipe's minimum rating.</summary>
        [DataMember(Name = "min_rating", Order = 4)]
        public string MinimumRating { get; set; }

        /// <summary>Gets or sets the amount of items produced.</summary>
        [DataMember(Name = "output_item_count", Order = 3)]
        public string OutputItemCount { get; set; }

        /// <summary>Gets or sets the output item identifier.</summary>
        [DataMember(Name = "output_item_id", Order = 2)]
        public string OutputItemId { get; set; }

        /// <summary>Gets or sets the recipe identifier.</summary>
        [DataMember(Name = "recipe_id", Order = 0)]
        public string RecipeId { get; set; }

        /// <summary>Gets or sets the time it takes to craft the recipe in milliseconds.</summary>
        [DataMember(Name = "time_to_craft_ms", Order = 5)]
        public string TimeToCraft { get; set; }

        /// <summary>Gets or sets the recipe type.</summary>
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }
    }
}