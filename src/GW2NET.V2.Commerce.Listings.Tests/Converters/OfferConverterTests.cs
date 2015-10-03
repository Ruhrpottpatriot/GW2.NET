// <copyright file="OfferConverterTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Commerce.Listings.Converters
{
    using GW2NET.V2.Commerce.Listings.Json;

    using Xunit;

    public class OfferConverterTests
    {
        [Theory]
        [InlineData(2, 106, 500)]
        [InlineData(1, 103, 192)]
        [InlineData(7, 29, 1750)]
        [InlineData(1, 56013, 1)]
        public void Convert(int listings, int unitPrice, int quantity)
        {
            var converter = new OfferConverter();
            var value = new ListingOfferDTO
            {
                Listings = listings,
                UnitPrice = unitPrice,
                Quantity = quantity
            };

            var result = converter.Convert(value, null);

            Assert.NotNull(result);
            Assert.Equal(listings, result.Listings);
            Assert.Equal(unitPrice, result.UnitPrice);
            Assert.Equal(quantity, result.Quantity);
        }
    }
}
