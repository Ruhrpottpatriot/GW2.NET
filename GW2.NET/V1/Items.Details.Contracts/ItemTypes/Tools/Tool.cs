// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Tools
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    /// <summary>Represents a tool.</summary>
    [JsonConverter(typeof(ToolConverter))]
    public abstract class Tool : Item
    {
        /// <summary>Initializes a new instance of the <see cref="Tool"/> class.</summary>
        /// <param name="toolType">The tool's type.</param>
        protected Tool(ToolType toolType)
            : base(ItemType.Tool)
        {
            this.ToolType = toolType;
        }

        /// <summary>Gets or sets the tool's type.</summary>
        [DataMember(Name = "tool_type")]
        protected ToolType ToolType { get; set; }

        /// <summary>Gets the name of the property that provides additional information.</summary>
        /// <returns>The name of the property.</returns>
        protected override string GetTypeKey()
        {
            return "tool";
        }
    }
}