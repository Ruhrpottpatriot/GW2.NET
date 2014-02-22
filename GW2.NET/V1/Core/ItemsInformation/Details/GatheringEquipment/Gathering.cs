// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gathering.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.GatheringEquipment
{
    /// <summary>
    /// Represents a piece of gathering equipment.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Gathering : Item // TODO: Rename 'Gathering' to 'GatheringEquipment'
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gathering"/> class.
        /// </summary>
        public Gathering()
            : base(ItemType.Gathering)
        {
        }

        /// <summary>
        /// Gets or sets the gathering equipment's details.
        /// </summary>
        [JsonProperty("gathering", Order = 100)]
        public GatheringItemDetails GatheringItemDetails { get; set; }
    }
}