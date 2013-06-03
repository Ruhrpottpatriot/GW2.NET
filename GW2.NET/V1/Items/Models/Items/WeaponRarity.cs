// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponRarity.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   TEnumerates the wqeapon rarity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>
    /// Enumerates the weapon rarity.
    /// </summary>
    public enum WeaponRarity
    {
        /// <summary>
        /// The item is junk.
        /// </summary>
        Junk,

        /// <summary>
        /// The item is of basic quality.
        /// </summary>
        Basic,

        /// <summary>
        /// The item is of fine quality.
        /// </summary>
        Fine,

        /// <summary>
        /// The item is a masterwork.
        /// </summary>
        Masterwork,

        /// <summary>
        /// The item is of rare quality.
        /// </summary>
        Rare,

        /// <summary>
        /// The item is of exotic quality.
        /// </summary>
        Exotic,

        /// <summary>
        /// The item is an ascended item.
        /// </summary>
        Ascended,

        /// <summary>
        /// The item is a legendary.
        /// </summary>
        Legendary
    }
}