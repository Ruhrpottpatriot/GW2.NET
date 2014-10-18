// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class MatchContract
    {
        [DataMember(Name = "maps", Order = 2)]
        internal ICollection<CompetitiveMapContract> Maps { get; set; }

        [DataMember(Name = "match_id", Order = 0)]
        internal string MatchId { get; set; }

        [DataMember(Name = "scores", Order = 1)]
        internal int[] Scores { get; set; }
    }
}