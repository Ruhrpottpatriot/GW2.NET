// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultGizmo.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a default gizmo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos.GizmoTypes
{
    using GW2DotNET.Common;

    /// <summary>Represents a default gizmo.</summary>
    [TypeDiscriminator(Value = "Default", BaseType = typeof(Gizmo))]
    public class DefaultGizmo : Gizmo
    {
    }
}