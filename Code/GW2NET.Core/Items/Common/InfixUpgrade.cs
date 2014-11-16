// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfixUpgrade.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an item's infixed combat upgrades.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items.Common
{
    using System.Collections.Generic;

    /// <summary>Represents an item's infixed combat upgrades.</summary>
    public class InfixUpgrade
    {
        /// <summary>Gets or sets the combat attribute modifiers.</summary>
        public ICollection<CombatAttribute> Attributes { get; set; }

        /// <summary>Gets or sets the buff. This is used for Boon Duration, Condition Duration, or additional attribute bonuses for ascended trinkets or back items.</summary>
        public CombatBuff Buff { get; set; }
    }
}