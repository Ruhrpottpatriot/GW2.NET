// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpgrade.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for items that provide a bonus when equipped.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common
{
    /// <summary>Provides the interface for items that provide a bonus when equipped.</summary>
    public interface IUpgrade
    {
        /// <summary>Gets or sets the item's infix upgrade.</summary>
        InfixUpgrade InfixUpgrade { get; set; }
    }
}