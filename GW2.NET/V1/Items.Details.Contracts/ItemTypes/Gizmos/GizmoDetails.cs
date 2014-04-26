// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GizmoDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a gizmo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a gizmo.</summary>
    [JsonConverter(typeof(GizmoDetailsConverter))]
    public abstract class GizmoDetails : ItemDetails
    {
        /// <summary>Infrastructure. Stores type information.</summary>
        private readonly GizmoType type;

        /// <summary>Initializes a new instance of the <see cref="GizmoDetails"/> class.</summary>
        /// <param name="gizmoType">The gizmo type.</param>
        protected GizmoDetails(GizmoType gizmoType)
        {
            this.type = gizmoType;
        }

        /// <summary>Gets the gizmo's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public GizmoType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}