// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemsInformation.Details.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.ArmorPieces
{
    /// <summary>
    /// Represents detailed information about an armor piece.
    /// </summary>
    public class ArmorItemDetails : EquipmentItemDetails
    {
        /// <summary>
        /// Gets or sets the armor piece's defense stat.
        /// </summary>
        [JsonProperty("defense", Order = 2)]
        public int Defense { get; set; }

        /// <summary>
        /// Gets or sets the armor piece's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ArmorType Type { get; set; }

        /// <summary>
        /// Gets or sets the armor piece's weight class.
        /// </summary>
        [JsonProperty("weight_class", Order = 1)]
        public WeightClass WeightClass { get; set; }
    }
}