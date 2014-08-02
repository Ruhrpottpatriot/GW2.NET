// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map and its details, including details about floor and translation data on how to translate between world coordinates and map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a map and its details, including details about floor and translation data on how to translate between world coordinates and map coordinates.</summary>
    [DataContract]
    public sealed class MapContract
    {
        /// <summary>Gets or sets the continent identifier of the continent that this map belongs to.</summary>
        [DataMember(Name = "continent_id", Order = 7)]
        public int ContinentId { get; set; }

        /// <summary>Gets or sets the name of the continent that this map belongs to.</summary>
        [DataMember(Name = "continent_name", Order = 8)]
        public string ContinentName { get; set; }

        /// <summary>Gets or sets the dimensions of the map within the continent coordinate system.</summary>
        [DataMember(Name = "continent_rect", Order = 10)]
        public double[][] ContinentRectangle { get; set; }

        /// <summary>Gets or sets the default floor of this map.</summary>
        [DataMember(Name = "default_floor", Order = 3)]
        public int DefaultFloor { get; set; }

        /// <summary>Gets or sets a list of available floors for this map.</summary>
        [DataMember(Name = "floors", Order = 4)]
        public ICollection<int> Floors { get; set; }

        /// <summary>Gets or sets the name of the map.</summary>
        [DataMember(Name = "map_name", Order = 0)]
        public string MapName { get; set; }

        /// <summary>Gets or sets the dimensions of the map.</summary>
        [DataMember(Name = "map_rect", Order = 9)]
        public double[][] MapRectangle { get; set; }

        /// <summary>Gets or sets the maximum level of this map.</summary>
        [DataMember(Name = "max_level", Order = 2)]
        public int MaximumLevel { get; set; }

        /// <summary>Gets or sets the minimum level of this map.</summary>
        [DataMember(Name = "min_level", Order = 1)]
        public int MinimumLevel { get; set; }

        /// <summary>Gets or sets the region identifier of the region that this map belongs to.</summary>
        [DataMember(Name = "region_id", Order = 5)]
        public int RegionId { get; set; }

        /// <summary>Gets or sets the name of the region that this map belongs to.</summary>
        [DataMember(Name = "region_name", Order = 6)]
        public string RegionName { get; set; }
    }
}