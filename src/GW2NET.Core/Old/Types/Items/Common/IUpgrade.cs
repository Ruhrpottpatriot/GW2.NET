// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpgrade.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for items that provide combat bonuses while equipped.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items.Common
{
    using System;

    /// <summary>Provides the interface for items that provide combat bonuses while equipped.</summary>
    public interface IUpgrade
    {
        /// <summary>Gets or sets the item's infixed combat upgrades.</summary>
        /// <exception cref="ArgumentNullException">The value is a null reference.</exception>
        InfixUpgrade InfixUpgrade { get; set; }
    }
}