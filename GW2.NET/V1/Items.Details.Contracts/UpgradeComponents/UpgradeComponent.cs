// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.UpgradeComponents
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Items.Details.Contracts.Common;
    using GW2DotNET.V1.Items.Details.Contracts.Common.Attributes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Represents an upgrade component.</summary>
    [TypeDiscriminator(Value = "UpgradeComponent", BaseType = typeof(Item))]
    public abstract class UpgradeComponent : Item, IUpgrade
    {
        /// <summary>Backing field.</summary>
        private ItemAttributeCollection attributes;

        /// <summary>Backing field.</summary>
        private ItemBuff buff;

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponent"/> class.</summary>
        protected UpgradeComponent()
        {
            this.buff = new ItemBuff();
            this.attributes = new ItemAttributeCollection();
        }

        /// <summary>Gets or sets the item's attributes.</summary>
        [DataMember(Name = "attributes")]
        public virtual ItemAttributeCollection Attributes
        {
            get
            {
                return this.attributes;
            }

            set
            {
                this.attributes = value;
            }
        }

        /// <summary>Gets or sets the upgrade component's bonuses.</summary>
        [DataMember(Name = "bonuses")]
        public virtual UpgradeBonusCollection Bonuses { get; set; }

        /// <summary>Gets or sets the item's buff.</summary>
        [DataMember(Name = "buff")]
        public virtual ItemBuff Buff
        {
            get
            {
                return this.buff;
            }

            set
            {
                this.buff = value;
            }
        }

        /// <summary>Gets or sets the upgrade component's infusion upgrades.</summary>
        [DataMember(Name = "infusion_upgrade_flags")]
        public virtual InfusionSlotTypes InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        [DataMember(Name = "suffix")]
        public virtual string Suffix { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        [DataMember(Name = "upgrade_component_flags")]
        public virtual UpgradeComponentFlags UpgradeComponentFlags { get; set; }
    }
}