// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bag.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Bag type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// A bag.
    /// </summary>
    public struct Bag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bag"/> struct.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <param name="noSellOrSort">
        /// The no sell or sort.
        /// </param>
        [JsonConstructor]
        public Bag(int size, bool noSellOrSort)
            : this()
        {
            this.NoSellOrSort = noSellOrSort;
            this.Size = size;
        }

        /// <summary>
        /// Gets the bag size.
        /// </summary>
        [JsonProperty("size")]
        public int Size
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the bag can be sold or sorted.
        /// </summary>
        [JsonProperty("no_sell_or_sort")]
        public bool NoSellOrSort
        {
            get;
            private set;
        }
    }
}
