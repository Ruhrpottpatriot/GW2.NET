// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for upgrade component types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System.Collections.Generic;

    /// <summary>Provides the base class for upgrade component types.</summary>
    public abstract class UpgradeComponent : Item, IUpgrade
    {
        /// <summary>Backing field for <see cref="InfixUpgrade"/>.</summary>
        private InfixUpgrade infixUpgrade = new InfixUpgrade();

        /// <summary>Gets or sets the upgrade component's bonuses.</summary>
        public virtual ICollection<string> Bonuses { get; set; }

        /// <summary>Gets or sets the item's infixed combat upgrades.</summary>
        public virtual InfixUpgrade InfixUpgrade
        {
            get
            {
                return this.infixUpgrade;
            }

            set
            {
                this.infixUpgrade = value;
            }
        }

        /// <summary>Gets or sets the upgrade component's infusion upgrades.</summary>
        public virtual InfusionSlotFlags InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        public virtual string Suffix { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        public virtual UpgradeComponentFlags UpgradeComponentFlags { get; set; }
    }
}