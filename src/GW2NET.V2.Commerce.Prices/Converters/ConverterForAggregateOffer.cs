// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForAggregateOffer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AggregateOfferDataContract" /> to objects of type <see cref="AggregateOffer" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices
{
    using System;

    using GW2NET.Commerce;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="AggregateOfferDataContract"/> to objects of type <see cref="AggregateOffer"/>.</summary>
    internal sealed class ConverterForAggregateOffer : IConverter<AggregateOfferDataContract, AggregateOffer>
    {
        /// <summary>Converts the given object of type <see cref="AggregateOfferDataContract"/> to an object of type <see cref="AggregateOffer"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public AggregateOffer Convert(AggregateOfferDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new AggregateOffer
            {
                Quantity = value.Quantity,
                UnitPrice = value.UnitPrice
            };
        }
    }
}