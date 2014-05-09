// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a consumable item.</summary>
    [JsonConverter(typeof(ConsumableDetailsConverter))]
    public abstract class ConsumableDetails : ItemDetails
    {
        /// <summary>Initializes a new instance of the <see cref="ConsumableDetails"/> class.</summary>
        /// <param name="type">The consumable's type.</param>
        protected ConsumableDetails(ConsumableType type)
        {
            this.Type = type;
        }

        /// <summary>Gets or sets the consumable's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        protected ConsumableType Type { get; set; }
    }
}