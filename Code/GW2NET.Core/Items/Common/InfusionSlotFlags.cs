// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotFlags.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known infusion slot types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items.Common
{
    using System;

    /// <summary>Enumerates the known infusion slot types.</summary>
    [Flags]
    public enum InfusionSlotFlags
    {
        /// <summary>The 'Agony' infusion slot type.</summary>
        Agony = 0, 

        /// <summary>The 'Defense' infusion slot type.</summary>
        Defense = 1 << 0, 

        /// <summary>The 'Offense' infusion slot type.</summary>
        Offense = 1 << 1, 

        /// <summary>The 'Utility' infusion slot type.</summary>
        Utility = 1 << 2
    }
}