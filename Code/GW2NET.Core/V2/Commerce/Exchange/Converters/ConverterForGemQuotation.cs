// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGemQuotation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GemQuotationDataContract" /> to objects of type <see cref="GemQuotation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.V2.Commerce.Exchange.Json;

    /// <summary>Converts objects of type <see cref="GemQuotationDataContract"/> to objects of type <see cref="GemQuotation"/>.</summary>
    internal sealed class ConverterForGemQuotation : IConverter<GemQuotationDataContract, GemQuotation>
    {
        /// <summary>Converts the given object of type <see cref="GemQuotationDataContract"/> to an object of type <see cref="GemQuotation"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public GemQuotation Convert(GemQuotationDataContract value)
        {
            Contract.Assume(value != null);
            return new GemQuotation
            {
                CoinsPerGem = value.CoinsPerGem, 
                Receive = value.Quantity
            };
        }
    }
}