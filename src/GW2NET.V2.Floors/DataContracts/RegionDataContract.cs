// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RegionDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents the region object from the api.</summary>
    [DataContract]
    internal sealed class RegionDataContract
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }

        /// <summary>
        /// Gets or sets the label coordinates.
        /// </summary>
        [DataMember(Name = "label_coord", Order = 1)]
        internal double[] LabelCoordinates { get; set; }

        /// <summary>
        /// Gets or sets the maps.
        /// </summary>
        [DataMember(Name = "maps", Order = 2)]
        internal IDictionary<string, MapDataContract> Maps { get; set; }
    }
}