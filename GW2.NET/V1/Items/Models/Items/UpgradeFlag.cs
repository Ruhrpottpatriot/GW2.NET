// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeFlag.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the upgrade flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>
    /// Enumerates the upgrade flags.
    /// </summary>
    public enum UpgradeFlag
    {
        /// <summary>
        /// The item is a defense item.
        /// </summary>
        Defense,

        /// <summary>
        /// The item is a offense item.
        /// </summary>
        Offense,

        /// <summary>
        /// The item is a utility item.
        /// </summary>
        Utility,
    }
}