// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the match details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches
{
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Contracts;

    /// <summary>Provides the default implementation of the match details service.</summary>
    public class MatchDetailsService : IMatchDetailsService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly MatchDetailsSerializerSettings Settings = new MatchDetailsSerializerSettings();

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MatchDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MatchDetailsService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Match GetMatchDetails(string matchId)
        {
            var request = new MatchDetailsRequest { MatchId = matchId };
            return this.serviceClient.Send(request, new JsonSerializer<Match>(Settings));
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(string matchId)
        {
            return this.GetMatchDetailsAsync(matchId, CancellationToken.None);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(string matchId, CancellationToken cancellationToken)
        {
            var request = new MatchDetailsRequest { MatchId = matchId };
            return this.serviceClient.SendAsync(request, new JsonSerializer<Match>(Settings), cancellationToken);
        }
    }
}