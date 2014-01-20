// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GizmoType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.ItemDetails.Gizmos
{
    /// <summary>
    /// Enumerates the possible gizmo types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GizmoType
    {
        /// <summary>The 'Default' gizmo type.</summary>
        [EnumMember(Value = "Default")]
        Default = 1 << 0,

        /// <summary>The 'Rentable Contract NPC' gizmo type.</summary>
        [EnumMember(Value = "RentableContractNpc")]
        RentableContractNPC = 1 << 1,

        /// <summary>The 'Unlimited Consumable' gizmo type.</summary>
        [EnumMember(Value = "UnlimitedConsumable")]
        UnlimitedConsumable = 1 << 2,
    }
}