// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a Point of Interest (POI) location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a Point of Interest (POI) location.</summary>
    public sealed class PointOfInterestContract : ServiceContract
    {
        /// <summary>Gets or sets the coordinates of this Point of Interest.</summary>
        [DataMember(Name = "coord", Order = 4)]
        public double[] Coordinates { get; set; }

        /// <summary>Gets or sets the floor of this Point of Interest.</summary>
        [DataMember(Name = "floor", Order = 3)]
        public int Floor { get; set; }

        /// <summary>Gets or sets the name of this Point of Interest.</summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets the Point of Interest identifier.</summary>
        [DataMember(Name = "poi_id", Order = 0)]
        public int PointOfInterestId { get; set; }

        /// <summary>Gets or sets Point of Interest type.</summary>
        [DataMember(Name = "type", Order = 2)]
        public string Type { get; set; }
    }
}