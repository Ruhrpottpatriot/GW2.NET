// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs;

namespace GW2DotNET.V1.RestSharp
{
    /// <summary>
    /// Represents a request for a list of the currently running World versus World matches, with the participating worlds included in the result.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches"/> for more information.
    /// </remarks>
    public class MatchesRequest : ServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatchesRequest"/> class.
        /// </summary>
        public MatchesRequest()
            : base(new Uri(Resources.Matches, UriKind.Relative))
        {
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<MatchesResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<MatchesResult>(serviceClient);
        }

        /// <summary>
        /// Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<MatchesResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<MatchesResult>(serviceClient);
        }
    }
}