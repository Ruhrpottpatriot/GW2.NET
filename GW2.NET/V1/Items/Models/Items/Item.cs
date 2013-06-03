// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Item type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.V1.Items.Models.Items.SubType;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>
    /// The item.
    /// </summary>
    public struct Item
    {
        /// <summary>
        /// The id.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> struct.
        /// </summary>
        /// <param name="restrictions">
        /// The restrictions.
        /// </param>
        /// <param name="flags">
        /// The flags.
        /// </param>
        /// <param name="gameTypes">
        /// The game types.
        /// </param>
        /// <param name="vendorValue">
        /// The vendor value.
        /// </param>
        /// <param name="rarity">
        /// The rarity.
        /// </param>
        /// <param name="level">
        /// The level.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="weaponDetails">
        /// The weapon details.
        /// </param>
        /// <param name="upgradeComponentDetails">
        /// The upgrade component details.
        /// </param>
        /// <param name="trophyDetails">
        /// The trophy details.
        /// </param>
        /// <param name="trinketDetails">
        /// The trinket details.
        /// </param>
        /// <param name="toolDetails">
        /// The tool details.
        /// </param>
        /// <param name="gizmoDetails">
        /// The gizmo details.
        /// </param>
        /// <param name="gatheringDetails">
        /// The gathering details.
        /// </param>
        /// <param name="craftingMaterialDetails">
        /// The crafting material details.
        /// </param>
        /// <param name="containerDetails">
        /// The container details.
        /// </param>
        /// <param name="consumableDetails">
        /// The consumable details.
        /// </param>
        /// <param name="bagDetails">
        /// The bag details.
        /// </param>
        /// <param name="backDetails">
        /// The back details.
        /// </param>
        /// <param name="armourDetails">
        /// The armour details.
        /// </param>
        [JsonConstructor]
        public Item(IEnumerable<Restriction> restrictions, IEnumerable<ItemFlags> flags, IEnumerable<GameType> gameTypes, int vendorValue, WeaponRarity rarity, int level, ItemType type, string description, string name, int id, Weapon? weaponDetails, UpgradeComponent upgradeComponentDetails, Trophy? trophyDetails, Trinket? trinketDetails, Tool? toolDetails, Gizmo? gizmoDetails, Tool? gatheringDetails, CraftingMaterial? craftingMaterialDetails, Container? containerDetails, Consumable? consumableDetails, Bag? bagDetails, Back? backDetails, Armour? armourDetails)
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

        /// <summary>
        /// Gets the id.
        /// </summary>
        [JsonProperty("item_id")]
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [JsonProperty("type")]
        public ItemType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the minimum level to use.
        /// </summary>
        [JsonProperty("level")]
        public int Level
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the rarity.
        /// </summary>
        [JsonProperty("rarity")]
        public WeaponRarity Rarity
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the vendor value.
        /// </summary>
        [JsonProperty("vendor_value")]
        public int VendorValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the game types the item is dropped in.
        /// </summary>
        [JsonProperty("game_types")]
        public IEnumerable<GameType> GameTypes
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the item flags.
        /// </summary>
        [JsonProperty("flags")]
        public IEnumerable<ItemFlags> Flags
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the restrictions.
        /// </summary>
        [JsonProperty("restrictions")]
        public IEnumerable<Restriction> Restrictions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the weapon details.
        /// </summary>
        [JsonProperty("weapon")]
        public Weapon? WeaponDetails { get; private set; }

        /// <summary>
        /// Gets the upgrade component details.
        /// </summary>
        [JsonProperty("upgrade_component")]
        public UpgradeComponent UpgradeComponentDetails { get; private set; }

        /// <summary>
        /// Gets the trophy details.
        /// </summary>
        [JsonProperty("trophy")]
        public Trophy? TrophyDetails { get; private set; }

        /// <summary>
        /// Gets the trinket details.
        /// </summary>
        [JsonProperty("trinket")]
        public Trinket? TrinketDetails { get; private set; }

        /// <summary>
        /// Gets the tool details.
        /// </summary>
        [JsonProperty("tool")]
        public Tool? ToolDetails { get; private set; }

        /// <summary>
        /// Gets the gizmo details.
        /// </summary>
        [JsonProperty("gizmo")]
        public Gizmo? GizmoDetails { get; private set; }

        /// <summary>
        /// Gets the gathering details.
        /// </summary>
        [JsonProperty("gathering")]
        public Tool? GatheringDetails { get; private set; }

        /// <summary>
        /// Gets the crafting material details.
        /// </summary>
        [JsonProperty("crafting_material")]
        public CraftingMaterial? CraftingMaterialDetails { get; private set; }

        /// <summary>
        /// Gets the container details.
        /// </summary>
        [JsonProperty("container")]
        public Container? ContainerDetails { get; private set; }

        /// <summary>
        /// Gets the consumable details.
        /// </summary>
        [JsonProperty("consumable")]
        public Consumable? ConsumableDetails { get; private set; }

        /// <summary>
        /// Gets the bag details.
        /// </summary>
        [JsonProperty("bag")]
        public Bag? BagDetails { get; private set; }

        /// <summary>
        /// Gets the back details.
        /// </summary>
        [JsonProperty("back")]
        public Back? BackDetails { get; private set; }

        /// <summary>
        /// Gets the armour details.
        /// </summary>
        [JsonProperty("armor")]
        public Armour? ArmourDetails { get; private set; }

        /// <summary>
        /// Determines if two instances of the specified <see cref="Item"/> are equal.
        /// </summary>
        /// <param name="itemA">
        /// The first item.
        /// </param>
        /// <param name="itemB">
        /// The second item.
        /// </param>
        /// <returns>
        /// true if the two instances are equal, otherwise false.
        /// </returns>
        public static bool operator ==(Item itemA, Item itemB)
        {
            return itemA.Id == itemB.Id;
        }

        /// <summary>
        /// Determines if two instances of the specified <see cref="Item"/> are not equal.
        /// </summary>
        /// <param name="itemA">
        /// The first item.
        /// </param>
        /// <param name="itemB">
        /// The second item.
        /// </param>
        /// <returns>
        /// true if the two instances are not equal, otherwise false.
        /// </returns>
        public static bool operator !=(Item itemA, Item itemB)
        {
            return itemA.Id != itemB.Id;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param>
        public override bool Equals(object obj)
        {
            return obj is Item && this == (Item)obj;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="Item"/> are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another <see cref="Item"/> to compare to. </param>
        public bool Equals(Item obj)
        {
            return this == obj;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
