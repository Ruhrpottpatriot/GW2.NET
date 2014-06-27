// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpgradable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for items that can be upgraded.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Common
{
    /// <summary>Provides the interface for items that can be upgraded.</summary>
    public interface IUpgradable
    {
        /// <summary>Gets or sets the item's infusion slots.</summary>
        InfusionSlotCollection InfusionSlots { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item.</summary>
        Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item.</summary>
        Item SuffixItem { get; set; }
    }
}