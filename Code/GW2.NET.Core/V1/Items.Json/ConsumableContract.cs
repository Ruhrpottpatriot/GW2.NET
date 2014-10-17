// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents a consumable item.</summary>
    [DataContract]
    public sealed class ConsumableContract
    {
        /// <summary>Gets or sets the unlocked color identifier.</summary>
        [DataMember(Name = "color_id", Order = 5)]
        public string ColorId { get; set; }

        /// <summary>Gets or sets the consumable's effect description.</summary>
        [DataMember(Name = "description", Order = 2)]
        public string Description { get; set; }

        /// <summary>Gets or sets the consumable's effect duration.</summary>
        [DataMember(Name = "duration_ms", Order = 1)]
        public string Duration { get; set; }

        /// <summary>Gets or sets the unlocked recipe identifier.</summary>
        [DataMember(Name = "recipe_id", Order = 4)]
        public string RecipeId { get; set; }

        /// <summary>Gets or sets the consumable type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        /// <summary>Gets or sets the unlock type.</summary>
        [DataMember(Name = "unlock_type", Order = 3)]
        public string UnlockType { get; set; }
    }
}