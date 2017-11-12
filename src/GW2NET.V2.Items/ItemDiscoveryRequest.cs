// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDiscoveryRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a discovery request that targets the /v2/items interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using GW2NET.Common;

    /// <summary>Represents a discovery request that targets the /v2/items interface.</summary>
    internal sealed class ItemDiscoveryRequest : DiscoveryRequest
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/items";
            }
        }
    }
}
