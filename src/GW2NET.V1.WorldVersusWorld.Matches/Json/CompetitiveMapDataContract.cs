// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitiveMapDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the CompetitiveMapDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.WorldVersusWorld.Matches.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/wvw/match_details")]
    internal sealed class CompetitiveMapDataContract
    {
        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }

        [DataMember(Name = "scores", Order = 1)]
        internal int[] Scores { get; set; }

        [DataMember(Name = "objectives", Order = 2)]
        internal ICollection<ObjectiveDataContract> Objectives { get; set; }

        [DataMember(Name = "bonuses", Order = 3)]
        internal ICollection<MapBonusDataContract> Bonuses { get; set; }
    }
}