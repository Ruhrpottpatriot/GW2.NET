// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bag.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Bag type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    public struct Bag
    {
        public Bag(int size, bool noSellOrSort)
            : this()
        {
            this.NoSellOrSort = noSellOrSort;
            this.Size = size;
        }

        public int Size
        {
            get;
            private set;
        }

        public bool NoSellOrSort
        {
            get;
            private set;
        }
    }
}
