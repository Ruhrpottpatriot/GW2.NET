// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.WorldVersusWorldInformation.Details;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for details regarding the specified match, including the total score and further details for each map.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details"/> for more information.
    /// </remarks>
    public class MatchDetailsRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatchDetailsRequest"/> class.
        /// </summary>
        /// <param name="matchId">The match ID.</param>
        public MatchDetailsRequest(string matchId)
            : base(new Uri(Resources.MatchDetails + "?match_id={match_id}", UriKind.Relative))
        {
            this.AddUrlSegment("match_id", matchId);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="MatchDetails"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MatchDetails"/>.</returns>
        public IServiceResponse<MatchDetails> GetResponse(IServiceClient handler)
        {
            return base.GetResponse<MatchDetails>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="MatchDetails"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceClient"/> that sends the request over a network and returns an instance of type <see cref="ServiceResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="MatchDetails"/>.</returns>
        public Task<IServiceResponse<MatchDetails>> GetResponseAsync(IServiceClient handler)
        {
            return base.GetResponseAsync<MatchDetails>(handler);
        }
    }
}