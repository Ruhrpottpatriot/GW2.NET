// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeDiscoveryRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The exchange discovery request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce
{
    using GW2DotNET.Common;

    /// <summary>The exchange discovery request.</summary>
    internal sealed class ExchangeDiscoveryRequest : DiscoveryRequest
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/commerce/exchange";
            }
        }
    }
}