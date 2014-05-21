// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultGizmo.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a default gizmo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos.GizmoTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a default gizmo.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class DefaultGizmo : Gizmo
    {
        /// <summary>Initializes a new instance of the <see cref="DefaultGizmo" /> class.</summary>
        public DefaultGizmo()
            : base(GizmoType.Default)
        {
        }
    }
}