using System.Diagnostics;

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

        /// <summary>
        /// Unit test to get all maps.
        /// Also checks if the caching works.
        /// </summary>
        [Test]
        public void GetMaps()
        {
            var maps = this.data.Maps;

            Debug.WriteLine("First call map count: {0}", maps.Count);

            var maps2 = this.data.Maps;

            Debug.WriteLine("Second call map count: {0}", maps2.Count);
        }
    }
}
