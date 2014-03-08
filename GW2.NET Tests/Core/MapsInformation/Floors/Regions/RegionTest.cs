using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions;
using Newtonsoft.Json;
using NUnit.Framework;
using Region = GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Region;

namespace GW2DotNET.Core.MapsInformation.Floors.Regions
{
    [TestFixture]
    public class RegionTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"label_coord\":[],\"maps\":{}}";
            this.region = JsonConvert.DeserializeObject<Region>(input);
        }

        private Region region;

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Region_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.region.ExtensionData);
        }

        [Test]
        [Category("map_floor.json")]
        public void Region_LabelCoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.region.LabelCoordinates;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Region_MapsReflectsInput()
        {
            var expected = new SubregionCollection();
            SubregionCollection actual = this.region.Maps;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Region_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.region.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}