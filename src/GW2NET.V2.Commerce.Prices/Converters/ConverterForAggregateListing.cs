// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForAggregateListing.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AggregateListingDataContract" /> to objects of type <see cref="AggregateListing" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices
{
    using System;
    using System.Diagnostics;

    using GW2NET.Commerce;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="AggregateListingDataContract"/> to objects of type <see cref="AggregateListing"/>.</summary>
    internal sealed class ConverterForAggregateListing : IConverter<AggregateListingDataContract, AggregateListing>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<AggregateOfferDataContract, AggregateOffer> converterForAggregateOffer;

        /// <summary>Initializes a new instance of the <see cref="ConverterForAggregateListing"/> class.</summary>
        internal ConverterForAggregateListing()
            : this(new ConverterForAggregateOffer())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForAggregateListing"/> class.</summary>
        /// <param name="converterForAggregateOffer">The converter for <see cref="AggregateOffer"/>.</param>
        internal ConverterForAggregateListing(IConverter<AggregateOfferDataContract, AggregateOffer> converterForAggregateOffer)
        {
            if (converterForAggregateOffer == null)
            {
                throw new ArgumentNullException("converterForAggregateOffer", "Precondition: converterForAggregateOffer != null");
            }

            this.converterForAggregateOffer = converterForAggregateOffer;
        }

        /// <inheritdoc />
        public AggregateListing Convert(AggregateListingDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var aggregateListing = new AggregateListing
            {
                ItemId = value.Id,
                Whitelisted = value.Whitelisted
            };
            var buys = value.BuyOffers;
            if (buys != null)
            {
                aggregateListing.BuyOffers = this.converterForAggregateOffer.Convert(buys);
            }

            Debug.Assert(buys != null, "buys != null");

            var sells = value.SellOffers;
            if (sells != null)
            {
                aggregateListing.SellOffers = this.converterForAggregateOffer.Convert(sells);
            }

            Debug.Assert(sells != null, "Expected 'sells' for aggregate listing");

            return aggregateListing;
        }
    }
}
