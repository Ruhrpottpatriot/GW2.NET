// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bag.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Bags
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a bag.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Bag : Item
    {
        /// <summary>Infrastructure. Stores the item details.</summary>
        private BagDetails details;

        /// <summary>Initializes a new instance of the <see cref="Bag" /> class.</summary>
        public Bag()
            : base(ItemType.Bag)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "bag", Order = 100)]
        public BagDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.Bag = this;
            }
        }
    }
}