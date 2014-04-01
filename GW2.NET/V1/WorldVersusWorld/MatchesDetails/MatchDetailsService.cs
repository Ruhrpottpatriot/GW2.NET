// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the match details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.MatchesDetails
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.WorldVersusWorld.MatchesDetails.Types;

    /// <summary>Provides the default implementation of the match details service.</summary>
    public class MatchDetailsService : ServiceBase, IMatchDetailsService
    {
        /// <summary>Initializes a new instance of the <see cref="MatchDetailsService"/> class.</summary>
        public MatchDetailsService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MatchDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MatchDetailsService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public MatchDetails GetMatchDetails(string matchId)
        {
            return this.Request<MatchDetails>(new MatchDetailsRequest { MatchId = matchId });
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<MatchDetails> GetMatchDetailsAsync(string matchId)
        {
            return this.GetMatchDetailsAsync(matchId, CancellationToken.None);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken cancellationToken)
        {
            return this.RequestAsync<MatchDetails>(new MatchDetailsRequest { MatchId = matchId }, cancellationToken);
        }
    }
}