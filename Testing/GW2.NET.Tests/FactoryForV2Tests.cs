// <copyright file="FactoryForV2Tests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

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
            var build = this.bootstrapper.Services.Builds.GetBuild();

            Assert.IsNotNull(build);
            Assert.That(build.BuildId, Is.GreaterThan(0));
        }

        [Test]
        public void ColorIdTest()
        {
            var ids = this.bootstrapper.Services.Colors.ForDefaultCulture().Discover();

            Assert.IsNotNull(ids);

            Assert.That(ids, Is.All.Not.Null);
            Assert.That(ids, !Is.Empty);
        }

        [Test]
        public void ColorDetailsTest()
        {
            var color = this.bootstrapper.Services.Colors.ForDefaultCulture().Find(5);

            Assert.NotNull(color);
        }

        [Test]
        public void GemsExchangeTest()
        {
            var exchange = this.bootstrapper.Services.Commerce.Exchange.GetCoins(gems: 100);

            Assert.NotNull(exchange);
            Assert.AreEqual(exchange.Send, 100);
        }

        [Test]
        public void CoinsExchangeTest()
        {
            var exchange = this.bootstrapper.Services.Commerce.Exchange.GetGems(coins: 100000);

            Assert.NotNull(exchange);
            Assert.AreEqual(exchange.Send, 100000);
        }
    }
}
