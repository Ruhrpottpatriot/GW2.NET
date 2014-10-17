// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents the location of an event on the map.</summary>
    [DataContract]
    public sealed class LocationContract
    {
        /// <summary>Gets or sets the center coordinates.</summary>
        [DataMember(Name = "center", Order = 1)]
        public double[] Center { get; set; }

        /// <summary>Gets or sets the location's height.</summary>
        [DataMember(Name = "height", Order = 2)]
        public double Height { get; set; }

        /// <summary>Gets or sets the series of points in the polygon.</summary>
        [DataMember(Name = "points", Order = 6)]
        public double[][] Points { get; set; }

        /// <summary>Gets or sets the location's radius.</summary>
        [DataMember(Name = "radius", Order = 3)]
        public double Radius { get; set; }

        /// <summary>Gets or sets the location's rotation.</summary>
        [DataMember(Name = "rotation", Order = 4)]
        public double Rotation { get; set; }

        /// <summary>Gets or sets the location type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        /// <summary>Gets or sets the location's range on the z-axis.</summary>
        [DataMember(Name = "z_range", Order = 5)]
        public double[] ZRange { get; set; }
    }
}