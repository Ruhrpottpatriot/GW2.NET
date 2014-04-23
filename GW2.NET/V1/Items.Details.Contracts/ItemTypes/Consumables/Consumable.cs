// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Consumable.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a consumable item.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Consumable : Item
    {
        /// <summary>Infrastructure. Stores the item details.</summary>
        private ConsumableDetails details;

        /// <summary>Initializes a new instance of the <see cref="Consumable" /> class.</summary>
        public Consumable()
            : base(ItemType.Consumable)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "consumable", Order = 100)]
        public ConsumableDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.Consumable = this;
            }
        }
    }
}