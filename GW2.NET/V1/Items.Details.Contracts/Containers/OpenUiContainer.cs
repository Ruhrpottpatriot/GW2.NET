// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenUiContainer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a container that opens a user interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Containers
{
    using GW2DotNET.Common;

    /// <summary>Represents a container that opens a user interface.</summary>
    [TypeDiscriminator(Value = "OpenUI", BaseType = typeof(Container))]
    public class OpenUiContainer : Container
    {
    }
}