// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gizmo.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a gizmo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    /// <summary>Represents a gizmo.</summary>
    [JsonConverter(typeof(GizmoConverter))]
    public abstract class Gizmo : Item
    {
        /// <summary>Initializes a new instance of the <see cref="Gizmo"/> class.</summary>
        /// <param name="gizmoType">The gizmo type.</param>
        protected Gizmo(GizmoType gizmoType)
            : base(ItemType.Gizmo)
        {
            this.GizmoType = gizmoType;
        }

        /// <summary>Gets or sets the gizmo's type.</summary>
        [DataMember(Name = "gizmo_type")]
        protected GizmoType GizmoType { get; set; }

        /// <summary>Gets the name of the property that provides additional information.</summary>
        /// <returns>The name of the property.</returns>
        protected override string GetTypeKey()
        {
            return "gizmo";
        }
    }
}