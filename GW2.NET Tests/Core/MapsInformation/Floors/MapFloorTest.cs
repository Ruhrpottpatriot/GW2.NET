using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Floors
{
    [TestFixture]
    public class MapFloorTest
    {
        private MapFloor mapFloor;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"texture_dims\":[],\"regions\":{}}";
            this.mapFloor = JsonConvert.DeserializeObject<MapFloor>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void MapFloor_TextureDimensionsReflectsInput()
        {
            var expected = default(Size);
            var actual   = this.mapFloor.TextureDimensions;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void MapFloor_MapRegionsReflectsInput()
        {
            var expected = new MapRegionCollection();
            var actual   = this.mapFloor.MapRegions;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void MapFloor_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.mapFloor.ExtensionData);
        }
    }
}
