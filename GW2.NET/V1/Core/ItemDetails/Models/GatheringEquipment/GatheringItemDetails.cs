// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.GatheringEquipment
{
    /// <summary>
    /// Represents detailed information about a piece of gathering equipment.
    /// </summary>
    public class GatheringItemDetails : ItemDetailsBase // // TODO: Rename 'GatheringItemDetails' to 'GatheringEquipmentDetails'
    {
        /// <summary>
        /// Gets or sets the gathering equipment's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public GatheringType Type { get; set; }
    }
}