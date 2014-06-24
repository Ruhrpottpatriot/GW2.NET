// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Backpack.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a backpack.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Backpacks
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Items.Details.Contracts.Common;

    /// <summary>Represents a backpack.</summary>
    [TypeDiscriminator(Value = "Back", BaseType = typeof(Item))]
    public class Backpack : Item, IUpgrade, IUpgradable, ISkinnable
    {
        /// <summary>Backing field.</summary>
        private ItemAttributeCollection attributes;

        /// <summary>Backing field.</summary>
        private ItemBuff buff;

        /// <summary>Backing field.</summary>
        private InfusionSlotCollection infusionSlots;

        /// <summary>Initializes a new instance of the <see cref="Backpack"/> class.</summary>
        public Backpack()
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

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public virtual int DefaultSkin { get; set; }

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
    }
}