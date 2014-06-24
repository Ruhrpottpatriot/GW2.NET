// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultContainer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a default container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers
{
    using GW2DotNET.Common;

    /// <summary>Represents a default container.</summary>
    [TypeDiscriminator(Value = "Default", BaseType = typeof(Container))]
    public class DefaultContainer : Container
    {
    }
}