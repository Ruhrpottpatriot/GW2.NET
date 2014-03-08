using GW2DotNET.V1.Core.MapsInformation.Names;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.MapsInformation.Names
{
    [TestFixture]
    public class MapNameTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"ID\":\"0\",\"name\":\"\"}";
            this.mapName = JsonConvert.DeserializeObject<MapName>(input);
        }

        private MapName mapName;

        [Test]
        [Category("map_names.json")]
        [Category("ExtensionData")]
        public void MapName_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.mapName.ExtensionData);
        }

        [Test]
        [Category("map_names.json")]
        public void MapName_IdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.mapName.Id;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_names.json")]
        public void MapName_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.mapName.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}