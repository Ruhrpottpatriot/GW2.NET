// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts.Tools
{
    using GW2DotNET.Common;

    /// <summary>Represents an unknown tool.</summary>
    [TypeDiscriminator(Value = "Unknown", BaseType = typeof(Tool))]
    public class UnknownTool : Tool
    {
    }
}