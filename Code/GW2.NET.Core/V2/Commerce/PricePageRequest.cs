// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricePageRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The price page request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce
{
    using GW2DotNET.V2.Common;

    /// <summary>The price page request.</summary>
    public class PricePageRequest : PageRequest
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/commerce/prices";
            }
        }
    }
}