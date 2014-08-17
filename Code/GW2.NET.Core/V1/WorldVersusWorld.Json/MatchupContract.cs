// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchupContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World matchup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents a World versus World matchup.</summary>
    [DataContract]
    public sealed class MatchupContract
    {
        /// <summary>Gets or sets the blue world identifier.</summary>
        [DataMember(Name = "blue_world_id", Order = 2)]
        public int BlueWorldId { get; set; }

        /// <summary>Gets or sets the timestamp (UTC) of when the match ends.</summary>
        [DataMember(Name = "end_time", Order = 5)]
        public string EndTime { get; set; }

        /// <summary>Gets or sets the green world identifier.</summary>
        [DataMember(Name = "green_world_id", Order = 3)]
        public int GreenWorldId { get; set; }

        /// <summary>Gets or sets the match identifier.</summary>
        [DataMember(Name = "wvw_match_id", Order = 0)]
        public string MatchId { get; set; }

        /// <summary>Gets or sets the red world identifier.</summary>
        [DataMember(Name = "red_world_id", Order = 1)]
        public int RedWorldId { get; set; }

        /// <summary>Gets or sets the timestamp (UTC) of when the match started.</summary>
        [DataMember(Name = "start_time", Order = 4)]
        public string StartTime { get; set; }
    }
}