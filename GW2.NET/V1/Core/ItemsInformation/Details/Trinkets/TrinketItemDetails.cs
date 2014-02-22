// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemsInformation.Details.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Trinkets
{
    /// <summary>
    /// Represents detailed information about a trinket.
    /// </summary>
    public class TrinketItemDetails : EquipmentItemDetails
    {
        /// <summary>
        /// Gets or sets the trinket's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public TrinketType Type { get; set; }
    }
}