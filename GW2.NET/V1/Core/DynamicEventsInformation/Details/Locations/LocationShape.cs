// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationShape.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations
{
    /// <summary>
    /// Enumerates the possible location shapes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LocationShape
    {
        /// <summary> The spherical location type.</summary>
        [EnumMember(Value = "sphere")]
        Sphere = 1 << 0,

        /// <summary> The cylindrical location type.</summary>
        [EnumMember(Value = "cylinder")]
        Cylinder = 1 << 1,

        /// <summary> The polygonal location type.</summary>
        [EnumMember(Value = "poly")]
        Polygon = 1 << 2
    }
}