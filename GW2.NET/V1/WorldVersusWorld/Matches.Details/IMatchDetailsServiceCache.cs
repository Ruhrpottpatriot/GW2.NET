// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMatchDetailsServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a match details service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Details
{
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Details.Types;

    /// <summary>Provides the interface for a match details service cache.</summary>
    public interface IMatchDetailsServiceCache : IMatchDetailsService
    {
        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        MatchDetails GetMatchDetails(string matchId, bool allowCache);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        Task<MatchDetails> GetMatchDetailsAsync(string matchId, bool allowCache);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a World versus World match and its details.</summary>
        /// <param name="matchDetails">A World versus World match and its details.</param>
        void SetMatchDetails(MatchDetails matchDetails);

        /// <summary>Sets a World versus World match and its details.</summary>
        /// <param name="matchDetails">A World versus World match and its details.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetMatchDetails(MatchDetails matchDetails, CacheItemParameters parameters);
    }
}