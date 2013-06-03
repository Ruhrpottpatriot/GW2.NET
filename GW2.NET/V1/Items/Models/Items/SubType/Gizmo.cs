// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gizmo.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Gizmo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// The gizmo.
    /// </summary>
    public struct Gizmo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gizmo"/> struct.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        [JsonConstructor]
        public Gizmo(GizmoType type)
            : this()
        {
            this.Type = type;
        }

        /// <summary>
        /// Enumerates the gizmo types.
        /// </summary>
        public enum GizmoType
        {
            /// <summary>
            /// The default gizmo.
            /// </summary>
            Default,

            /// <summary>
            /// A rentable contract npc.
            /// </summary>
            RentableContractNpc,

            /// <summary>
            /// An unlimited consumable.
            /// </summary>
            UnlimitedConsumable,
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [JsonProperty("type")]
        public GizmoType Type
        {
            get;
            private set;
        }
    }
}
