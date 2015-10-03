// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDiscoveryRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a discovery request against the /v2/characters endpoint.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts.Characters
{
    using GW2NET.Common;

    /// <summary>Represents a discovery request against the /v2/characters endpoint.</summary>
    public sealed class CharacterDiscoveryRequest : DiscoveryRequest
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/characters";
            }
        }
    }
}