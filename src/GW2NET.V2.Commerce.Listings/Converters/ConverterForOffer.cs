// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForOffer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ListingOfferDataContract" /> to objects of type <see cref="Offer" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Listings
{
    using System.Diagnostics.Contracts;

    using GW2NET.Commerce;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="ListingOfferDataContract"/> to objects of type <see cref="Offer"/>.</summary>
    internal sealed class ConverterForOffer : IConverter<ListingOfferDataContract, Offer>
    {
        /// <summary>Converts the given object of type <see cref="ListingOfferDataContract"/> to an object of type <see cref="Offer"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Offer Convert(ListingOfferDataContract value)
        {
            Contract.Assume(value != null);
            return new Offer
            {
                Listings = value.Listings, 
                UnitPrice = value.UnitPrice, 
                Quantity = value.Quantity
            };
        }
    }
}