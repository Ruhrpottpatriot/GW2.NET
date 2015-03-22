// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the SectorDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Runtime.Serialization;

    /// <summary>Represents the sector object from the api.</summary>
    [DataContract]
    internal sealed class SectorDataContract
    {
        /// <summary>
        /// Gets or sets the sector id.
        /// </summary>
        [DataMember(Name = "sector_id", Order = 0)]
        internal int SectorId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        [DataMember(Name = "level", Order = 2)]
        internal int Level { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        [DataMember(Name = "coord", Order = 3)]
        internal double[] Coordinates { get; set; }
    }
}