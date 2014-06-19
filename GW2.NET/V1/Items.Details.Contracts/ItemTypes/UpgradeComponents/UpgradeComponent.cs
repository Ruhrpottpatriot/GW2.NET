// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Represents an upgrade component.</summary>
    [JsonConverter(typeof(UpgradeComponentConverter))]
    public abstract class UpgradeComponent : Item, IUpgrade
    {
        /// <summary>Backing field.</summary>
        private ItemAttributeCollection attributes;

        /// <summary>Backing field.</summary>
        private ItemBuff buff;

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponent"/> class.</summary>
        /// <param name="upgradeComponentType">The upgrade component's type.</param>
        protected UpgradeComponent(UpgradeComponentType upgradeComponentType)
            : base(ItemType.UpgradeComponent)
        {
            this.UpgradeComponentType = upgradeComponentType;
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
        [DataMember(Name = "bonuses", Order = 103)]
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
        [DataMember(Name = "infusion_upgrade_flags", Order = 102)]
        public virtual InfusionSlotTypes InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        [DataMember(Name = "suffix", Order = 105)]
        public virtual string Suffix { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        [DataMember(Name = "upgrade_component_flags", Order = 101)]
        public virtual UpgradeComponentFlags UpgradeComponentFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's type.</summary>
        [DataMember(Name = "upgrade_component_type", Order = 100)]
        protected UpgradeComponentType UpgradeComponentType { get; set; }

        /// <summary>Gets the name of the property that provides additional information.</summary>
        /// <returns>The name of the property.</returns>
        protected override string GetTypeKey()
        {
            return "upgrade_component";
        }

        /// <summary>Infrastructure. The method that is called immediately after deserialization of the object.</summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserialized]
        protected new void OnDeserialized(StreamingContext context)
        {
            base.OnDeserialized(context);
            const string Key = "infix_upgrade";
            object infixUpgrade;
            if (this.ExtensionData.TryGetValue(Key, out infixUpgrade) && this.ExtensionData.Remove(Key))
            {
                JsonSerializer.CreateDefault().Populate(((JObject)infixUpgrade).CreateReader(), this);
            }
        }
    }
}