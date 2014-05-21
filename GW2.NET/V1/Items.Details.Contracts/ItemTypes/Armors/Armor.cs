// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor piece.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Represents an armor piece.</summary>
    [JsonConverter(typeof(ArmorConverter))]
    public abstract class Armor : Item, ISkinnable, IUpgrade, IUpgradable
    {
        /// <summary>Backing field.</summary>
        private ItemAttributeCollection attributes;

        /// <summary>Backing field.</summary>
        private ItemBuff buff;

        /// <summary>Initializes a new instance of the <see cref="Armor"/> class.</summary>
        /// <param name="armorType">The armor type.</param>
        protected Armor(ArmorType armorType)
            : base(ItemType.Armor, "armor")
        {
            this.ArmorType = armorType;
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

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public virtual int DefaultSkin { get; set; }

        /// <summary>Gets or sets the armor's defense stat.</summary>
        [DataMember(Name = "defense")]
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        [DataMember(Name = "infusion_slots")]
        public virtual InfusionSlotCollection InfusionSlots { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item's ID.</summary>
        [DataMember(Name = "secondary_suffix_item_id")]
        public virtual int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item's ID.</summary>
        [DataMember(Name = "suffix_item_id")]
        public virtual int? SuffixItemId { get; set; }

        /// <summary>Gets or sets the armor's weight class.</summary>
        [DataMember(Name = "weight_class")]
        public virtual ArmorWeightClass WeightClass { get; set; }

        /// <summary>Gets or sets the armor's type.</summary>
        [DataMember(Name = "armor_type")]
        protected ArmorType ArmorType { get; set; }

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