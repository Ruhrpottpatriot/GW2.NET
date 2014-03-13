// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Tools
{
    using GW2DotNET.V1.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a tool.
    /// </summary>
    [JsonConverter(typeof(ToolDetailsConverter))]
    public abstract class ToolDetails : JsonObject
    {
        /// <summary>Initializes a new instance of the <see cref="ToolDetails"/> class.</summary>
        /// <param name="toolType">The tool's type.</param>
        protected ToolDetails(ToolType toolType)
        {
            this.Type = toolType;
        }

        /// <summary>
        ///     Gets or sets the tool's charges.
        /// </summary>
        [JsonProperty("charges", Order = 1)]
        public int Charges { get; set; }

        /// <summary>
        ///     Gets or sets the tool's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ToolType Type { get; set; }
    }
}