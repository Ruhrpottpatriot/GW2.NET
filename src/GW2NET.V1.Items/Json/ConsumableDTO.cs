// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ConsumableDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    public sealed class ConsumableDTO
    {
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "duration_ms", Order = 1)]
        public string Duration { get; set; }

        [DataMember(Name = "description", Order = 2)]
        public string Description { get; set; }

        [DataMember(Name = "unlock_type", Order = 3)]
        public string UnlockType { get; set; }

        [DataMember(Name = "recipe_id", Order = 4)]
        public string RecipeId { get; set; }

        [DataMember(Name = "color_id", Order = 5)]
        public string ColorId { get; set; }
    }
}