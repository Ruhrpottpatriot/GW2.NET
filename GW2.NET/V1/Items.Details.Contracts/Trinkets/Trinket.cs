﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a trinket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Trinkets
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Items.Details.Contracts.Common;
    using GW2DotNET.V1.Items.Details.Contracts.Common.Attributes;

    /// <summary>Represents a trinket.</summary>
    [TypeDiscriminator(Value = "Trinket", BaseType = typeof(Item))]
    public abstract class Trinket : Item, IUpgrade, IUpgradable
    {
        /// <summary>Backing field.</summary>
        private ItemAttributeCollection attributes;

        /// <summary>Backing field.</summary>
        private ItemBuff buff;

        /// <summary>Backing field.</summary>
        private InfusionSlotCollection infusionSlots;

        /// <summary>Initializes a new instance of the <see cref="Trinket"/> class.</summary>
        protected Trinket()
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
    }
}