// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bag.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Bags
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a bag.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Bag : Item
    {
        /// <summary>Infrastructure. Stores the bag details.</summary>
        private BagDetails bagDetails;

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
        public BagDetails BagDetails
        {
            get
            {
                return this.bagDetails;
            }

            set
            {
                this.bagDetails = value;
                value.Bag = this;
            }
        }
    }
}