// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Trinkets
{
    /// <summary>
    /// Represents a trinket.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Trinket : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trinket"/> class.
        /// </summary>
        public Trinket()
            : base(ItemType.Trinket)
        {
        }

        /// <summary>
        /// Gets or sets the trinket's details.
        /// </summary>
        [JsonProperty("trinket", Order = 100)]
        public TrinketItemDetails TrinketItemDetails { get; set; }
    }
}