// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveV2DTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ObjectiveV2DTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Objectives.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/wvw/objectives")]
    public sealed class ObjectiveDTO
    {
        [DataMember(Name = "id", Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "sector_id", Order = 2)]
        public string SectorId { get; set; }

        [DataMember(Name = "type", Order = 3)]
        public string Type { get; set; }

        [DataMember(Name = "map_type", Order = 4)]
        public string MapType { get; set; }

        [DataMember(Name = "map_id", Order = 5)]
        public string MapId { get; set; }

        [DataMember(Name = "coord", Order = 6)]
        public double[] Coord { get; set; }

        [DataMember(Name = "label_coord", Order = 7)]
        public double[] LabelCoord { get; set; }
    }
}
