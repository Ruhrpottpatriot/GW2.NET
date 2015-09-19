// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OfferConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ListingOfferDTO" /> to objects of type <see cref="Offer" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Listings.Converters
{
    using System;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.V2.Commerce.Listings.Json;

    /// <summary>Converts objects of type <see cref="ListingOfferDTO"/> to objects of type <see cref="Offer"/>.</summary>
    public sealed class OfferConverter : IConverter<ListingOfferDTO, Offer>
    {
        /// <summary>Converts the given object of type <see cref="ListingOfferDTO"/> to an object of type <see cref="Offer"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Offer Convert(ListingOfferDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new Offer
            {
                Listings = value.Listings,
                UnitPrice = value.UnitPrice,
                Quantity = value.Quantity
            };
        }
    }
}