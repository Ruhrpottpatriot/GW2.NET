// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a trinket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Trinkets
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a trinket.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Trinket : Item
    {
        /// <summary>Infrastructure. Stores the item details.</summary>
        private TrinketDetails details;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Trinket" /> class.
        /// </summary>
        public Trinket()
            : base(ItemType.Trinket)
        {
        }

        /// <summary>
        ///     Gets or sets the item details.
        /// </summary>
        [JsonProperty("trinket", Order = 100)]
        public TrinketDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.Trinket = this;
            }
        }
    }
}