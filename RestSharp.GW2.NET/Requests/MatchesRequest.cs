// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of the currently running World versus World matches, with the participating worlds
//   included in the result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.WorldVersusWorld.Matches;

    /// <summary>
    ///     Represents a request for a list of the currently running World versus World matches, with the participating worlds
    ///     included in the result.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches" /> for more information.
    /// </remarks>
    public class MatchesRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MatchesRequest" /> class.
        /// </summary>
        public MatchesRequest()
            : base(Services.Matches)
        {
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<MatchesResult> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<MatchesResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MatchesResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<MatchesResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MatchesResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<MatchesResult>(serviceClient, cancellationToken);
        }
    }
}