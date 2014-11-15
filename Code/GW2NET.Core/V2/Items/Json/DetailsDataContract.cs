// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the <see cref="DetailsDataContract" /> type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for all items.</content>
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        /// <summary>Gets or sets the type.</summary>
        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }

        #endregion
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for upgradable items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        [DataMember(Name = "defense", Order = 2)]
        internal int? Defense { get; set; }

        [DataMember(Name = "infusion_slots", Order = 3)]
        internal ICollection<InfusionSlotDataContract> InfusionSlots { get; set; }

        [DataMember(Name = "secondary_suffix_item_id", Order = 6)]
        internal string SecondarySuffixItemId { get; set; }

        [DataMember(Name = "suffix_item_id", Order = 5)]
        internal int? SuffixItemId { get; set; }

        #endregion
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for upgrade items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        [DataMember(Name = "infix_upgrade", Order = 4)]
        internal InfixUpgradeDataContract InfixUpgrade { get; set; }

        #endregion
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for armor items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        [DataMember(Name = "weight_class", Order = 1)]
        internal string WeightClass { get; set; }

        #endregion
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for bag items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        [DataMember(Name = "no_sell_or_sort", Order = 0)]
        internal bool? NoSellOrSort { get; set; }

        [DataMember(Name = "size", Order = 1)]
        internal int? Size { get; set; }

        #endregion
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for consumable items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        [DataMember(Name = "color_id", Order = 2)]
        internal int? ColorId { get; set; }

        [DataMember(Name = "description", Order = 3)]
        internal string Description { get; set; }

        [DataMember(Name = "duration_ms", Order = 2)]
        internal double? Duration { get; set; }

        [DataMember(Name = "recipe_id", Order = 2)]
        internal int? RecipeId { get; set; }

        [DataMember(Name = "unlock_type", Order = 1)]
        internal string UnlockType { get; set; }

        #endregion
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for tool items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        [DataMember(Name = "charges", Order = 1)]
        internal int? Charges { get; set; }

        #endregion
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for upgrade component items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        [DataMember(Name = "bonuses", Order = 3)]
        internal ICollection<string> Bonuses { get; set; }

        [DataMember(Name = "flags", Order = 1)]
        internal ICollection<string> Flags { get; set; }

        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        internal ICollection<string> InfusionUpgradeFlags { get; set; }

        [DataMember(Name = "suffix", Order = 5)]
        internal string Suffix { get; set; }

        #endregion
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content>Contains data contract properties for weapon items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed partial class DetailsDataContract
    {
        #region Properties

        [DataMember(Name = "damage_type", Order = 1)]
        internal string DamageType { get; set; }

        [DataMember(Name = "max_power", Order = 3)]
        internal int? MaximumPower { get; set; }

        [DataMember(Name = "min_power", Order = 2)]
        internal int? MinimumPower { get; set; }

        #endregion
    }
}