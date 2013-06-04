// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemFlags.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible item flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>
    /// Enumerates the possible item flags.
    /// </summary>
    public enum ItemFlags
    {
        /// <summary>
        /// Cannot be sold at a vendor.
        /// </summary>
        NoSell,

        /// <summary>
        /// Item is soulbound on acquire.
        /// </summary>
        SoulbindOnAcquire,

        /// <summary>
        /// Account Bound
        /// </summary>
        AccountBound,

        /// <summary>
        /// Cannot be Salvaged
        /// </summary>
        NoSalvage,

        /// <summary>
        /// Cannot be Upgraded
        /// </summary>
        NotUpgradeable,

        /// <summary>
        /// The unique.
        /// </summary>
        Unique,

        /// <summary>
        /// Cannot be used in the Mystic Forge
        /// </summary>
        NoMysticForge,

        /// <summary>
        ///  Hide the item's suffix
        /// </summary>
        HideSuffix,

        /// <summary>
        /// Soulbind on Use or Equip
        /// </summary>
        SoulBindOnUse,

        /// <summary>
        /// Cannot be used underwater
        /// </summary>
        NoUnderwater,
    }
}