// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a trinket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents a trinket.</summary>
    [JsonConverter(typeof(TrinketConverter))]
    public abstract class Trinket : Item, IUpgrade, IUpgradable
    {
        /// <summary>Initializes a new instance of the <see cref="Trinket"/> class.</summary>
        /// <param name="trinketType">The trinket's type.</param>
        protected Trinket(TrinketType trinketType)
            : base(ItemType.Trinket, "trinket")
        {
            this.TrinketType = trinketType;
        }

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

        /// <summary>Gets or sets the trinket's type.</summary>
        [DataMember(Name = "trinket_type", Order = 100)]
        protected TrinketType TrinketType { get; set; }
    }
}