// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemFlags.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known additional item flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System;

    /// <summary>Enumerates the known additional item flags.</summary>
    [Flags]
    public enum ItemFlags
    {
        /// <summary>Indicates no additional item flags.</summary>
        None = 0, 

        /// <summary>The 'Account Bound' item flag.</summary>
        AccountBound = 1 << 0, 

        /// <summary>The 'Hide Suffix' item flag.</summary>
        HideSuffix = 1 << 1, 

        /// <summary>The 'No Mystic Forge' item flag.</summary>
        NoMysticForge = 1 << 2, 

        /// <summary>The 'No Salvage' item flag.</summary>
        NoSalvage = 1 << 3, 

        /// <summary>The 'No Sell' item flag.</summary>
        NoSell = 1 << 4, 

        /// <summary>The 'Not Upgradeable' item flag.</summary>
        NotUpgradeable = 1 << 5, 

        /// <summary>The 'No Underwater' item flag.</summary>
        NoUnderwater = 1 << 6, 

        /// <summary>The 'Soul Bind On Acquire' item flag.</summary>
        SoulBindOnAcquire = 1 << 7, 

        /// <summary>The 'Soul Bind On Use' item flag.</summary>
        SoulBindOnUse = 1 << 8, 

        /// <summary>The 'Unique' item flag.</summary>
        Unique = 1 << 9, 

        /// <summary>The 'Account Bind On Use' item flag.</summary>
        AccountBindOnUse = 1 << 10, 

        /// <summary>The 'Monster Only' item flag.</summary>
        MonsterOnly = 1 << 11
    }
}