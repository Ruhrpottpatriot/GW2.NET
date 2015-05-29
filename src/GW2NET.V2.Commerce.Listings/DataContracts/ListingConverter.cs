// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListingConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ListingDataContract" /> to objects of type <see cref="Listing" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Listings.DataContracts
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Commerce;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="ListingDataContract"/> to objects of type <see cref="Listing"/>.</summary>
    public sealed class ListingConverter : IConverter<ListingDataContract, Listing>
    {
        private readonly IConverter<ICollection<ListingOfferDataContract>, ICollection<Offer>> offerCollectionConverter;

        public ListingConverter(IConverter<ICollection<ListingOfferDataContract>, ICollection<Offer>> offerCollectionConverter)
        {
            if (offerCollectionConverter == null)
            {
                throw new ArgumentNullException("offerCollectionConverter", "Precondition: offerCollectionConverter != null");
            }

            this.offerCollectionConverter = offerCollectionConverter;
        }

        /// <summary>Converts the given object of type <see cref="ListingDataContract"/> to an object of type <see cref="Listing"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Listing Convert(ListingDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Listing
            {
                ItemId = value.Id,
                BuyOffers = this.offerCollectionConverter.Convert(value.BuyOffers, state),
                SellOffers = this.offerCollectionConverter.Convert(value.SellOffers, state)
            };
        }
    }
}