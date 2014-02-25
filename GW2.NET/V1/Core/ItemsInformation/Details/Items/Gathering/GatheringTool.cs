// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringTool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gathering
{
    /// <summary>
    /// Represents a gathering tool.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class GatheringTool : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GatheringTool"/> class.
        /// </summary>
        public GatheringTool()
            : base(ItemType.Gathering)
        {
        }

        /// <summary>
        /// Gets or sets the gathering equipment's details.
        /// </summary>
        [JsonProperty("gathering", Order = 100)]
        public GatheringToolDetails GatheringToolDetails { get; set; }
    }
}