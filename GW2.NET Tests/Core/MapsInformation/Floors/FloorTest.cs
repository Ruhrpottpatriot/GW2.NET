using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.MapsInformation.Floors
{
    [TestFixture]
    public class FloorTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"texture_dims\":[],\"regions\":{}}";
            this.floor = JsonConvert.DeserializeObject<Floor>(input);
        }

        private Floor floor;

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Floor_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.floor.ExtensionData);
        }

        [Test]
        [Category("map_floor.json")]
        public void Floor_RegionsReflectsInput()
        {
            var expected = new RegionCollection();
            RegionCollection actual = this.floor.Regions;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Floor_TextureDimensionsReflectsInput()
        {
            Size expected = default(Size);
            Size actual = this.floor.TextureDimensions;
            Assert.AreEqual(expected, actual);
        }
    }
}