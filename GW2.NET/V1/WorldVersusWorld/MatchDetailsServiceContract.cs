// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The match details service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld
{
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Entities.WorldVersusWorld;

    /// <summary>The match details service contract.</summary>
    [ContractClassFor(typeof(IMatchDetailsService))]
    internal abstract class MatchDetailsServiceContract : IMatchDetailsService
    {
        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Match GetMatchDetails(string match)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(string match)
        {
            Contract.Ensures(Contract.Result<Task<Match>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="match">The match identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public Task<Match> GetMatchDetailsAsync(string match, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Match>>() != null);
            throw new System.NotImplementedException();
        }
    }
}