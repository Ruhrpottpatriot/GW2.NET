// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchupDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchupDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.WorldVersusWorld.Matches.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/wvw/matches")]
    internal sealed class MatchupDataContract
    {
        [DataMember(Name = "wvw_match_id", Order = 0)]
        internal string MatchId { get; set; }

        [DataMember(Name = "red_world_id", Order = 1)]
        internal int RedWorldId { get; set; }

        [DataMember(Name = "blue_world_id", Order = 2)]
        internal int BlueWorldId { get; set; }

        [DataMember(Name = "green_world_id", Order = 3)]
        internal int GreenWorldId { get; set; }

        [DataMember(Name = "start_time", Order = 4)]
        internal string StartTime { get; set; }

        [DataMember(Name = "end_time", Order = 5)]
        internal string EndTime { get; set; }
    }
}
