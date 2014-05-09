// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a trinket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a trinket.</summary>
    [JsonConverter(typeof(TrinketDetailsConverter))]
    public abstract class TrinketDetails : EquipmentDetails
    {
        /// <summary>Initializes a new instance of the <see cref="TrinketDetails"/> class.</summary>
        /// <param name="trinketType">The trinket's type.</param>
        protected TrinketDetails(TrinketType trinketType)
        {
            this.Type = trinketType;
        }

        /// <summary>Gets or sets the trinket's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        protected TrinketType Type { get; set; }
    }
}