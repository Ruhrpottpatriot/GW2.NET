// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a details request that targets the /v2/commerce/exchange interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a details request that targets the /v2/commerce/exchange interface.</summary>
    internal sealed class ExchangeDetailsRequest : DetailsRequest
    {
        /// <summary>Gets or sets the quantity.</summary>
        public long? Quantity { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/commerce/exchange/{0}";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public override IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            foreach (var parameter in base.GetParameters())
            {
                yield return parameter;
            }

            var quantity = this.Quantity;
            if (quantity.HasValue)
            {
                yield return new KeyValuePair<string, string>("quantity", quantity.Value.ToString(NumberFormatInfo.InvariantInfo));
            }
        }
    }
}