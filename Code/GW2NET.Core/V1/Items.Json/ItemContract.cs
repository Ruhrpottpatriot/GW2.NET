// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents an item.</summary>
    [DataContract]
    public sealed class ItemContract
    {
        /// <summary>Gets or sets the armor details.</summary>
        [DataMember(Name = "armor", Order = 11)]
        public ArmorContract Armor { get; set; }

        /// <summary>Gets or sets the backpack details.</summary>
        [DataMember(Name = "back", Order = 12)]
        public BackpackContract Backpack { get; set; }

        /// <summary>Gets or sets the bag details.</summary>
        [DataMember(Name = "bag", Order = 13)]
        public BagContract Bag { get; set; }

        /// <summary>Gets or sets the consumable details.</summary>
        [DataMember(Name = "consumable", Order = 14)]
        public ConsumableContract Consumable { get; set; }

        /// <summary>Gets or sets the container details.</summary>
        [DataMember(Name = "container", Order = 15)]
        public ContainerContract Container { get; set; }

        /// <summary>Gets or sets the item's default skin.</summary>
        [DataMember(Name = "default_skin", Order = 9)]
        public string DefaultSkin { get; set; }

        /// <summary>Gets or sets the item description.</summary>
        [DataMember(Name = "description", Order = 2)]
        public string Description { get; set; }

        /// <summary>Gets or sets the item's additional flags.</summary>
        [DataMember(Name = "flags", Order = 11)]
        public string[] Flags { get; set; }

        /// <summary>Gets or sets the item's game types.</summary>
        [DataMember(Name = "game_types", Order = 10)]
        public string[] GameTypes { get; set; }

        /// <summary>Gets or sets the gathering tool details.</summary>
        [DataMember(Name = "gathering", Order = 16)]
        public GatheringToolContract GatheringTool { get; set; }

        /// <summary>Gets or sets the gizmo details.</summary>
        [DataMember(Name = "gizmo", Order = 17)]
        public GizmoContract Gizmo { get; set; }

        /// <summary>Gets or sets the item's icon identifier for use with the render service.</summary>
        [DataMember(Name = "icon_file_id", Order = 7)]
        public string IconFileId { get; set; }

        /// <summary>Gets or sets the item's icon signature for use with the render service.</summary>
        [DataMember(Name = "icon_file_signature", Order = 8)]
        public string IconFileSignature { get; set; }

        /// <summary>Gets or sets the item identifier.</summary>
        [DataMember(Name = "item_id", Order = 0)]
        public string ItemId { get; set; }

        /// <summary>Gets or sets the item level.</summary>
        [DataMember(Name = "level", Order = 4)]
        public string Level { get; set; }

        /// <summary>Gets or sets the name of the item.</summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets the item's rarity.</summary>
        [DataMember(Name = "rarity", Order = 5)]
        public string Rarity { get; set; }

        /// <summary>Gets or sets the item's restrictions.</summary>
        [DataMember(Name = "restrictions")]
        public ICollection<string> Restrictions { get; set; }

        /// <summary>Gets or sets the tool details.</summary>
        [DataMember(Name = "tool", Order = 18)]
        public ToolContract Tool { get; set; }

        /// <summary>Gets or sets the trinket details.</summary>
        [DataMember(Name = "trinket", Order = 19)]
        public TrinketContract Trinket { get; set; }

        /// <summary>Gets or sets the item type.</summary>
        [DataMember(Name = "type", Order = 3)]
        public string Type { get; set; }

        /// <summary>Gets or sets the upgrade component details.</summary>
        [DataMember(Name = "upgrade_component", Order = 20)]
        public UpgradeComponentContract UpgradeComponent { get; set; }

        /// <summary>Gets or sets the item's vendor value.</summary>
        [DataMember(Name = "vendor_value", Order = 6)]
        public string VendorValue { get; set; }

        /// <summary>Gets or sets the weapon details.</summary>
        [DataMember(Name = "weapon", Order = 21)]
        public WeaponContract Weapon { get; set; }
    }
}