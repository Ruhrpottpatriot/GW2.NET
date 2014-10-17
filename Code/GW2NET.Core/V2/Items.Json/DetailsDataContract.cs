// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The details data contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>The details data contract.</summary>
    [DataContract]
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the item type.</summary>
        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }
    }

    /// <summary>The upgradable item details data contract.</summary>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the armor's defense rating.</summary>
        [DataMember(Name = "defense", Order = 2)]
        internal int? Defense { get; set; }

        /// <summary>Gets or sets the armor's infusion slots.</summary>
        [DataMember(Name = "infusion_slots", Order = 3)]
        internal ICollection<InfusionSlotDataContract> InfusionSlots { get; set; }

        /// <summary>Gets or sets the armor's secondary suffix item.</summary>
        [DataMember(Name = "secondary_suffix_item_id", Order = 6)]
        internal string SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the armor's suffix item.</summary>
        [DataMember(Name = "suffix_item_id", Order = 5)]
        internal int? SuffixItemId { get; set; }
    }

    /// <summary>The upgrade item details data contract.</summary>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the armor's infixed upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 4)]
        internal InfixUpgradeDataContract InfixUpgrade { get; set; }
    }

    /// <summary>The armor details data contract.</summary>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the armor's weight class.</summary>
        [DataMember(Name = "weight_class", Order = 1)]
        internal string WeightClass { get; set; }
    }

    /// <summary>The bag details data contract.</summary>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets a value indicating whether this is an invisible bag.</summary>
        [DataMember(Name = "no_sell_or_sort", Order = 0)]
        internal bool? NoSellOrSort { get; set; }

        /// <summary>Gets or sets the bag's capacity.</summary>
        [DataMember(Name = "size", Order = 1)]
        internal int? Size { get; set; }
    }

    /// <summary>The consumable details data contract.</summary>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the unlocked color identifier.</summary>
        [DataMember(Name = "color_id", Order = 2)]
        internal int? ColorId { get; set; }

        /// <summary>Gets or sets the consumable's effect description.</summary>
        [DataMember(Name = "description", Order = 3)]
        internal string Description { get; set; }

        /// <summary>Gets or sets the consumable's effect duration.</summary>
        [DataMember(Name = "duration_ms", Order = 2)]
        internal double? Duration { get; set; }

        /// <summary>Gets or sets the unlocked recipe identifier.</summary>
        [DataMember(Name = "recipe_id", Order = 2)]
        internal int? RecipeId { get; set; }

        /// <summary>Gets or sets the unlock type.</summary>
        [DataMember(Name = "unlock_type", Order = 1)]
        internal string UnlockType { get; set; }
    }

    /// <summary>The tool details data contract.</summary>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the number of charges.</summary>
        [DataMember(Name = "charges", Order = 1)]
        internal int? Charges { get; set; }
    }

    /// <summary>The upgrade component details data contract.</summary>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the upgrade component's bonuses.</summary>
        [DataMember(Name = "bonuses", Order = 3)]
        internal ICollection<string> Bonuses { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        [DataMember(Name = "flags", Order = 1)]
        internal ICollection<string> Flags { get; set; }

        /// <summary>Gets or sets the upgrade component's infusion upgrades.</summary>
        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        internal ICollection<string> InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        [DataMember(Name = "suffix", Order = 5)]
        internal string Suffix { get; set; }
    }

    /// <summary>The weapon details data contract.</summary>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the weapon's damage type.</summary>
        [DataMember(Name = "damage_type", Order = 1)]
        internal string DamageType { get; set; }

        /// <summary>Gets or sets the weapon's maximum power rating.</summary>
        [DataMember(Name = "max_power", Order = 3)]
        internal int? MaximumPower { get; set; }

        /// <summary>Gets or sets the weapon's minimum power rating.</summary>
        [DataMember(Name = "min_power", Order = 2)]
        internal int? MinimumPower { get; set; }
    }
}