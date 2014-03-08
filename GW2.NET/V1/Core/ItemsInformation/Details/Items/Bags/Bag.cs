// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bag.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Bags
{
    /// <summary>
    ///     Represents a bag.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Bag : Item
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Bag" /> class.
        /// </summary>
        public Bag()
            : base(ItemType.Bag)
        {
        }

        /// <summary>
        ///     Gets or sets the bag's details.
        /// </summary>
        [JsonProperty("bag", Order = 100)]
        public BagDetails BagDetails { get; set; }
    }
}