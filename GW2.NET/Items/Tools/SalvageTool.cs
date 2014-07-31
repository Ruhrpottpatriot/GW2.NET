// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SalvageTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a salvaging tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Items
{
    /// <summary>Represents a salvaging tool.</summary>
    public class SalvageTool : Tool
    {
        /// <summary>Gets or sets the tool's charges.</summary>
        public virtual int Charges { get; set; }
    }
}