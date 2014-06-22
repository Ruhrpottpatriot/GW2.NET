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
    using GW2DotNET.V1.WorldVersusWorld.Matches.Contracts;

    /// <summary>Provides the default implementation of the matches service.</summary>
    public class MatchService : IMatchService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MatchService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MatchService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public IEnumerable<Match> GetMatches()
        {
            return this.serviceClient.Send(new MatchRequest(), new JsonSerializer<MatchCollection>());
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Match>> GetMatchesAsync()
        {
            return this.GetMatchesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Match>> GetMatchesAsync(CancellationToken cancellationToken)
        {
            var t1 = this.serviceClient.SendAsync(new MatchRequest(), new JsonSerializer<MatchCollection>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Match>>(task => task.Result, cancellationToken);

            return t2;
        }
    }
}