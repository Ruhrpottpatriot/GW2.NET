// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Maps.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/maps")]
    public sealed class MapDTO
    {
        [DataMember(Name = "map_name", Order = 0)]
        public string MapName { get; set; }

        [DataMember(Name = "min_level", Order = 1)]
        public int MinimumLevel { get; set; }

        [DataMember(Name = "max_level", Order = 2)]
        public int MaximumLevel { get; set; }

        [DataMember(Name = "default_floor", Order = 3)]
        public int DefaultFloor { get; set; }

        [DataMember(Name = "type", Order = 4)]
        public string TypeName { get; set; }

        [DataMember(Name = "floors", Order = 5)]
        public ICollection<int> Floors { get; set; }

        [DataMember(Name = "region_id", Order = 6)]
        public int RegionId { get; set; }

        [DataMember(Name = "region_name", Order = 7)]
        public string RegionName { get; set; }

        [DataMember(Name = "continent_id", Order = 8)]
        public int ContinentId { get; set; }

        [DataMember(Name = "continent_name", Order = 9)]
        public string ContinentName { get; set; }

        [DataMember(Name = "map_rect", Order = 10)]
        public double[][] MapRectangle { get; set; }

        [DataMember(Name = "continent_rect", Order = 11)]
        public double[][] ContinentRectangle { get; set; }
    }
}