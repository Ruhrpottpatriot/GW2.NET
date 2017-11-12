// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISkinnable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for items that have a visual appearance in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using GW2NET.Skins;

    /// <summary>Provides the interface for items that have a visual appearance in the game.</summary>
    public interface ISkinnable
    {
        /// <summary>Gets or sets the default skin. This is a navigation property. Use the value of <see cref="DefaultSkinId"/> to obtain a reference.</summary>
        Skin DefaultSkin { get; set; }

        /// <summary>Gets or sets the default skin identifier.</summary>
        int DefaultSkinId { get; set; }
    }
}
