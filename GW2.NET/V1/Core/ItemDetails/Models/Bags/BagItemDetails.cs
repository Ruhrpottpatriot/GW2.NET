// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Bags
{
    /// <summary>
    /// Represents detailed information about a bag.
    /// </summary>
    public class BagItemDetails : Common.ItemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BagItemDetails"/> class.
        /// </summary>
        public BagItemDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BagItemDetails"/> class using the specified values.
        /// </summary>
        /// <param name="noSellOrSort">Indicates whether this is an invisible bag.</param>
        /// <param name="size">The bag's capacity.</param>
        public BagItemDetails(bool noSellOrSort, int size)
        {
            this.NoSellOrSort = noSellOrSort;
            this.Size = size;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this is an invisible bag.
        /// </summary>
        [JsonProperty("no_sell_or_sort", Order = 0)]
        [JsonConverter(typeof(NumericBooleanConverter))]
        public bool NoSellOrSort { get; set; }

        /// <summary>
        /// Gets or sets the bag's capacity.
        /// </summary>
        [JsonProperty("size", Order = 1)]
        public int Size { get; set; }
    }
}