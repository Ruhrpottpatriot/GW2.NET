// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gizmo.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Gizmo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    public struct Gizmo
    {
        public Gizmo(GizmoType type)
            : this()
        {
            this.Type = type;
        }

        public GizmoType Type
        {
            get;
            private set;
        }

        public enum GizmoType
        {
            Default,
            RentableContractNPC,
            UnlimitedConsumable,
        }
    }
}
