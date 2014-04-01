// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GizmoType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible gizmo types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.Gizmos
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible gizmo types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GizmoType
    {
        /// <summary>The 'Unknown' gizmo type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Default' gizmo type.</summary>
        [EnumMember(Value = "Default")]
        Default = 1 << 0, 

        /// <summary>The 'Rentable Contract NPC' gizmo type.</summary>
        [EnumMember(Value = "RentableContractNpc")]
        RentableContractNpc = 1 << 1, 

        /// <summary>The 'Unlimited Consumable' gizmo type.</summary>
        [EnumMember(Value = "UnlimitedConsumable")]
        UnlimitedConsumable = 1 << 2, 
    }
}