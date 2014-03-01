using System.Drawing;
using GW2DotNET.V1.Core.Drawing;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.DynamicEventsInformationTests.DetailsTests.LocationsTests
{
    [TestFixture]
    public class PolygonLocationTest
    {
        private PolygonLocation polygonLocation;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"poly\",\"center\":[-45685.2,-13819.6,-1113],\"z_range\":[-2389,163],\"points\":[[-49395.8,-15845.5],[-42699.7,-15794.1],[-43053,-14081.4],[-43629.7,-11725.4],[-49647.8,-11651.7]]}";
            this.polygonLocation = JsonConvert.DeserializeObject<PolygonLocation>(input);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_TypeReflectsInput()
        {
            const LocationType expectedLocationType = LocationType.Polygon;
            Assert.AreEqual(expectedLocationType, this.polygonLocation.Type);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_CenterReflectsInput()
        {
            var expectedCenter = new Point3D(-45685.2D, -13819.6D, -1113D);
            Assert.AreEqual(expectedCenter, this.polygonLocation.Center);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_ZRangeReflectsInput()
        {
            var expectedZRange = new Point(-2389, 163);
            Assert.AreEqual(expectedZRange, this.polygonLocation.ZRange);
        }

        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_PointsReflectsInput()
        {
            var expectedPoints = new Points()
            {
                new PointF(-49395.8F,-15845.5F),
                new PointF(-42699.7F,-15794.1F),
                new PointF(-43053F,-14081.4F),
                new PointF(-43629.7F,-11725.4F),
                new PointF(-49647.8F,-11651.7F)
            };
            Assert.AreEqual(expectedPoints, this.polygonLocation.Points);
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
