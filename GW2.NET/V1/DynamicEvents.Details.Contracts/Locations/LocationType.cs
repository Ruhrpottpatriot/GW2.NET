// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible location shapes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible location shapes.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LocationType
    {
        /// <summary> The 'unknown' location type.</summary>
        [EnumMember(Value = "unknown")]
        Unknown = 0, 

        /// <summary> The 'sphere' location type.</summary>
        [EnumMember(Value = "sphere")]
        Sphere = 1 << 0, 

        /// <summary> The 'cylinder' location type.</summary>
        [EnumMember(Value = "cylinder")]
        Cylinder = 1 << 1, 

        /// <summary> The 'poly' location type.</summary>
        [EnumMember(Value = "poly")]
        Polygon = 1 << 2
    }
}