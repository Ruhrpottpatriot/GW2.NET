// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SalvageTool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a salvaging tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Tools.ToolTypes
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a salvaging tool.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class SalvageTool : Tool
    {
        /// <summary>Initializes a new instance of the <see cref="SalvageTool" /> class.</summary>
        public SalvageTool()
            : base(ToolType.Salvage)
        {
        }

        /// <summary>Gets or sets the tool's charges.</summary>
        [DataMember(Name = "charges", Order = 1000)]
        public virtual int Charges { get; set; }
    }
}