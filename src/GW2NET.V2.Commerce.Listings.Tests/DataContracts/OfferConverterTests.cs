namespace GW2NET.V2.Commerce.Listings.DataContracts
{
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
            var value = new ListingOfferDataContract
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
