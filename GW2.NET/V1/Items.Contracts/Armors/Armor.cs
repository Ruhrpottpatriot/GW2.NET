// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor piece.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts.Armors
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Contracts.Common;
    using GW2DotNET.V1.Items.Contracts.Common.Attributes;
    using GW2DotNET.V1.Skins.Contracts;

    using Newtonsoft.Json;

    /// <summary>Represents an armor piece.</summary>
    [TypeDiscriminator(Value = "Armor", BaseType = typeof(Item))]
    public abstract class Armor : Item, IUpgrade, IUpgradable, ISkinnable
    {
        /// <summary>Gets or sets the item's attributes.</summary>
        [DataMember(Name = "attributes")]
        public virtual ItemAttributeCollection Attributes { get; set; }

        /// <summary>Gets or sets the item's buff.</summary>
        [DataMember(Name = "buff")]
        public virtual ItemBuff Buff { get; set; }

        /// <summary>Gets or sets the item's default skin.</summary>
        [DataMember(Name = "default_skin")]
        [JsonConverter(typeof(UnknownSkinConverter))]
        public virtual Skin DefaultSkin { get; set; }

        /// <summary>Gets or sets the armor's defense stat.</summary>
        [DataMember(Name = "defense")]
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        [DataMember(Name = "infusion_slots")]
        public virtual InfusionSlotCollection InfusionSlots { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item.</summary>
        [DataMember(Name = "secondary_suffix_item_id")]
        [JsonConverter(typeof(UnknownItemConverter))]
        public virtual Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item.</summary>
        [DataMember(Name = "suffix_item_id")]
        [JsonConverter(typeof(UnknownItemConverter))]
        public virtual Item SuffixItem { get; set; }

        /// <summary>Gets or sets the armor's weight class.</summary>
        [DataMember(Name = "weight_class")]
        public virtual ArmorWeightClass WeightClass { get; set; }
    }
}