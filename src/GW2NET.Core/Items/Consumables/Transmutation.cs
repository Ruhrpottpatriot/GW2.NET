// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Transmutation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a transmutation item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items.Consumables
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Skins;

    /// <summary>Represents a transmutation item.</summary>
    public class Transmutation : Consumable
    {
        private static readonly int[] EmptySkinIds = new int[0];

        private static readonly Skin[] EmptySkins = new Skin[0];

        private ICollection<int> skinIds = EmptySkinIds;

        private ICollection<Skin> skins = EmptySkins;

        public ICollection<int> SkinIds
        {
            get
            {
                Debug.Assert(this.skinIds != null, "this.skinIds != null");
                return this.skinIds;
            }

            set
            {
                this.skinIds = value ?? EmptySkinIds;
            }
        }

        public virtual ICollection<Skin> Skins
        {
            get
            {
                Debug.Assert(this.skins != null, "this.skins != null");
                return this.skins;
            }

            set
            {
                this.skins = value ?? EmptySkins;
            }
        }
    }
}