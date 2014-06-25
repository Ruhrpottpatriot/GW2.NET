// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SalvageTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a salvaging tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Tools
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;

    /// <summary>Represents a salvaging tool.</summary>
    [TypeDiscriminator(Value = "Salvage", BaseType = typeof(Tool))]
    public class SalvageTool : Tool
    {
        /// <summary>Gets or sets the tool's charges.</summary>
        [DataMember(Name = "charges")]
        public virtual int Charges { get; set; }
    }
}