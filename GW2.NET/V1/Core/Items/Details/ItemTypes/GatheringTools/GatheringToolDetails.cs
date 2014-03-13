// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringToolDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a gathering tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.GatheringTools
{
    using GW2DotNET.V1.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a gathering tool.
    /// </summary>
    [JsonConverter(typeof(GatheringToolDetailsConverter))]
    public abstract class GatheringToolDetails : JsonObject
    {
        /// <summary>Initializes a new instance of the <see cref="GatheringToolDetails"/> class.</summary>
        /// <param name="gatheringToolType">The gathering tool type.</param>
        protected GatheringToolDetails(GatheringToolType gatheringToolType)
        {
            this.ToolType = gatheringToolType;
        }

        /// <summary>
        ///     Gets or sets the gathering equipment's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public GatheringToolType ToolType { get; set; }
    }
}