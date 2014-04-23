// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible item types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible item types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemType
    {
        /// <summary>The 'Unknown' item type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Armor' item type.</summary>
        [EnumMember(Value = "Armor")]
        Armor = 1 << 0, 

        /// <summary>The 'Back' item type.</summary>
        [EnumMember(Value = "Back")]
        Back = 1 << 1, 

        /// <summary>The 'Bag' item type.</summary>
        [EnumMember(Value = "Bag")]
        Bag = 1 << 2, 

        /// <summary>The 'Consumable' item type.</summary>
        [EnumMember(Value = "Consumable")]
        Consumable = 1 << 3, 

        /// <summary>The 'Container' item type.</summary>
        [EnumMember(Value = "Container")]
        Container = 1 << 4, 

        /// <summary>The 'Crafting Material' item type.</summary>
        [EnumMember(Value = "CraftingMaterial")]
        CraftingMaterial = 1 << 5, 

        /// <summary>The 'Gathering' item type.</summary>
        [EnumMember(Value = "Gathering")]
        Gathering = 1 << 6, 

        /// <summary>The 'Gizmo' item type.</summary>
        [EnumMember(Value = "Gizmo")]
        Gizmo = 1 << 7, 

        /// <summary>The 'Mini Pet' item type.</summary>
        [EnumMember(Value = "MiniPet")]
        MiniPet = 1 << 8, 

        /// <summary>The 'Tool' item type.</summary>
        [EnumMember(Value = "Tool")]
        Tool = 1 << 9, 

        /// <summary>The 'Trinket' item type.</summary>
        [EnumMember(Value = "Trinket")]
        Trinket = 1 << 10, 

        /// <summary>The 'Trophy' item type.</summary>
        [EnumMember(Value = "Trophy")]
        Trophy = 1 << 11, 

        /// <summary>The 'Upgrade Component' item type.</summary>
        [EnumMember(Value = "UpgradeComponent")]
        UpgradeComponent = 1 << 12, 

        /// <summary>The 'Weapon' item type.</summary>
        [EnumMember(Value = "Weapon")]
        Weapon = 1 << 13
    }
}