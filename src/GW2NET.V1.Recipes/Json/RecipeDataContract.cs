// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RecipeDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Recipes.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/recipe_details")]
    internal sealed class RecipeDataContract
    {
        [DataMember(Name = "recipe_id", Order = 0)]
        internal string RecipeId { get; set; }

        [DataMember(Name = "type", Order = 1)]
        internal string Type { get; set; }

        [DataMember(Name = "output_item_id", Order = 2)]
        internal string OutputItemId { get; set; }

        [DataMember(Name = "output_item_count", Order = 3)]
        internal string OutputItemCount { get; set; }

        [DataMember(Name = "min_rating", Order = 4)]
        internal string MinimumRating { get; set; }

        [DataMember(Name = "time_to_craft_ms", Order = 5)]
        internal string TimeToCraft { get; set; }

        [DataMember(Name = "disciplines", Order = 6)]
        internal ICollection<string> CraftingDisciplines { get; set; }

        [DataMember(Name = "flags", Order = 7)]
        internal ICollection<string> Flags { get; set; }

        [DataMember(Name = "ingredients", Order = 8)]
        internal ICollection<IngredientDataContract> Ingredients { get; set; }
    }
}
