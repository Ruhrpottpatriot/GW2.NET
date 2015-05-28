namespace GW2NET
{
    using NUnit.Framework;

    [TestFixture]
    public class FactoryForV2Tests
    {
        private GW2Bootstrapper bootstrapper;

        [SetUp]
        public void SetUp()
        {
            this.bootstrapper = new GW2Bootstrapper();
        }


        [Test]
        public void BuildTest()
        {
            var build = this.bootstrapper.V2.Builds.GetBuild();

            Assert.IsNotNull(build);
            Assert.That(build.BuildId, Is.GreaterThan(0));
        }

        [Test]
        public void ColorIdTest()
        {
            var ids = this.bootstrapper.V2.Colors.ForDefaultCulture().Discover();

            Assert.IsNotNull(ids);

            Assert.That(ids, Is.All.Not.Null);
            Assert.That(ids, !Is.Empty);
        }

        [Test]
        public void ColorDetailsTest()
        {
            var color = this.bootstrapper.V2.Colors.ForDefaultCulture().Find(5);

            Assert.NotNull(color);
        }

        [Test]
        public void GemsExchangeTest()
        {
            var exchange = this.bootstrapper.V2.Commerce.Exchange.GetCoins(gems: 100);

            Assert.NotNull(exchange);
            Assert.AreEqual(exchange.Send, 100);
        }

        [Test]
        public void CoinsExchangeTest()
        {
            var exchange = this.bootstrapper.V2.Commerce.Exchange.GetGems(coins: 100000);

            Assert.NotNull(exchange);
            Assert.AreEqual(exchange.Send, 100000);
        }
    }
}
