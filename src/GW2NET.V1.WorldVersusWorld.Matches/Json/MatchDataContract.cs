// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.WorldVersusWorld.Matches.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/wvw/match_details")]
    internal sealed class MatchDataContract
    {
        [DataMember(Name = "match_id", Order = 0)]
        internal string MatchId { get; set; }

        [DataMember(Name = "scores", Order = 1)]
        internal int[] Scores { get; set; }

        [DataMember(Name = "maps", Order = 2)]
        internal ICollection<CompetitiveMapDataContract> Maps { get; set; }
    }
}