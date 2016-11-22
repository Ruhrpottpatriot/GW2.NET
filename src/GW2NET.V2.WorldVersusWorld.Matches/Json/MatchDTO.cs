// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Matches.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class MatchDTO
    {
        /// <summary>Gets or sets the match id.</summary>
        [DataMember(Name = "match_id", Order = 0)]
        public string MatchId { get; set; }

        /// <summary>Gets or sets the start time.</summary>
        [DataMember(Name = "start_time", Order = 1)]
        public string StartTime { get; set; }

        /// <summary>Gets or sets the end time.</summary>
        [DataMember(Name = "end_time", Order = 2)]
        public string EndTime { get; set; }

        /// <summary>Gets or sets the scores per team.</summary>
        [DataMember(Name = "scores", Order = 3)]
        public int[] Scores { get; set; }

        /// <summary>Gets or sets the teams' world ids.</summary>
        [DataMember(Name = "worlds", Order = 4)]
        public int[] Worlds { get; set; }

        /// <summary>Gets or sets the deaths per team.</summary>
        [DataMember(Name = "deaths", Order = 5)]
        public int[] Deaths { get; set; }

        /// <summary>Gets or sets the kills per team.</summary>
        [DataMember(Name = "kills", Order = 6)]
        public int[] Kills { get; set; }

        /// <summary>Gets or sets the details per map.</summary>
        [DataMember(Name = "maps", Order = 7)]
        public ICollection<CompetitiveMapDTO> Maps { get; set; }
    }
}