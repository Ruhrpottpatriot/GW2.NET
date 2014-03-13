// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringTool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a gathering tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.GatheringTools
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a gathering tool.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class GatheringTool : Item
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GatheringTool" /> class.
        /// </summary>
        public GatheringTool()
            : base(ItemType.Gathering)
        {
        }

        /// <summary>
        ///     Gets or sets the gathering equipment's details.
        /// </summary>
        [JsonProperty("gathering", Order = 100)]
        public GatheringToolDetails GatheringToolDetails { get; set; }
    }
}