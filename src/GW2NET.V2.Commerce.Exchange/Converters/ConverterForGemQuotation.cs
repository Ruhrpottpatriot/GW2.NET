// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGemQuotation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GemQuotationDataContract" /> to objects of type <see cref="GemQuotation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange
{
    using System;

    using GW2NET.Commerce;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="GemQuotationDataContract"/> to objects of type <see cref="GemQuotation"/>.</summary>
    internal sealed class ConverterForGemQuotation : IConverter<GemQuotationDataContract, GemQuotation>
    {
        /// <inheritdoc />
        public GemQuotation Convert(GemQuotationDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new GemQuotation
            {
                CoinsPerGem = value.CoinsPerGem,
                Receive = value.Quantity
            };
        }
    }
}