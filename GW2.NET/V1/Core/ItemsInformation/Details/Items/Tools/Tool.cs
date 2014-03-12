// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Tools
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a tool.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Tool : Item
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Tool" /> class.
        /// </summary>
        public Tool()
            : base(ItemType.Tool)
        {
        }

        /// <summary>
        ///     Gets or sets the tool's details.
        /// </summary>
        [JsonProperty("tool", Order = 100)]
        public ToolDetails ToolDetails { get; set; }
    }
}