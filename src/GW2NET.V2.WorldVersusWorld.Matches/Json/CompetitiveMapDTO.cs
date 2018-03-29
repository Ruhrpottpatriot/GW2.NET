// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitiveMapDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the CompetitiveMapDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Matches.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class CompetitiveMapDTO
    {
        /// <summary>Gets or sets the map id.</summary>
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        /// <summary>Gets or sets the map type.</summary>
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        /// <summary>Gets or sets the scores per team.</summary>
        [DataMember(Name = "scores", Order = 2)]
        public TeamStatDTO Scores { get; set; }

        /// <summary>Gets or sets the map bonus details.</summary>
        [DataMember(Name = "bonuses", Order = 3)]
        public ICollection<MapBonusDTO> Bonuses { get; set; }

        /// <summary>Gets or sets the details per objective.</summary>
        [DataMember(Name = "objectives", Order = 4)]
        public ICollection<MatchObjectiveDTO> Objectives { get; set; }

        /// <summary>Gets or sets the deaths per team.</summary>
        [DataMember(Name = "deaths", Order = 5)]
        public TeamStatDTO Deaths { get; set; }

        /// <summary>Gets or sets the kills per team.</summary>
        [DataMember(Name = "kills", Order = 6)]
        public TeamStatDTO Kills { get; set; }
    }
}