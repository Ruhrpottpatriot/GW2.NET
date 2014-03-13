// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GizmoDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a gizmo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Gizmos
{
    using GW2DotNET.V1.Core.Common;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a gizmo.
    /// </summary>
    [JsonConverter(typeof(GizmoDetailsConverter))]
    public abstract class GizmoDetails : JsonObject
    {
        /// <summary>Initializes a new instance of the <see cref="GizmoDetails"/> class.</summary>
        /// <param name="gizmoType">The gizmo type.</param>
        protected GizmoDetails(GizmoType gizmoType)
        {
            this.Type = gizmoType;
        }

        /// <summary>Gets or sets the gizmo.</summary>
        public Gizmo Gizmo { get; set; }

        /// <summary>
        ///     Gets or sets the gizmo's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public GizmoType Type { get; set; }
    }
}