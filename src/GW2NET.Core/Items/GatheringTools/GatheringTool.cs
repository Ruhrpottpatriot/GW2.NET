// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for gathering tool types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items.GatheringTools
{
    using Common;
    using Skins;

    /// <summary>Provides the base class for gathering tool types.</summary>
    public abstract class GatheringTool : Item, ISkinnable
    {
        /// <summary>Gets or sets the default skin. This is a navigation property. Use the value of <see cref="DefaultSkinId"/> to obtain a reference.</summary>
        public virtual Skin DefaultSkin { get; set; }

        /// <summary>Gets or sets the default skin identifier.</summary>
        public virtual int DefaultSkinId { get; set; }
    }
}