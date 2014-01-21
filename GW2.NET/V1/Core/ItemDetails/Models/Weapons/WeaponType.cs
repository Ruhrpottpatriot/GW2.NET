// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Weapons
{
    /// <summary>
    /// Enumerates the possible weapon types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeaponType
    {
        /// <summary>The 'Axe' weapon type.</summary>
        [EnumMember(Value = "Axe")]
        Axe = 1 << 0,

        /// <summary>The 'Dagger' weapon type.</summary>
        [EnumMember(Value = "Dagger")]
        Dagger = 1 << 1,

        /// <summary>The 'Focus' weapon type.</summary>
        [EnumMember(Value = "Focus")]
        Focus = 1 << 2,

        /// <summary>The 'Great sword' weapon type.</summary>
        [EnumMember(Value = "Greatsword")]
        Greatsword = 1 << 3,

        /// <summary>The 'Hammer' weapon type.</summary>
        [EnumMember(Value = "Hammer")]
        Hammer = 1 << 4,

        /// <summary>The 'Harpoon' weapon type.</summary>
        [EnumMember(Value = "Harpoon")]
        Harpoon = 1 << 5,

        /// <summary>The 'Large bundle' weapon type.</summary>
        [EnumMember(Value = "LargeBundle")]
        LargeBundle = 1 << 6,

        /// <summary>The 'Long bow' weapon type.</summary>
        [EnumMember(Value = "LongBow")]
        LongBow = 1 << 7,

        /// <summary>The 'Mace' weapon type.</summary>
        [EnumMember(Value = "Mace")]
        Mace = 1 << 8,

        /// <summary>The 'Pistol' weapon type.</summary>
        [EnumMember(Value = "Pistol")]
        Pistol = 1 << 9,

        /// <summary>The 'Rifle' weapon type.</summary>
        [EnumMember(Value = "Rifle")]
        Rifle = 1 << 10,

        /// <summary>The 'Scepter' weapon type.</summary>
        [EnumMember(Value = "Scepter")]
        Scepter = 1 << 11,

        /// <summary>The 'Shield' weapon type.</summary>
        [EnumMember(Value = "Shield")]
        Shield = 1 << 12,

        /// <summary>The 'Short bow' weapon type.</summary>
        [EnumMember(Value = "ShortBow")]
        ShortBow = 1 << 13,

        /// <summary>The 'Spear gun' weapon type.</summary>
        [EnumMember(Value = "Speargun")]
        Speargun = 1 << 14,

        /// <summary>The 'Staff' weapon type.</summary>
        [EnumMember(Value = "Staff")]
        Staff = 1 << 15,

        /// <summary>The 'Sword' weapon type.</summary>
        [EnumMember(Value = "Sword")]
        Sword = 1 << 16,

        /// <summary>The 'Torch' weapon type.</summary>
        [EnumMember(Value = "Torch")]
        Torch = 1 << 17,

        /// <summary>The 'Toy' weapon type.</summary>
        [EnumMember(Value = "Toy")]
        Toy = 1 << 18,

        /// <summary>The 'Trident' weapon type.</summary>
        [EnumMember(Value = "Trident")]
        Trident = 1 << 19,

        /// <summary>The 'Two-handed toy' weapon type.</summary>
        [EnumMember(Value = "TwoHandedToy")]
        TwoHandedToy = 1 << 20,

        /// <summary>The 'War horn' weapon type.</summary>
        [EnumMember(Value = "Warhorn")]
        Warhorn = 1 << 21
    }
}