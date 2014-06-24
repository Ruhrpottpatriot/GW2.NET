// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GiftBox.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a gift box container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers.ContainerTypes
{
    using GW2DotNET.Common;

    /// <summary>Represents a gift box container.</summary>
    [TypeDiscriminator(Value = "GiftBox", BaseType = typeof(Container))]
    public class GiftBox : Container
    {
    }
}