// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Maps.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/maps")]
    internal sealed class MapDataContract
    {
        [DataMember(Name = "map_name", Order = 0)]
        internal string MapName { get; set; }

        [DataMember(Name = "min_level", Order = 1)]
        internal int MinimumLevel { get; set; }

        [DataMember(Name = "max_level", Order = 2)]
        internal int MaximumLevel { get; set; }

        [DataMember(Name = "default_floor", Order = 3)]
        internal int DefaultFloor { get; set; }

        [DataMember(Name = "floors", Order = 4)]
        internal ICollection<int> Floors { get; set; }

        [DataMember(Name = "region_id", Order = 5)]
        internal int RegionId { get; set; }

        [DataMember(Name = "region_name", Order = 6)]
        internal string RegionName { get; set; }

        [DataMember(Name = "continent_id", Order = 7)]
        internal int ContinentId { get; set; }

        [DataMember(Name = "continent_name", Order = 8)]
        internal string ContinentName { get; set; }

        [DataMember(Name = "map_rect", Order = 9)]
        internal double[][] MapRectangle { get; set; }

        [DataMember(Name = "continent_rect", Order = 10)]
        internal double[][] ContinentRectangle { get; set; }
    }
}
