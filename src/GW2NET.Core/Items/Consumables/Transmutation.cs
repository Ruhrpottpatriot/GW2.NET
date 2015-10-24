// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Transmutation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a transmutation item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System.Collections.Generic;

    using GW2NET.Skins;

    /// <summary>Represents a transmutation item.</summary>
    public class Transmutation : Consumable
    {
        public ICollection<int> SkinIds { get; set; }

        public virtual ICollection<Skin> Skins { get; set; }
    }
}