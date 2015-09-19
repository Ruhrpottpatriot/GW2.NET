// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RecipeDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Recipes.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/recipe_details")]
    public sealed class RecipeDTO
    {
        [DataMember(Name = "recipe_id", Order = 0)]
        public string RecipeId { get; set; }

        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        [DataMember(Name = "output_item_id", Order = 2)]
        public string OutputItemId { get; set; }

        [DataMember(Name = "output_item_count", Order = 3)]
        public string OutputItemCount { get; set; }

        [DataMember(Name = "min_rating", Order = 4)]
        public string MinimumRating { get; set; }

        [DataMember(Name = "time_to_craft_ms", Order = 5)]
        public string TimeToCraft { get; set; }

        [DataMember(Name = "disciplines", Order = 6)]
        public ICollection<string> CraftingDisciplines { get; set; }

        [DataMember(Name = "flags", Order = 7)]
        public ICollection<string> Flags { get; set; }

        [DataMember(Name = "ingredients", Order = 8)]
        public ICollection<IngredientDTO> Ingredients { get; set; }
    }
}