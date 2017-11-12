using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2NET
{
    using System.Diagnostics;
    using System.Runtime.Remoting;

    using NUnit.Framework;

    [TestFixture]
    public class FactoryForV2Tests
    {
        [Test]
        public void BuildTest()
        {
            var build = GW2.V2.Builds.GetBuild();

            Assert.IsNotNull(build);
            Assert.That(build.BuildId, Is.GreaterThan(0));
        }

        [Test]
        public void ColorIdTest()
        {
            var ids = GW2.V2.Colors.ForDefaultCulture().Discover();

            Assert.IsNotNull(ids);

            Assert.That(ids, Is.All.Not.Null);
            Assert.That(ids, !Is.Empty);
        }

        [Test]
        public void ColorDetailsTest()
        {
            var color = GW2.V2.Colors.ForDefaultCulture().Find(5);

            Assert.NotNull(color);
        }
    }
}
