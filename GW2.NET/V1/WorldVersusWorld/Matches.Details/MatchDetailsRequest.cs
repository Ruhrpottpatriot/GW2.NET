// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding the specified match, including the total score and further details for each map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Details
{
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for details regarding the specified match, including the total score and further details for each map.</summary>
    public class MatchDetailsRequest : IMatchRequest
    {
        /// <summary>Gets or sets the match identifier.</summary>
        public string MatchId { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return Services.MatchDetails;
            }
        }
    }
}