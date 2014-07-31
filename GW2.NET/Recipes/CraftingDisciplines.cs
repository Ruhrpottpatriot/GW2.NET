// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingDisciplines.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates known crafting disciplines.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Recipes
{
    using System;

    /// <summary>Enumerates known crafting disciplines.</summary>
    [Flags]
    public enum CraftingDisciplines
    {
        /// <summary>Indicates no crafting disciplines.</summary>
        None = 0, 

        /// <summary>The 'Armor smith' crafting discipline.</summary>
        Armorsmith = 1 << 0, 

        /// <summary>The 'Artificer' crafting discipline.</summary>
        Artificer = 1 << 1, 

        /// <summary>The 'Chef' crafting discipline.</summary>
        Chef = 1 << 2, 

        /// <summary>The 'Huntsman' crafting discipline.</summary>
        Huntsman = 1 << 3, 

        /// <summary>The 'Jeweler' crafting discipline.</summary>
        Jeweler = 1 << 4, 

        /// <summary>The 'Leatherworker' crafting discipline.</summary>
        Leatherworker = 1 << 5, 

        /// <summary>The 'Tailor' crafting discipline.</summary>
        Tailor = 1 << 6, 

        /// <summary>The 'Weapon smith' crafting discipline.</summary>
        Weaponsmith = 1 << 7
    }
}