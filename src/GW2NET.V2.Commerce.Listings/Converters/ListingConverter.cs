// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListingConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ListingDTO" /> to objects of type <see cref="Listing" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Listings.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.V2.Commerce.Listings.Json;

    /// <summary>Converts objects of type <see cref="ListingDTO"/> to objects of type <see cref="Listing"/>.</summary>
    public sealed class ListingConverter : IConverter<ListingDTO, Listing>
    {
        private readonly IConverter<ICollection<ListingOfferDTO>, ICollection<Offer>> offerCollectionConverter;

        public ListingConverter(IConverter<ICollection<ListingOfferDTO>, ICollection<Offer>> offerCollectionConverter)
        {
            if (offerCollectionConverter == null)
            {
                throw new ArgumentNullException("offerCollectionConverter");
            }

            this.offerCollectionConverter = offerCollectionConverter;
        }

        /// <summary>Converts the given object of type <see cref="ListingDTO"/> to an object of type <see cref="Listing"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Listing Convert(ListingDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state is IResponse");
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", "state");
            }

            return new Listing
            {
                ItemId = value.Id,
                BuyOffers = this.offerCollectionConverter.Convert(value.BuyOffers, value),
                SellOffers = this.offerCollectionConverter.Convert(value.SellOffers, value),
                Timestamp = response.Date
            };
        }
    }
}