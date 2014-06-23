// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a logging tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.GatheringTools.GatheringToolsTypes
{
    /// <summary>Represents detailed information about a logging tool.</summary>
    public class LoggingTool : GatheringTool
    {
        /// <summary>Initializes a new instance of the <see cref="LoggingTool" /> class.</summary>
        public LoggingTool()
            : base(GatheringToolType.Logging)
        {
        }
    }
}