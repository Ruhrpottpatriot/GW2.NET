using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregion;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.MapsInformation.Floors.Regions
{
    [TestFixture]
    public class MapRegionTest
    {
        private MapRegion mapRegion;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"label_coord\":[],\"maps\":{}}";
            this.mapRegion = JsonConvert.DeserializeObject<MapRegion>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void MapRegion_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.mapRegion.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void MapRegion_LabelCoordinatesReflectsInput()
        {
            var expected = default(PointF);
            var actual   = this.mapRegion.LabelCoordinates;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void MapRegion_MapsReflectsInput()
        {
            var expected = new Maps();
            var actual   = this.mapRegion.Maps;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void MapRegion_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.mapRegion.ExtensionData);
        }
    }
}
