// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding the specified match, including the total score and further details for each map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.MatchesDetails
{
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for details regarding the specified match, including the total score and further details for each map.</summary>
    public class MatchDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private string matchId;

        /// <summary>Initializes a new instance of the <see cref="MatchDetailsRequest" /> class.</summary>
        public MatchDetailsRequest()
            : base(Services.MatchDetails)
        {
        }

        /// <summary>Gets or sets the match ID.</summary>
        public string MatchId
        {
            get
            {
                return this.matchId;
            }

            set
            {
                this.Query["match_id"] = this.matchId = value;
            }
        }
    }
}