// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    public sealed class ItemDTO
    {
        [DataMember(Name = "item_id", Order = 0)]
        public string ItemId { get; set; }

        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "description", Order = 2)]
        public string Description { get; set; }

        [DataMember(Name = "type", Order = 3)]
        public string Type { get; set; }

        [DataMember(Name = "level", Order = 4)]
        public string Level { get; set; }

        [DataMember(Name = "rarity", Order = 5)]
        public string Rarity { get; set; }

        [DataMember(Name = "vendor_value", Order = 6)]
        public string VendorValue { get; set; }

        [DataMember(Name = "icon_file_id", Order = 7)]
        public string IconFileId { get; set; }

        [DataMember(Name = "icon_file_signature", Order = 8)]
        public string IconFileSignature { get; set; }

        [DataMember(Name = "default_skin", Order = 9)]
        public string DefaultSkin { get; set; }

        [DataMember(Name = "game_types", Order = 10)]
        public string[] GameTypes { get; set; }

        [DataMember(Name = "flags", Order = 11)]
        public string[] Flags { get; set; }

        [DataMember(Name = "restrictions", Order = 12)]
        public ICollection<string> Restrictions { get; set; }

        [DataMember(Name = "armor", Order = 13)]
        public ArmorDTO Armor { get; set; }
        [DataMember(Name = "back", Order = 13)]
        public BackpackDTO Backpack { get; set; }

        [DataMember(Name = "bag", Order = 13)]
        public BagDTO Bag { get; set; }

        [DataMember(Name = "consumable", Order = 13)]
        public ConsumableDTO Consumable { get; set; }

        [DataMember(Name = "container", Order = 13)]
        public ContainerDTO Container { get; set; }

        [DataMember(Name = "gathering", Order = 13)]
        public GatheringToolDTO GatheringTool { get; set; }

        [DataMember(Name = "gizmo", Order = 13)]
        public GizmoDTO Gizmo { get; set; }

        [DataMember(Name = "tool", Order = 13)]
        public ToolDTO Tool { get; set; }

        [DataMember(Name = "trinket", Order = 13)]
        public TrinketDTO Trinket { get; set; }

        [DataMember(Name = "upgrade_component", Order = 13)]
        public UpgradeComponentDTO UpgradeComponent { get; set; }

        [DataMember(Name = "weapon", Order = 13)]
        public WeaponDTO Weapon { get; set; }

        [DataMember(Name = "minipet", Order = 13)]
        public MiniPetDTO MiniPet { get; set; }
    }
}