// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpgradable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for items that can be upgraded.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for items that can be upgraded.</summary>
    public interface IUpgradable
    {
        /// <summary>Gets or sets the item's infusion slots.</summary>
        ICollection<InfusionSlot> InfusionSlots { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item. This is a navigation property. Use the value of <see cref="SecondarySuffixItemId"/> to obtain a reference.</summary>
        Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item identifier.</summary>
        int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item. This is a navigation property. Use the value of <see cref="SuffixItemId"/> to obtain a reference.</summary>
        Item SuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item identifier.</summary>
        int? SuffixItemId { get; set; }
    }
}
