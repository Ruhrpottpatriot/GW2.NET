// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentFlags.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible upgrade component flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System;

    /// <summary>Enumerates the possible upgrade component flags.</summary>
    [Flags]
    public enum UpgradeComponentFlags
    {
        /// <summary>Indicates no upgrade component flags.</summary>
        None = 0,

        /// <summary>The 'Trinket' upgrade component flag.</summary>
        Trinket = 1 << 0,

        /// <summary>The 'Light Armor' upgrade component flag.</summary>
        LightArmor = 1 << 1,

        /// <summary>The 'Medium Armor' upgrade component flag.</summary>
        MediumArmor = 1 << 2,

        /// <summary>The 'Heavy Armor' upgrade component flag.</summary>
        HeavyArmor = 1 << 3,

        /// <summary>The 'Axe' upgrade component flag.</summary>
        Axe = 1 << 4,

        /// <summary>The 'Dagger' upgrade component flag.</summary>
        Dagger = 1 << 5,

        /// <summary>The 'Focus' upgrade component flag.</summary>
        Focus = 1 << 6,

        /// <summary>The 'Great sword' upgrade component flag.</summary>
        Greatsword = 1 << 7,

        /// <summary>The 'Hammer' upgrade component flag.</summary>
        Hammer = 1 << 8,

        /// <summary>The 'Harpoon' upgrade component flag.</summary>
        Harpoon = 1 << 9,

        /// <summary>The 'Long Bow' upgrade component flag.</summary>
        LongBow = 1 << 10,

        /// <summary>The 'Mace' upgrade component flag.</summary>
        Mace = 1 << 11,

        /// <summary>The 'Pistol' upgrade component flag.</summary>
        Pistol = 1 << 12,

        /// <summary>The 'Rifle' upgrade component flag.</summary>
        Rifle = 1 << 13,

        /// <summary>The 'Scepter' upgrade component flag.</summary>
        Scepter = 1 << 14,

        /// <summary>The 'Shield' upgrade component flag.</summary>
        Shield = 1 << 15,

        /// <summary>The 'Short Bow' upgrade component flag.</summary>
        ShortBow = 1 << 16,

        /// <summary>The 'Spear gun' upgrade component flag.</summary>
        Speargun = 1 << 17,

        /// <summary>The 'Staff' upgrade component flag.</summary>
        Staff = 1 << 18,

        /// <summary>The 'Sword' upgrade component flag.</summary>
        Sword = 1 << 19,

        /// <summary>The 'Torch' upgrade component flag.</summary>
        Torch = 1 << 20,

        /// <summary>The 'Trident' upgrade component flag.</summary>
        Trident = 1 << 21,

        /// <summary>The 'War horn' upgrade component flag.</summary>
        Warhorn = 1 << 22
    }
}