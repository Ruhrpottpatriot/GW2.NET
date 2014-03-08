// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.ColorsInformation.Details;

namespace GW2DotNET.V1.RestSharp.Requests
{
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
            : base(Resources.Colors)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ColorsRequest" /> class.
        /// </summary>
        /// <param name="languageInfo">The output language.</param>
        public ColorsRequest(CultureInfo languageInfo)
            : base(Resources.Colors, languageInfo)
        {
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<DyesResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<DyesResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DyesResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<DyesResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<DyesResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<DyesResult>(serviceClient, cancellationToken);
        }
    }
}