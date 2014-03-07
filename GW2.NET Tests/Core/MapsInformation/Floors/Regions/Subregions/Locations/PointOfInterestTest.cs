using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    [TestFixture]
    public class PointOfInterestTest
    {
        private PointOfInterest pointOfInterest;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"poi_id\":0,\"name\":\"\",\"type\":\"unknown\",\"floor\":0,\"coord\":[]}";
            this.pointOfInterest = JsonConvert.DeserializeObject<PointOfInterest>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void PointOfInterest_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.pointOfInterest.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void PointOfInterest_TypeReflectsInput()
        {
            const PointOfInterestType expected = default(PointOfInterestType);
            var actual                         = this.pointOfInterest.Type;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void PointOfInterest_FloorReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.pointOfInterest.Floor;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void PointOfInterest_CoordinatesReflectsInput()
        {
            var expected = default(PointF);
            var actual   = this.pointOfInterest.Coordinates;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void PointOfInterest_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.pointOfInterest.ExtensionData);
        }
    }
}
