// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ObjectiveDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Matches.Json
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class MatchObjectiveDTO
    {
        /// <summary>Objective id</summary>
        [DataMember(Name = "id", Order = 0)]
        public string Id { get; set; }

        /// <summary>Type of objective</summary>
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        /// <summary>Team color that owns the objective.</summary>
        [DataMember(Name = "owner", Order = 2)]
        public string Owner { get; set; }

        /// <summary>Timestamp of last flip of the objective.</summary>
        [DataMember(Name = "last_flipped", Order = 3)]
        public string LastFlipped { get; set; }

        /// <summary>Guild Id which has claimed the objective.</summary>
        [DataMember(Name = "claimed_by", Order = 4)]
        public string ClaimedBy { get; set; }

        /// <summary>Timestamp when objective was claimed.</summary>
        [DataMember(Name = "claimed_at", Order = 5)]
        public string ClaimedAt { get; set; }
    }
}