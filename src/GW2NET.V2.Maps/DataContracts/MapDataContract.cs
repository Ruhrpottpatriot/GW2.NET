// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Maps
{
    using System.Runtime.Serialization;

    /// <summary>Defines the map data contract.</summary>
    [DataContract]
    internal sealed class MapDataContract
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the minimum level.
        /// </summary>
        [DataMember(Name = "min_level", Order = 2)]
        public int MinimumLevel { get; set; }

        /// <summary>
        /// Gets or sets the maximum level.
        /// </summary>
        [DataMember(Name = "max_level", Order = 3)]
        public int MaximumLevel { get; set; }

        /// <summary>
        /// Gets or sets the default floor.
        /// </summary>
        [DataMember(Name = "default_floor", Order = 4)]
        public int DefaultFloor { get; set; }

        /// <summary>
        /// Gets or sets the floors.
        /// </summary>
        [DataMember(Name = "floors", Order = 5)]
        public int[] Floors { get; set; }

        /// <summary>
        /// Gets or sets the region id.
        /// </summary>
        [DataMember(Name = "region_id", Order = 6)]
        public int RegionId { get; set; }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        [DataMember(Name = "region_name", Order = 7)]
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets the continent id.
        /// </summary>
        [DataMember(Name = "continent_id", Order = 8)]
        public int ContinentId { get; set; }

        /// <summary>
        /// Gets or sets the continent name.
        /// </summary>
        [DataMember(Name = "continent_name", Order = 9)]
        public string ContinentName { get; set; }

        /// <summary>
        /// Gets or sets the map rectangle.
        /// </summary>
        [DataMember(Name = "map_rect", Order = 10)]
        public double[][] MapRectangle { get; set; }

        /// <summary>
        /// Gets or sets the continent rectangle.
        /// </summary>
        [DataMember(Name = "continent_rect", Order = 11)]
        public double[][] ContinentRectangle { get; set; }
    }
}