// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMatchServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a matches service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.WorldVersusWorld.Matches.Types;

    /// <summary>Provides the interface for a matches service cache.</summary>
    public interface IMatchServiceCache : IMatchService
    {
        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        IEnumerable<Match> GetMatches(bool allowCache);

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        Task<IEnumerable<Match>> GetMatchesAsync(bool allowCache);

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        Task<IEnumerable<Match>> GetMatchesAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of currently running World versus World matches.</summary>
        /// <param name="matches">A collection of currently running World versus World matches.</param>
        void SetMatches(IEnumerable<Match> matches);
    }
}