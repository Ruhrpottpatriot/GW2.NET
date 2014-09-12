// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The exchange details request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2DotNET.V2.Common;

    /// <summary>The exchange details request.</summary>
    public class ExchangeDetailsRequest : DetailsRequest
    {
        /// <summary>Gets or sets the quantity.</summary>
        public int Quantity { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/commerce/exchange/" + this.Identifier;
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public override IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            yield return new KeyValuePair<string, string>("quantity", this.Quantity.ToString(NumberFormatInfo.InvariantInfo));
        }
    }
}