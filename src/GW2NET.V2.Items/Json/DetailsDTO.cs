// <copyright file="DetailsDTO.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for all items.</content>
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        /// <summary>Gets or sets the type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for upgradable items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "defense", Order = 2)]
        public int? Defense { get; set; }

        [DataMember(Name = "infusion_slots", Order = 3)]
        public ICollection<InfusionSlotDTO> InfusionSlots { get; set; }

        [DataMember(Name = "secondary_suffix_item_id", Order = 6)]
        public string SecondarySuffixItemId { get; set; }

        [DataMember(Name = "suffix_item_id", Order = 5)]
        public int? SuffixItemId { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for upgrade items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "infix_upgrade", Order = 4)]
        public InfixUpgradeDTO InfixUpgrade { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for armor items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "weight_class", Order = 1)]
        public string WeightClass { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for bag items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "no_sell_or_sort", Order = 0)]
        public bool? NoSellOrSort { get; set; }

        [DataMember(Name = "size", Order = 1)]
        public int? Size { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for consumable items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "color_id", Order = 2)]
        public int? ColorId { get; set; }

        [DataMember(Name = "description", Order = 3)]
        public string Description { get; set; }

        [DataMember(Name = "duration_ms", Order = 2)]
        public double? Duration { get; set; }

        [DataMember(Name = "recipe_id", Order = 2)]
        public int? RecipeId { get; set; }

        [DataMember(Name = "unlock_type", Order = 1)]
        public string UnlockType { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for tool items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "charges", Order = 1)]
        public int? Charges { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for upgrade component items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "bonuses", Order = 3)]
        public ICollection<string> Bonuses { get; set; }

        [DataMember(Name = "flags", Order = 1)]
        public ICollection<string> Flags { get; set; }

        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        public ICollection<string> InfusionUpgradeFlags { get; set; }

        [DataMember(Name = "suffix", Order = 5)]
        public string Suffix { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO" /> type.</summary>
    /// <content>Contains data contract properties for weapon items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "damage_type", Order = 1)]
        public string DamageType { get; set; }

        [DataMember(Name = "max_power", Order = 3)]
        public int? MaximumPower { get; set; }

        [DataMember(Name = "min_power", Order = 2)]
        public int? MinimumPower { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO"/> type.</summary>
    /// <content>Contains data contract properties for transmutation items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "skins", Order = 1)]
        public int[] Skins { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDTO"/> type.</summary>
    /// <content>Contains data contract properties for miniature items.</content>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed partial class DetailsDTO
    {
        [DataMember(Name = "minipet_id", Order = 1)]
        public int MiniPetId { get; set; }
    }
}