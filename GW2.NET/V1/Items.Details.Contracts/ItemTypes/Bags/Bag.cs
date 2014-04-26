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
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents a bag.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Bag : Item
    {
        /// <summary>Initializes a new instance of the <see cref="Bag" /> class.</summary>
        public Bag()
            : base(ItemType.Bag)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "bag", Order = 100)]
        public override ItemDetails Details
        {
            get
            {
                return base.Details;
            }

            set
            {
                base.Details = value;
            }
        }

        /// <summary>The method that is called before de-serializing.</summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserializing]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            this.Details = new BagDetails();
        }
    }
}