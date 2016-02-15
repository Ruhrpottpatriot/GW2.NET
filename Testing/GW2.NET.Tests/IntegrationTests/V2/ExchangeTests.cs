namespace GW2NET.IntegrationTests.V2
{
    using System;

    using Xunit;

    public class ExchangeTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        [Theory]
        [InlineData(10000)]
        public void GetGems(int coins)
        {
            var result = GW2.Services.Commerce.Exchange.GetGems(coins);
            Assert.NotNull(result);
            Assert.StrictEqual(coins, result.Send);
            Assert.NotInRange(result.Receive, int.MinValue, 0);
            Assert.NotInRange(result.CoinsPerGem, int.MinValue, 0);
            Assert.NotStrictEqual(default(DateTimeOffset), result.Timestamp);
        }

        [Theory]
        [InlineData(10000)]
        public async void GetGemsAsync(int coins)
        {
            var result = await GW2.Services.Commerce.Exchange.GetGemsAsync(coins);
            Assert.NotNull(result);
            Assert.StrictEqual(coins, result.Send);
            Assert.NotInRange(result.Receive, int.MinValue, 0);
            Assert.NotInRange(result.CoinsPerGem, int.MinValue, 0);
            Assert.NotStrictEqual(default(DateTimeOffset), result.Timestamp);
        }

        [Theory]
        [InlineData(1000)]
        public void GetCoins(int gems)
        {
            var result = GW2.Services.Commerce.Exchange.GetCoins(gems);
            Assert.NotNull(result);
            Assert.StrictEqual(gems, result.Send);
            Assert.NotInRange(result.Receive, int.MinValue, 0);
            Assert.NotInRange(result.CoinsPerGem, int.MinValue, 0);
            Assert.NotStrictEqual(default(DateTimeOffset), result.Timestamp);
        }

        [Theory]
        [InlineData(1000)]
        public async void GetCoinsAsync(int gems)
        {
            var result = await GW2.Services.Commerce.Exchange.GetCoinsAsync(gems);
            Assert.NotNull(result);
            Assert.StrictEqual(gems, result.Send);
            Assert.NotInRange(result.Receive, int.MinValue, 0);
            Assert.NotInRange(result.CoinsPerGem, int.MinValue, 0);
            Assert.NotStrictEqual(default(DateTimeOffset), result.Timestamp);
        }
    }
}