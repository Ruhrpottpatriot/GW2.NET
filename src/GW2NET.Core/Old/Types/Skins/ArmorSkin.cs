// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Skins
{
    using Items.Armors;

    /// <summary>Represents an armor skin.</summary>
    public abstract class ArmorSkin : Skin
    {
        /// <summary>Gets or sets the armor skin's weight class.</summary>
        public virtual WeightClass WeightClass { get; set; }
    }
}