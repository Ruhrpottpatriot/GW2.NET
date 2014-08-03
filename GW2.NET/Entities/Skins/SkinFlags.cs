// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinFlags.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known additional skin flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.Skins
{
    using System;

    /// <summary>Enumerates the known additional skin flags.</summary>
    [Flags]
    public enum SkinFlags
    {
        /// <summary>Indicates no additional skin flags.</summary>
        None = 0, 

        /// <summary>The 'Show In Wardrobe' skin flag.</summary>
        ShowInWardrobe = 1 << 0, 

        /// <summary>The 'No Cost' skin flag.</summary>
        NoCost = 1 << 1, 

        /// <summary>The 'Hide If Locked' skin flag.</summary>
        HideIfLocked = 1 << 2
    }
}