// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible types of unlock consumables.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible types of unlock consumables.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnlockType
    {
        /// <summary>The 'Unknown' unlock type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Bag Slot' unlock type.</summary>
        [EnumMember(Value = "BagSlot")]
        BagSlot = 1 << 0, 

        /// <summary>The 'Bank Tab' unlock type.</summary>
        [EnumMember(Value = "BankTab")]
        BankTab = 1 << 1, 

        /// <summary>The 'Crafting Recipe' unlock type.</summary>
        [EnumMember(Value = "CraftingRecipe")]
        CraftingRecipe = 1 << 2, 

        /// <summary>The 'Dye' unlock type.</summary>
        [EnumMember(Value = "Dye")]
        Dye = 1 << 3, 

        /// <summary>The 'Content' unlock type.</summary>
        [EnumMember(Value = "Content")]
        Content = 1 << 4, 

        /// <summary>The 'Collectible Capacity' unlock type.</summary>
        [EnumMember(Value = "CollectibleCapacity")]
        CollectibleCapacity = 1 << 5
    }
}