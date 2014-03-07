// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.BuildInformation;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for the current build ID of the game.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/build"/> for more information.
    /// </remarks>
    public class BuildRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildRequest"/> class.
        /// </summary>
        public BuildRequest()
            : base(new Uri(Resources.Build, UriKind.Relative))
        {
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<Build> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<Build>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Build>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<Build>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Build>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<Build>(serviceClient, cancellationToken);
        }
    }
}