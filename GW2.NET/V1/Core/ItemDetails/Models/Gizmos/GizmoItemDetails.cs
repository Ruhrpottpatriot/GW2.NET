// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GizmoItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Gizmos
{
    /// <summary>
    /// Represents detailed information about a gizmo.
    /// </summary>
    public class GizmoItemDetails : ItemDetailsBase
    {
        /// <summary>
        /// Gets or sets the gizmo's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public GizmoType Type { get; set; }
    }
}