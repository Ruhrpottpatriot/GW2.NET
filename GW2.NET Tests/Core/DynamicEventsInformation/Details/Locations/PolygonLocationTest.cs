using System.Drawing;
using GW2DotNET.V1.Core.Drawing;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.DynamicEventsInformation.Details.Locations
{
    [TestFixture]
    public class PolygonLocationTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"poly\",\"center\":[],\"z_range\":[],\"points\":[]}";
            this.polygonLocation = JsonConvert.DeserializeObject<PolygonLocation>(input);
        }

        private PolygonLocation polygonLocation;

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_CenterReflectsInput()
        {
            Point3D expected = default(Point3D);
            Point3D actual = this.polygonLocation.Center;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        [Category("ExtensionData")]
        public void PolygonLocation_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.polygonLocation.ExtensionData);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_PointsReflectsInput()
        {
            var expected = new PointCollection();
            PointCollection actual = this.polygonLocation.PointCollection;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_TypeReflectsInput()
        {
            const LocationType expected = LocationType.Polygon;
            LocationType actual = this.polygonLocation.Type;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_ZRangeReflectsInput()
        {
            Point expected = default(Point);
            Point actual = this.polygonLocation.ZRange;

            Assert.AreEqual(expected, actual);
        }
    }
}