﻿// --------------------------------------------------------------------------------------------------------------------
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
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/wvw/match_details")]
    public sealed class MatchDTO
    {
        [DataMember(Name = "match_id", Order = 0)]
        public string MatchId { get; set; }

        [DataMember(Name = "scores", Order = 1)]
        public int[] Scores { get; set; }

        [DataMember(Name = "maps", Order = 2)]
        public ICollection<CompetitiveMapDTO> Maps { get; set; }
    }
}