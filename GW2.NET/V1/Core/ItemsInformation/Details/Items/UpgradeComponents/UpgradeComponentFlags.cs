// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentFlags.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.UpgradeComponents
{
    /// <summary>
    ///     Enumerates the possible upgrade component flags.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum UpgradeComponentFlags
    {
        /// <summary>The 'Trinket' upgrade component flag.</summary>
        [EnumMember(Value = "Trinket")] Trinket = 1 << 0,

        /// <summary>The 'Light Armor' upgrade component flag.</summary>
        [EnumMember(Value = "LightArmor")] LightArmor = 1 << 1,

        /// <summary>The 'Medium Armor' upgrade component flag.</summary>
        [EnumMember(Value = "MediumArmor")] MediumArmor = 1 << 2,

        /// <summary>The 'Heavy Armor' upgrade component flag.</summary>
        [EnumMember(Value = "HeavyArmor")] HeavyArmor = 1 << 3,

        /// <summary>The 'Axe' upgrade component flag.</summary>
        [EnumMember(Value = "Axe")] Axe = 1 << 4,

        /// <summary>The 'Dagger' upgrade component flag.</summary>
        [EnumMember(Value = "Dagger")] Dagger = 1 << 5,

        /// <summary>The 'Focus' upgrade component flag.</summary>
        [EnumMember(Value = "Focus")] Focus = 1 << 6,

        /// <summary>The 'Great sword' upgrade component flag.</summary>
        [EnumMember(Value = "GreatSword")] Greatsword = 1 << 7,

        /// <summary>The 'Hammer' upgrade component flag.</summary>
        [EnumMember(Value = "Hammer")] Hammer = 1 << 8,

        /// <summary>The 'Harpoon' upgrade component flag.</summary>
        [EnumMember(Value = "Harpoon")] Harpoon = 1 << 9,

        /// <summary>The 'Long Bow' upgrade component flag.</summary>
        [EnumMember(Value = "LongBow")] LongBow = 1 << 10,

        /// <summary>The 'Mace' upgrade component flag.</summary>
        [EnumMember(Value = "Mace")] Mace = 1 << 11,

        /// <summary>The 'Pistol' upgrade component flag.</summary>
        [EnumMember(Value = "Pistol")] Pistol = 1 << 12,

        /// <summary>The 'Rifle' upgrade component flag.</summary>
        [EnumMember(Value = "Rifle")] Rifle = 1 << 13,

        /// <summary>The 'Scepter' upgrade component flag.</summary>
        [EnumMember(Value = "Scepter")] Scepter = 1 << 14,

        /// <summary>The 'Shield' upgrade component flag.</summary>
        [EnumMember(Value = "Shield")] Shield = 1 << 15,

        /// <summary>The 'Short Bow' upgrade component flag.</summary>
        [EnumMember(Value = "ShortBow")] ShortBow = 1 << 16,

        /// <summary>The 'Spear gun' upgrade component flag.</summary>
        [EnumMember(Value = "SpearGun")] Speargun = 1 << 17,

        /// <summary>The 'Staff' upgrade component flag.</summary>
        [EnumMember(Value = "Staff")] Staff = 1 << 18,

        /// <summary>The 'Sword' upgrade component flag.</summary>
        [EnumMember(Value = "Sword")] Sword = 1 << 19,

        /// <summary>The 'Torch' upgrade component flag.</summary>
        [EnumMember(Value = "Torch")] Torch = 1 << 20,

        /// <summary>The 'Trident' upgrade component flag.</summary>
        [EnumMember(Value = "Trident")] Trident = 1 << 21,

        /// <summary>The 'War horn' upgrade component flag.</summary>
        [EnumMember(Value = "WarHorn")] Warhorn = 1 << 22
    }
}