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
        /// Sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="MatchesResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceResponse{TContent}"/> that sends the request over a network and returns an instance of type <see cref="MatchesResult"/>.</param>
        /// <returns>Returns an instance of type <see cref="MatchesResult"/>.</returns>
        public IServiceResponse<MatchesResult> GetResponse(IServiceClient handler)
        {
            return base.GetResponse<MatchesResult>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ServiceClient"/> and retrieves a response whose content is of type <see cref="MatchesResult"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ServiceResponse{TContent}"/> that sends the request over a network and returns an instance of type <see cref="MatchesResult"/>.</param>
        /// <returns>Returns an instance of type <see cref="MatchesResult"/>.</returns>
        public Task<IServiceResponse<MatchesResult>> GetResponseAsync(IServiceClient handler)
        {
            return base.GetResponseAsync<MatchesResult>(handler);
        }
    }
}