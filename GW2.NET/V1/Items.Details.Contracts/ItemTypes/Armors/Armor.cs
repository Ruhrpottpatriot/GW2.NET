// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.Net Coding Team">
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

    /// <summary>Represents an armor piece.</summary>
    [JsonConverter(typeof(ArmorConverter))]
    public abstract class Armor : Item, ISkinnable, IUpgrade, IUpgradable
    {
        /// <summary>Initializes a new instance of the <see cref="Armor"/> class.</summary>
        /// <param name="armorType">The armor type.</param>
        protected Armor(ArmorType armorType)
            : base(ItemType.Armor, "armor")
        {
            this.ArmorType = armorType;
        }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public virtual int DefaultSkin { get; set; }

        /// <summary>Gets or sets the armor's defense stat.</summary>
        [DataMember(Name = "defense")]
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the item's infix upgrade.</summary>
        [DataMember(Name = "infix_upgrade")]
        public virtual InfixUpgrade InfixUpgrade { get; set; }

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
    }
}