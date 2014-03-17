// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of the currently running World versus World matches, with the participating worlds included in the result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    /// <summary>Represents a request for a list of the currently running World versus World matches, with the participating worlds included in the result.</summary>
    public class MatchesRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="MatchesRequest" /> class.</summary>
        public MatchesRequest()
            : base(Services.Matches)
        {
        }
    }
}