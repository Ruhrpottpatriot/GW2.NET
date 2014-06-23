// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an unknown tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Tools.ToolTypes
{
    /// <summary>Represents detailed information about an unknown tool.</summary>
    public class UnknownTool : Tool
    {
        /// <summary>Initializes a new instance of the <see cref="UnknownTool" /> class.</summary>
        public UnknownTool()
            : base(ToolType.Unknown)
        {
        }
    }
}