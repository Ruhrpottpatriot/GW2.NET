// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class ItemContract
    {
        [DataMember(Name = "armor", Order = 11)]
        internal ArmorContract Armor { get; set; }

        [DataMember(Name = "back", Order = 12)]
        internal BackpackContract Backpack { get; set; }

        [DataMember(Name = "bag", Order = 13)]
        internal BagContract Bag { get; set; }

        [DataMember(Name = "consumable", Order = 14)]
        internal ConsumableContract Consumable { get; set; }

        [DataMember(Name = "container", Order = 15)]
        internal ContainerContract Container { get; set; }

        [DataMember(Name = "default_skin", Order = 9)]
        internal string DefaultSkin { get; set; }

        [DataMember(Name = "description", Order = 2)]
        internal string Description { get; set; }

        [DataMember(Name = "flags", Order = 11)]
        internal string[] Flags { get; set; }

        [DataMember(Name = "game_types", Order = 10)]
        internal string[] GameTypes { get; set; }

        [DataMember(Name = "gathering", Order = 16)]
        internal GatheringToolContract GatheringTool { get; set; }

        [DataMember(Name = "gizmo", Order = 17)]
        internal GizmoContract Gizmo { get; set; }

        [DataMember(Name = "icon_file_id", Order = 7)]
        internal string IconFileId { get; set; }

        [DataMember(Name = "icon_file_signature", Order = 8)]
        internal string IconFileSignature { get; set; }

        [DataMember(Name = "item_id", Order = 0)]
        internal string ItemId { get; set; }

        [DataMember(Name = "level", Order = 4)]
        internal string Level { get; set; }

        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }

        [DataMember(Name = "rarity", Order = 5)]
        internal string Rarity { get; set; }

        [DataMember(Name = "restrictions")]
        internal ICollection<string> Restrictions { get; set; }

        [DataMember(Name = "tool", Order = 18)]
        internal ToolContract Tool { get; set; }

        [DataMember(Name = "trinket", Order = 19)]
        internal TrinketContract Trinket { get; set; }

        [DataMember(Name = "type", Order = 3)]
        internal string Type { get; set; }

        [DataMember(Name = "upgrade_component", Order = 20)]
        internal UpgradeComponentContract UpgradeComponent { get; set; }

        [DataMember(Name = "vendor_value", Order = 6)]
        internal string VendorValue { get; set; }

        [DataMember(Name = "weapon", Order = 21)]
        internal WeaponContract Weapon { get; set; }
    }
}