// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRarity.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Common
{
    /// <summary>
    /// Enumerates the possible item rarities.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemRarity
    {
        /// <summary>The 'Junk' item rarity.</summary>
        [EnumMember(Value = "Junk")]
        Junk = 1 << 0,

        /// <summary>The 'Basic' item rarity.</summary>
        [EnumMember(Value = "Basic")]
        Basic = 1 << 1,

        /// <summary>The 'Fine' item rarity.</summary>
        [EnumMember(Value = "Fine")]
        Fine = 1 << 2,

        /// <summary>The 'Masterwork' item rarity.</summary>
        [EnumMember(Value = "Masterwork")]
        Masterwork = 1 << 3,

        /// <summary>The 'Rare' item rarity.</summary>
        [EnumMember(Value = "Rare")]
        Rare = 1 << 4,

        /// <summary>The 'Exotic' item rarity.</summary>
        [EnumMember(Value = "Exotic")]
        Exotic = 1 << 5,

        /// <summary>The 'Ascended' item rarity.</summary>
        [EnumMember(Value = "Ascended")]
        Ascended = 1 << 6,

        /// <summary>The 'Legendary' item rarity.</summary>
        [EnumMember(Value = "Legendary")]
        Legendary = 1 << 7
    }
}