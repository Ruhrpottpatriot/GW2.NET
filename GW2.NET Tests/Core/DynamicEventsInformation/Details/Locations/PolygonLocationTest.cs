using System.Drawing;
using GW2DotNET.V1.Core.Drawing;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.DynamicEventsInformation.Details.Locations
{
    [TestFixture]
    public class PolygonLocationTest
    {
        private PolygonLocation polygonLocation;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"poly\",\"center\":[],\"z_range\":[],\"points\":[]}";
            this.polygonLocation = JsonConvert.DeserializeObject<PolygonLocation>(input);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_TypeReflectsInput()
        {
            const LocationType expected = LocationType.Polygon;
            var actual                  = this.polygonLocation.Type;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_CenterReflectsInput()
        {
            var expected = default(Point3D);
            var actual   = this.polygonLocation.Center;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_ZRangeReflectsInput()
        {
            var expected = default(Point);
            var actual   = this.polygonLocation.ZRange;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_PointsReflectsInput()
        {
            var expected = new Points();
            var actual   = this.polygonLocation.Points;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        [Category("ExtensionData")]
        public void PolygonLocation_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.polygonLocation.ExtensionData);
        }
    }
}
