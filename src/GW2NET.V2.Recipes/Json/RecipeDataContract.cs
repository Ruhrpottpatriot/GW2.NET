// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RecipeDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/recipes")]
    internal sealed class RecipeDataContract
    {
        #region Public Properties

        [DataMember(Order = 5, Name = "disciplines")]
        public ICollection<string> Disciplines { get; set; }

        [DataMember(Order = 6, Name = "flags")]
        public ICollection<string> Flags { get; set; }

        [DataMember(Order = 8, Name = "id")]
        public int Id { get; set; }

        [DataMember(Order = 7, Name = "ingredients")]
        public ICollection<IngredientDataContract> Ingredients { get; set; }

        [DataMember(Order = 3, Name = "min_rating")]
        public int MinRating { get; set; }

        [DataMember(Order = 2, Name = "output_item_count")]
        public int OutputItemCount { get; set; }

        [DataMember(Order = 1, Name = "output_item_id")]
        public int OutputItemId { get; set; }

        [DataMember(Order = 4, Name = "time_to_craft_ms")]
        public double TimeToCraftMs { get; set; }

        [DataMember(Order = 0, Name = "type")]
        public string Type { get; set; }

        #endregion
    }
}