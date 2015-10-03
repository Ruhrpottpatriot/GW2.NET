// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRarity.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates known item rarities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    /// <summary>Enumerates known item rarities.</summary>
    public enum ItemRarity
    {
        /// <summary>The 'Unknown' item rarity.</summary>
        Unknown = 0,

        /// <summary>The 'Junk' item rarity.</summary>
        Junk = 1 << 0,

        /// <summary>The 'Basic' item rarity.</summary>
        Basic = 1 << 1,

        /// <summary>The 'Fine' item rarity.</summary>
        Fine = 1 << 2,

        /// <summary>The 'Masterwork' item rarity.</summary>
        Masterwork = 1 << 3,

        /// <summary>The 'Rare' item rarity.</summary>
        Rare = 1 << 4,

        /// <summary>The 'Exotic' item rarity.</summary>
        Exotic = 1 << 5,

        /// <summary>The 'Ascended' item rarity.</summary>
        Ascended = 1 << 6,

        /// <summary>The 'Legendary' item rarity.</summary>
        Legendary = 1 << 7
    }
}