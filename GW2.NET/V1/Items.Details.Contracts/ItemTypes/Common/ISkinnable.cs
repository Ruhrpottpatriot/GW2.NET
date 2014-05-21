// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISkinnable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for items that have a visual appearance in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common
{
    /// <summary>Provides the interface for items that have a visual appearance in the game.</summary>
    public interface ISkinnable
    {
        /// <summary>Gets or sets the item's default skin identifier.</summary>
        int DefaultSkin { get; set; }
    }
}