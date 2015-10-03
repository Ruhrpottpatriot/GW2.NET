// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the PointOfInterestDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Floors.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/map_floor")]
    public sealed class PointOfInterestDTO
    {
        [DataMember(Name = "poi_id", Order = 0)]
        public int PointOfInterestId { get; set; }

        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "type", Order = 2)]
        public string Type { get; set; }

        [DataMember(Name = "floor", Order = 3)]
        public int Floor { get; set; }

        [DataMember(Name = "coord", Order = 4)]
        public double[] Coordinates { get; set; }
    }
}