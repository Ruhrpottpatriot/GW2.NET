// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForAggregateListing.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AggregateListingDataContract" /> to objects of type <see cref="AggregateListing" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Prices.Converters
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Commerce;
    using GW2NET.V2.Commerce.Prices.Json;

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
            Contract.Requires(converterForAggregateOffer != null);
            this.converterForAggregateOffer = converterForAggregateOffer;
        }

        /// <summary>Converts the given object of type <see cref="AggregateListingDataContract"/> to an object of type <see cref="AggregateListing"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public AggregateListing Convert(AggregateListingDataContract value)
        {
            Contract.Assume(value != null);
            var aggregateListing = new AggregateListing
            {
                ItemId = value.Id
            };
            var buys = value.BuyOffers;
            if (buys != null)
            {
                aggregateListing.BuyOffers = this.converterForAggregateOffer.Convert(buys);
            }
            else
            {
                Debug.Assert(buys != null, "Expected 'buys' for aggregate listing");
            }

            var sells = value.SellOffers;
            if (sells != null)
            {
                aggregateListing.SellOffers = this.converterForAggregateOffer.Convert(sells);
            }
            else
            {
                Debug.Assert(sells != null, "Expected 'sells' for aggregate listing");
            }

            return aggregateListing;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForAggregateOffer != null);
        }
    }
}