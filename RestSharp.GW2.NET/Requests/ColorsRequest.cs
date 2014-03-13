// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding dyes in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.Colors;

    /// <summary>
    ///     Represents a request for information regarding dyes in the game.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/colors" /> for more information.
    /// </remarks>
    public class ColorsRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ColorsRequest" /> class.
        /// </summary>
        public ColorsRequest()
            : base(Services.Colors)
        {
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<ColorsResult> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<ColorsResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<ColorsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<ColorsResult>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<ColorsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<ColorsResult>(serviceClient, cancellationToken);
        }
    }
}