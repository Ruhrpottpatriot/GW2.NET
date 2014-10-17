// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRestrictions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates known item restrictions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Items
{
    using System;

    /// <summary>Enumerates known item restrictions.</summary>
    [Flags]
    public enum ItemRestrictions
    {
        /// <summary>Indicates no restrictions.</summary>
        None = 0, 

        /// <summary>The 'Asura' item restriction.</summary>
        Asura = 1 << 0, 

        /// <summary>The 'Charr' item restriction.</summary>
        Charr = 1 << 1, 

        /// <summary>The 'Human' item restriction.</summary>
        Human = 1 << 2, 

        /// <summary>The 'Norn' item restriction.</summary>
        Norn = 1 << 3, 

        /// <summary>The 'Sylvari' item restriction.</summary>
        Sylvari = 1 << 4, 

        /// <summary>The 'Elementalist' item restriction.</summary>
        Elementalist = 1 << 5, 

        /// <summary>The 'Engineer' item restriction.</summary>
        Engineer = 1 << 6, 

        /// <summary>The 'Guardian' item restriction.</summary>
        Guardian = 1 << 7, 

        /// <summary>The 'Mesmer' item restriction.</summary>
        Mesmer = 1 << 8, 

        /// <summary>The 'Necromancer' item restriction.</summary>
        Necromancer = 1 << 9, 

        /// <summary>The 'Ranger' item restriction.</summary>
        Ranger = 1 << 10, 

        /// <summary>The 'Thief' item restriction.</summary>
        Thief = 1 << 11, 

        /// <summary>The 'Warrior' item restriction.</summary>
        Warrior = 1 << 12
    }
}