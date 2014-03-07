using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions;
using Newtonsoft.Json;
using NUnit.Framework;
using Region = GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Region;

namespace GW2DotNET_Tests.Core.MapsInformation.Floors.Regions
{
    [TestFixture]
    public class RegionTest
    {
        private Region region;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"label_coord\":[],\"maps\":{}}";
            this.region = JsonConvert.DeserializeObject<Region>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void Region_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.region.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Region_LabelCoordinatesReflectsInput()
        {
            var expected = default(PointF);
            var actual   = this.region.LabelCoordinates;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Region_MapsReflectsInput()
        {
            var expected = new SubregionCollection();
            var actual   = this.region.Maps;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Region_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.region.ExtensionData);
        }
    }
}
