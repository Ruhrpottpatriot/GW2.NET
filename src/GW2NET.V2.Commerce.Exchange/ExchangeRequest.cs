// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for requests that targets the /v2/commerce/exchange interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Provides the base class for requests that targets the /v2/commerce/exchange interface.</summary>
    public abstract class ExchangeRequest : IRequest
    {
        /// <summary>Gets or sets the quantity.</summary>
        public int? Quantity { get; set; }

        public abstract string Resource { get; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            var quantity = this.Quantity;
            if (quantity.HasValue)
            {
                yield return new KeyValuePair<string, string>("quantity", quantity.Value.ToString(NumberFormatInfo.InvariantInfo));
            }
        }
    }
}