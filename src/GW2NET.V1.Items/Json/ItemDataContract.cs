// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Items.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    internal sealed class ItemDataContract
    {
        [DataMember(Name = "item_id", Order = 0)]
        internal string ItemId { get; set; }

        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }

        [DataMember(Name = "description", Order = 2)]
        internal string Description { get; set; }

        [DataMember(Name = "type", Order = 3)]
        internal string Type { get; set; }

        [DataMember(Name = "level", Order = 4)]
        internal string Level { get; set; }

        [DataMember(Name = "rarity", Order = 5)]
        internal string Rarity { get; set; }

        [DataMember(Name = "vendor_value", Order = 6)]
        internal string VendorValue { get; set; }

        [DataMember(Name = "icon_file_id", Order = 7)]
        internal string IconFileId { get; set; }

        [DataMember(Name = "icon_file_signature", Order = 8)]
        internal string IconFileSignature { get; set; }

        [DataMember(Name = "default_skin", Order = 9)]
        internal string DefaultSkin { get; set; }

        [DataMember(Name = "game_types", Order = 10)]
        internal string[] GameTypes { get; set; }

        [DataMember(Name = "flags", Order = 11)]
        internal string[] Flags { get; set; }

        [DataMember(Name = "restrictions", Order = 12)]
        internal ICollection<string> Restrictions { get; set; }

        [DataMember(Name = "armor", Order = 13)]
        internal ArmorDataContract Armor { get; set; }

        [DataMember(Name = "back", Order = 14)]
        internal BackpackDataContract Backpack { get; set; }

        [DataMember(Name = "bag", Order = 15)]
        internal BagDataContract Bag { get; set; }

        [DataMember(Name = "consumable", Order = 16)]
        internal ConsumableDataContract Consumable { get; set; }

        [DataMember(Name = "container", Order = 17)]
        internal ContainerDataContract Container { get; set; }

        [DataMember(Name = "gathering", Order = 18)]
        internal GatheringToolDataContract GatheringTool { get; set; }

        [DataMember(Name = "gizmo", Order = 19)]
        internal GizmoDataContract Gizmo { get; set; }

        [DataMember(Name = "tool", Order = 20)]
        internal ToolDataContract Tool { get; set; }

        [DataMember(Name = "trinket", Order = 21)]
        internal TrinketDataContract Trinket { get; set; }

        [DataMember(Name = "upgrade_component", Order = 22)]
        internal UpgradeComponentDataContract UpgradeComponent { get; set; }

        [DataMember(Name = "weapon", Order = 23)]
        internal WeaponDataContract Weapon { get; set; }
    }
}