// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForAggregateOffer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AggregateOfferDataContract" /> to objects of type <see cref="AggregateOffer" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Commerce;
    using GW2NET.V2.Commerce.Prices.Json;

    /// <summary>Converts objects of type <see cref="AggregateOfferDataContract"/> to objects of type <see cref="AggregateOffer"/>.</summary>
    internal sealed class ConverterForAggregateOffer : IConverter<AggregateOfferDataContract, AggregateOffer>
    {
        /// <summary>Converts the given object of type <see cref="AggregateOfferDataContract"/> to an object of type <see cref="AggregateOffer"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public AggregateOffer Convert(AggregateOfferDataContract value)
        {
            Contract.Assume(value != null);
            return new AggregateOffer
            {
                Quantity = value.Quantity, 
                UnitPrice = value.UnitPrice
            };
        }
    }
}