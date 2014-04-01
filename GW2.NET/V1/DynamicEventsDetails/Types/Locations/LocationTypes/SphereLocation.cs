// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SphereLocation.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a spherical location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEventsDetails.Types.Locations.LocationTypes
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a spherical location of an event on the map.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class SphereLocation : Location
    {
        /// <summary>Initializes a new instance of the <see cref="SphereLocation" /> class.</summary>
        public SphereLocation()
            : base(LocationType.Sphere)
        {
        }

        /// <summary>Gets or sets the location's radius.</summary>
        [DataMember(Name = "radius", Order = 4)]
        public double Radius { get; set; }

        /// <summary>Gets or sets the location's rotation.</summary>
        [DataMember(Name = "rotation", Order = 5)]
        public double Rotation { get; set; }
    }
}