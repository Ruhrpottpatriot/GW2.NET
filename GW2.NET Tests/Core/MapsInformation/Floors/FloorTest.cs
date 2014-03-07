using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Floors
{
    [TestFixture]
    public class FloorTest
    {
        private Floor floor;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"texture_dims\":[],\"regions\":{}}";
            this.floor = JsonConvert.DeserializeObject<Floor>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void Floor_TextureDimensionsReflectsInput()
        {
            var expected = default(Size);
            var actual   = this.floor.TextureDimensions;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Floor_RegionsReflectsInput()
        {
            var expected = new RegionCollection();
            var actual   = this.floor.Regions;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Floor_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.floor.ExtensionData);
        }
    }
}
