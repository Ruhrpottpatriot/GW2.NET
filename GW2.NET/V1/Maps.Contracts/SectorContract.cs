// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an area within a map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents an area within a map.</summary>
    public sealed class SectorContract : ServiceContract
    {
        /// <summary>Gets or sets the sector's coordinates, which is (usually) the center position.</summary>
        [DataMember(Name = "coord", Order = 3)]
        public double[] Coordinates { get; set; }

        /// <summary>Gets or sets the sector's level.</summary>
        [DataMember(Name = "level", Order = 2)]
        public int Level { get; set; }

        /// <summary>Gets or sets the name of the sector.</summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets the sector identifier.</summary>
        [DataMember(Name = "sector_id", Order = 0)]
        public int SectorId { get; set; }
    }
}