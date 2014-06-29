// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the matches service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Contracts;

    /// <summary>Provides the default implementation of the matches service.</summary>
    public class MatchService : IMatchService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly MatchDetailsSerializerSettings Settings = new MatchDetailsSerializerSettings();

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MatchService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MatchService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Match GetMatchDetails(Matchup match)
        {
            Preconditions.EnsureNotNull(paramName: "match", value: match);
            var request = new MatchDetailsRequest { MatchId = match.MatchId };
            var result = this.serviceClient.Send(request, new JsonSerializer<Match>(Settings));

            // Patch missing information
            result.StartTime = match.StartTime;
            result.EndTime = match.EndTime;
            result.RedWorld = match.RedWorld;
            result.GreenWorld = match.GreenWorld;
            result.BlueWorld = match.BlueWorld;

            return result;
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(Matchup match)
        {
            return this.GetMatchDetailsAsync(match, CancellationToken.None);
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(Matchup match, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "match", value: match);
            var request = new MatchDetailsRequest { MatchId = match.MatchId };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<Match>(Settings), cancellationToken);
            var t2 = t1.ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Patch missing information
                        result.StartTime = match.StartTime;
                        result.EndTime = match.EndTime;
                        result.RedWorld = match.RedWorld;
                        result.GreenWorld = match.GreenWorld;
                        result.BlueWorld = match.BlueWorld;

                        return result;
                    }, 
                cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public IEnumerable<Matchup> GetMatches()
        {
            var request = new MatchRequest();
            var result = this.serviceClient.Send(request, new JsonSerializer<MatchupCollectionResult>());

            return result.Matchups;
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Matchup>> GetMatchesAsync()
        {
            return this.GetMatchesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Matchup>> GetMatchesAsync(CancellationToken cancellationToken)
        {
            var t1 = this.serviceClient.SendAsync(new MatchRequest(), new JsonSerializer<MatchupCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Matchup>>(task => task.Result.Matchups, cancellationToken);

            return t2;
        }
    }
}