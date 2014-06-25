// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SphereLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a spherical location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;

    /// <summary>Represents a spherical location of an event on the map.</summary>
    [TypeDiscriminator(Value = "sphere", BaseType = typeof(Location))]
    public class SphereLocation : Location
    {
        /// <summary>Gets or sets the location's radius.</summary>
        [DataMember(Name = "radius")]
        public double Radius { get; set; }

        /// <summary>Gets or sets the location's rotation.</summary>
        [DataMember(Name = "rotation")]
        public double Rotation { get; set; }
    }
}