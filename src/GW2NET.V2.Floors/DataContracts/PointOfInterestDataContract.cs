// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the point of interest object from the api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Runtime.Serialization;

    /// <summary>Represents the point of interest object from the api.</summary>
    [DataContract]
    internal sealed class PointOfInterestDataContract
    {
        /// <summary>
        /// Gets or sets the point of interest id.
        /// </summary>
        [DataMember(Name = "poi_id", Order = 0)]
        internal int PointOfInterestId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type", Order = 2)]
        internal string Type { get; set; }

        /// <summary>
        /// Gets or sets the floor.
        /// </summary>
        [DataMember(Name = "floor", Order = 3)]
        internal int Floor { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        [DataMember(Name = "coord", Order = 4)]
        internal double[] Coordinates { get; set; }
    }
}