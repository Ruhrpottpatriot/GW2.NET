using GW2DotNET.V1.Core.MapsInformation.Names;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.MapsInformation.Names
{
    [TestFixture]
    public class MapNameTest
    {
        private MapName mapName;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"id\":\"0\",\"name\":\"\"}";
            this.mapName = JsonConvert.DeserializeObject<MapName>(input);
        }

        [Test]
        [Category("map_names.json")]
        public void MapName_IdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.mapName.Id;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_names.json")]
        public void MapName_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.mapName.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_names.json")]
        [Category("ExtensionData")]
        public void MapName_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.mapName.ExtensionData);
        }
    }
}
