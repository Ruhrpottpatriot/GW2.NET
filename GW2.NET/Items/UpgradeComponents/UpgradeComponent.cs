// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for upgrade component types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Items
{
    using System.Collections.Generic;

    /// <summary>Provides the base class for upgrade component types.</summary>
    public abstract class UpgradeComponent : Item, IUpgrade
    {
        /// <summary>Gets or sets the upgrade component's bonuses.</summary>
        public virtual ICollection<string> Bonuses { get; set; }

        /// <summary>Gets or sets the item's buff.</summary>
        public virtual ItemBuff Buff { get; set; }

        /// <summary>Gets or sets the Condition Damage modifier.</summary>
        public virtual int ConditionDamage { get; set; }

        /// <summary>Gets or sets the Ferocity modifier.</summary>
        public virtual int Ferocity { get; set; }

        /// <summary>Gets or sets the Healing modifier.</summary>
        public virtual int Healing { get; set; }

        /// <summary>Gets or sets the upgrade component's infusion upgrades.</summary>
        public virtual InfusionSlotFlags InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the Power modifier.</summary>
        public virtual int Power { get; set; }

        /// <summary>Gets or sets the Precision modifier.</summary>
        public virtual int Precision { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        public virtual string Suffix { get; set; }

        /// <summary>Gets or sets the Toughness modifier.</summary>
        public virtual int Toughness { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        public virtual UpgradeComponentFlags UpgradeComponentFlags { get; set; }

        /// <summary>Gets or sets the Vitality modifier.</summary>
        public virtual int Vitality { get; set; }
    }
}