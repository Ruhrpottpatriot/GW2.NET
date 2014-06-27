// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Weapons
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.Common;
    using GW2DotNET.V1.Items.Details.Contracts.Common.Attributes;

    using Newtonsoft.Json;

    /// <summary>Represents a weapon.</summary>
    [TypeDiscriminator(Value = "Weapon", BaseType = typeof(Item))]
    public abstract class Weapon : Item, IUpgradable, IUpgrade, ISkinnable
    {
        /// <summary>Gets or sets the item's attributes.</summary>
        [DataMember(Name = "attributes")]
        public virtual ItemAttributeCollection Attributes { get; set; }

        /// <summary>Gets or sets the item's buff.</summary>
        [DataMember(Name = "buff")]
        public virtual ItemBuff Buff { get; set; }

        /// <summary>Gets or sets the weapon's damage type.</summary>
        [DataMember(Name = "damage_type")]
        public virtual WeaponDamageType DamageType { get; set; }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public virtual int DefaultSkin { get; set; }

        /// <summary>Gets or sets the weapon's defense.</summary>
        [DataMember(Name = "defense")]
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        [DataMember(Name = "infusion_slots")]
        public virtual InfusionSlotCollection InfusionSlots { get; set; }

        /// <summary>Gets or sets the weapon's maximum power.</summary>
        [DataMember(Name = "max_power")]
        public virtual int MaximumPower { get; set; }

        /// <summary>Gets or sets the weapon's minimum power.</summary>
        [DataMember(Name = "min_power")]
        public virtual int MinimumPower { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item.</summary>
        [DataMember(Name = "secondary_suffix_item_id")]
        [JsonConverter(typeof(UnknownItemConverter))]
        public virtual Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item.</summary>
        [DataMember(Name = "suffix_item_id")]
        [JsonConverter(typeof(UnknownItemConverter))]
        public virtual Item SuffixItem { get; set; }
    }
}