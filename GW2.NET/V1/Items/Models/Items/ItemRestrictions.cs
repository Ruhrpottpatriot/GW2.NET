// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRestrictions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Restriction type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>
    /// Enumerates all possible item restrictions.
    /// </summary>
    public enum ItemRestrictions
    {
        /// <summary>
        /// The item is for asura only.
        /// </summary>
        Asura,

        /// <summary>
        /// The item is for humans only.
        /// </summary>
        Human,

        /// <summary>
        /// The item is for charr only.
        /// </summary>
        Charr,

        /// <summary>
        /// The item is for norn only.
        /// </summary>
        Norn,

        /// <summary>
        /// The item is for sylvari only.
        /// </summary>
        Sylvari,

        /// <summary>
        /// The item is for guardians only.
        /// </summary>
        Guardian,

        /// <summary>
        /// The item is for warriors only.
        /// </summary>
        Warrior,
    }
}