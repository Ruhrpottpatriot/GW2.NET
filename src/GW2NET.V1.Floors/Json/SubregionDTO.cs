// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubregionDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the SubregionDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Floors.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/map_floor")]
    public sealed class SubregionDTO
    {
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }

        [DataMember(Name = "min_level", Order = 1)]
        public int MinimumLevel { get; set; }

        [DataMember(Name = "max_level", Order = 2)]
        public int MaximumLevel { get; set; }

        [DataMember(Name = "default_floor", Order = 3)]
        public int DefaultFloor { get; set; }

        [DataMember(Name = "map_rect", Order = 4)]
        public double[][] MapRectangle { get; set; }

        [DataMember(Name = "continent_rect", Order = 5)]
        public double[][] ContinentRectangle { get; set; }

        [DataMember(Name = "points_of_interest", Order = 6)]
        public ICollection<PointOfInterestDTO> PointsOfInterest { get; set; }

        [DataMember(Name = "tasks", Order = 7)]
        public ICollection<RenownTaskDTO> Tasks { get; set; }

        [DataMember(Name = "skill_challenges", Order = 8)]
        public ICollection<SkillChallengeDTO> SkillChallenges { get; set; }

        [DataMember(Name = "sectors", Order = 9)]
        public ICollection<SectorDTO> Sectors { get; set; }
    }
}