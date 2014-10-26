// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListingDiscoveryRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a discovery request that targets the /v2/commerce/listings interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Listings
{
    using System.Collections.Generic;

    using GW2NET.Common;

    /// <summary>Represents a discovery request that targets the /v2/commerce/listings interface.</summary>
    internal sealed class ListingDiscoveryRequest : IRequest
    {
        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return "/v2/commerce/listings";
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