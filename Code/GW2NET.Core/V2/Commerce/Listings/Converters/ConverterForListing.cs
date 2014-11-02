// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForListing.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ListingDataContract" /> to objects of type <see cref="Listing" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Listings.Converters
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Entities.Commerce;
    using GW2NET.V2.Commerce.Listings.Json;

    /// <summary>Converts objects of type <see cref="ListingDataContract"/> to objects of type <see cref="Listing"/>.</summary>
    internal sealed class ConverterForListing : IConverter<ListingDataContract, Listing>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<ListingOfferDataContract>, ICollection<Offer>> converterForOfferCollection;

        /// <summary>Initializes a new instance of the <see cref="ConverterForListing"/> class.</summary>
        public ConverterForListing()
            : this(new ConverterForCollection<ListingOfferDataContract, Offer>(new ConverterForOffer()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForListing"/> class.</summary>
        /// <param name="converterForOfferCollection">The converter for <see cref="ICollection{Offer}"/>.</param>
        internal ConverterForListing(IConverter<ICollection<ListingOfferDataContract>, ICollection<Offer>> converterForOfferCollection)
        {
            Contract.Requires(converterForOfferCollection != null);
            this.converterForOfferCollection = converterForOfferCollection;
        }

        /// <summary>Converts the given object of type <see cref="ListingDataContract"/> to an object of type <see cref="Listing"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Listing Convert(ListingDataContract value)
        {
            Contract.Assume(value != null);
            var listing = new Listing { ItemId = value.Id };

            var buys = value.BuyOffers;
            if (buys != null)
            {
                listing.BuyOffers = this.converterForOfferCollection.Convert(buys) ?? new List<Offer>(0);
            }
            else
            {
                Debug.Assert(buys != null, "Expected 'buys' for listing");
            }

            var sells = value.SellOffers;
            if (sells != null)
            {
                listing.SellOffers = this.converterForOfferCollection.Convert(sells) ?? new List<Offer>(0);
            }
            else
            {
                Debug.Assert(sells != null, "Expected 'sells' for listing");
            }

            return listing;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForOfferCollection != null);
        }
    }
}