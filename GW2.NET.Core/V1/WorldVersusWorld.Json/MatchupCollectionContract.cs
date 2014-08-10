// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchupCollectionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of matchups.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Wraps a collection of matchups.</summary>
    [DataContract]
    public sealed class MatchupCollectionContract
    {
        /// <summary>Gets or sets a collection of matches.</summary>
        [DataMember(Name = "wvw_matches", Order = 0)]
        public ICollection<MatchupContract> Matchups { get; set; }
    }
}