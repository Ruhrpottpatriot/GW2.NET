using GW2DotNET.Events;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    [TestFixture]
    class WorldDataTest
    {
        private WorldData data;

        [SetUp]
        public void Init()
        {
            data = WorldData.Instance;
        }

        [Test]
        public void GetWorlds()
        {
            var worlds = data.Worlds;

            Assert.IsFalse(worlds == null);
        }

        [Test]
        public void GetMaps()
        {
            var maps = data.Maps;

            Assert.IsFalse(maps == null);
        }
    }
}
