// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Consumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    /// <summary>Represents a consumable item.</summary>
    [JsonConverter(typeof(ConsumableConverter))]
    public abstract class Consumable : Item
    {
        /// <summary>Initializes a new instance of the <see cref="Consumable"/> class.</summary>
        /// <param name="consumableType">The consumable's type.</param>
        protected Consumable(ConsumableType consumableType)
            : base(ItemType.Consumable, "consumable")
        {
            this.ConsumableType = consumableType;
        }

        /// <summary>Gets or sets the consumable's type.</summary>
        [DataMember(Name = "consumable_type")]
        protected ConsumableType ConsumableType { get; set; }
    }
}