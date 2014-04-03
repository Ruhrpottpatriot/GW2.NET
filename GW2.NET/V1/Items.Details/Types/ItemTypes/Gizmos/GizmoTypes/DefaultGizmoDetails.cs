// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultGizmoDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a default gizmo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.Gizmos.GizmoTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a default gizmo.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class DefaultGizmoDetails : GizmoDetails
    {
        /// <summary>Initializes a new instance of the <see cref="DefaultGizmoDetails" /> class.</summary>
        public DefaultGizmoDetails()
            : base(GizmoType.Default)
        {
        }
    }
}