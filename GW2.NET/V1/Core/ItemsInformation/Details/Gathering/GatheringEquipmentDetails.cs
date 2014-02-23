// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringEquipmentDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Gathering
{
    /// <summary>
    /// Represents detailed information about a piece of gathering equipment.
    /// </summary>
    public class GatheringEquipmentDetails : JsonObject
    {
        /// <summary>
        /// Gets or sets the gathering equipment's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public GatheringEquipmentType Type { get; set; }
    }
}