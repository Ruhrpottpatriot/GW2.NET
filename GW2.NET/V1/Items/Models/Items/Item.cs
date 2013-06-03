// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Item type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models.Items
{
    using GW2DotNET.V1.Items.Models.Items.SubType;

    using Newtonsoft.Json;

    public struct Item
    {
        private readonly int id;

        [JsonConstructor]
        public Item(IEnumerable<Restriction> restrictions, IEnumerable<ItemFlags> flags, IEnumerable<GameType> gameTypes, int vendorValue, WeaponRarity rarity, int level, ItemType type, string description, string name, int id, Weapon? weaponDetails, UpgradeComponent? upgradeComponentDetails, Trophy? trophyDetails, Trinket? trinketDetails, Tool? toolDetails, Gizmo? gizmoDetails, Tool? gatheringDetails, CraftingMaterial? craftingMaterialDetails, Container? containerDetails, Consumable? consumableDetails, Bag? bagDetails, Back? backDetails, Armour? armourDetails)
            : this()
        {
            this.Name = name;
            this.id = id;
            this.ArmourDetails = armourDetails;
            this.BackDetails = backDetails;
            this.BagDetails = bagDetails;
            this.ConsumableDetails = consumableDetails;
            this.ContainerDetails = containerDetails;
            this.CraftingMaterialDetails = craftingMaterialDetails;
            this.GatheringDetails = gatheringDetails;
            this.GizmoDetails = gizmoDetails;
            this.ToolDetails = toolDetails;
            this.TrinketDetails = trinketDetails;
            this.TrophyDetails = trophyDetails;
            this.UpgradeComponentDetails = upgradeComponentDetails;
            this.WeaponDetails = weaponDetails;
            this.Description = description;
            this.Type = type;
            this.Level = level;
            this.Rarity = rarity;
            this.VendorValue = vendorValue;
            this.GameTypes = gameTypes;
            this.Flags = flags;
            this.Restrictions = restrictions;
        }

        [JsonProperty("item_id")]
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            private set;
        }

        [JsonProperty("description")]
        public string Description
        {
            get;
            private set;
        }
        [JsonProperty("type")]
        public ItemType Type
        {
            get;
            private set;
        }

        [JsonProperty("level")]
        public int Level
        {
            get;
            private set;
        }

        [JsonProperty("rarity")]
        public WeaponRarity Rarity
        {
            get;
            private set;
        }

        [JsonProperty("vendor_value")]
        public int VendorValue
        {
            get;
            private set;
        }

        [JsonProperty("game_types")]
        public IEnumerable<GameType> GameTypes
        {
            get;
            private set;
        }

        [JsonProperty("flags")]
        public IEnumerable<ItemFlags> Flags
        {
            get;
            private set;
        }

        [JsonProperty("restrictions")]
        public IEnumerable<Restriction> Restrictions
        {
            get;
            private set;
        }

        [JsonProperty("weapon")]
        public Weapon? WeaponDetails { get; private set; }

        [JsonProperty("upgrade_component")]
        public UpgradeComponent? UpgradeComponentDetails { get; private set; }

        [JsonProperty("trophy")]
        public Trophy? TrophyDetails { get; private set; }

        [JsonProperty("trinket")]
        public Trinket? TrinketDetails { get; private set; }

        [JsonProperty("tool")]
        public Tool? ToolDetails { get; private set; }

        [JsonProperty("gizmo")]
        public Gizmo? GizmoDetails { get; private set; }

        [JsonProperty("gathering")]
        public Tool? GatheringDetails { get; private set; }

        [JsonProperty("crafting_material")]
        public CraftingMaterial? CraftingMaterialDetails { get; private set; }

        [JsonProperty("container")]
        public Container? ContainerDetails { get; private set; }

        [JsonProperty("consumable")]
        public Consumable? ConsumableDetails { get; private set; }

        [JsonProperty("bag")]
        public Bag? BagDetails { get; private set; }

        [JsonProperty("back")]
        public Back? BackDetails { get; private set; }

        [JsonProperty("armor")]
        public Armour? ArmourDetails { get; private set; }
    }
}
