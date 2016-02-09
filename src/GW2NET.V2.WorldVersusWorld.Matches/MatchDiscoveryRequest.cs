// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDiscoveryRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of the currently running World versus World matches, with the participating worlds included in the result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.WorldVersusWorld.Matches
{
    using System.Collections.Generic;

    using GW2NET.Common;

    /// <summary>Represents a request for a list of the currently running World versus World matches, with the participating worlds included in the result.</summary>
    public sealed class MatchDiscoveryRequest : IRequest
    {
        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return "v1/wvw/matches.json";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            yield break;
        }
    }
}