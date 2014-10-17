// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Skins
{
    using GW2NET.Entities.Items;

    /// <summary>Represents an armor skin.</summary>
    public abstract class ArmorSkin : Skin
    {
        /// <summary>Gets or sets the armor skin's weight class.</summary>
        public virtual ArmorWeightClass WeightClass { get; set; }
    }
}