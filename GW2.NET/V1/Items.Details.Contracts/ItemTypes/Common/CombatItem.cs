// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatItem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for types that represent an item that can be used in combat.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Provides the base class for types that represent an item that can be used in combat.</summary>
    public abstract class CombatItem : Item, IUpgrade, IUpgradable
    {
        /// <summary>Backing field.</summary>
        private ItemAttributeCollection attributes;

        /// <summary>Backing field.</summary>
        private ItemBuff buff;

        /// <summary>Backing field.</summary>
        private InfusionSlotCollection infusionSlots;

        /// <summary>Initializes a new instance of the <see cref="CombatItem"/> class.</summary>
        protected CombatItem()
        {
            this.buff = new ItemBuff();
            this.attributes = new ItemAttributeCollection();
            this.infusionSlots = new InfusionSlotCollection();
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

        /// <summary>Gets or sets the item's infusion slots.</summary>
        [DataMember(Name = "infusion_slots")]
        public virtual InfusionSlotCollection InfusionSlots
        {
            get
            {
                return this.infusionSlots;
            }

            set
            {
                this.infusionSlots = value;
            }
        }

        /// <summary>Gets or sets the item's secondary suffix item's ID.</summary>
        [DataMember(Name = "secondary_suffix_item_id")]
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item's ID.</summary>
        [DataMember(Name = "suffix_item_id")]
        public int? SuffixItemId { get; set; }

        /// <summary>Infrastructure. The method that is called immediately after deserialization of the object.</summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            const string Key = "infix_upgrade";
            object infixUpgrade;
            if (this.ExtensionData.TryGetValue(Key, out infixUpgrade) && this.ExtensionData.Remove(Key))
            {
                JsonSerializer.CreateDefault().Populate(((JObject)infixUpgrade).CreateReader(), this);
            }
        }
    }
}