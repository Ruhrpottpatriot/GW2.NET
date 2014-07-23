// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World match.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a World versus World match.</summary>
    public sealed class MatchContract : ServiceContract
    {
        /// <summary>Gets or sets the list of maps.</summary>
        [DataMember(Name = "maps", Order = 2)]
        public ICollection<CompetitiveMapContract> Maps { get; set; }

        /// <summary>Gets or sets the match identifier.</summary>
        [DataMember(Name = "match_id", Order = 0)]
        public string MatchId { get; set; }

        /// <summary>Gets or sets the total scores.</summary>
        [DataMember(Name = "scores", Order = 1)]
        public int[] Scores { get; set; }
    }
}