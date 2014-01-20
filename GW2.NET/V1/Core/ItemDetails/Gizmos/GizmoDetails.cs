// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GizmoDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Gizmos
{
    /// <summary>
    /// Represents detailed information about a gizmo.
    /// </summary>
    public class GizmoDetails : Details
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GizmoDetails"/> class.
        /// </summary>
        public GizmoDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GizmoDetails"/> class using the specified values.
        /// </summary>
        /// <param name="type">The gizmo's type.</param>
        public GizmoDetails(GizmoType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the gizmo's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public GizmoType Type { get; set; }
    }
}