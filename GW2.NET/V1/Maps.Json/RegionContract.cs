// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a region on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a region on the map.</summary>
    [DataContract]
    public sealed class RegionContract
    {
        /// <summary>Gets or sets the coordinates of the region label.</summary>
        [DataMember(Name = "label_coord", Order = 1)]
        public double[] LabelCoordinates { get; set; }

        /// <summary>Gets or sets a collection of maps and their details.</summary>
        [DataMember(Name = "maps", Order = 2)]
        public IDictionary<string, SubregionContract> Maps { get; set; }

        /// <summary>Gets or sets the name of the region.</summary>
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }
    }
}