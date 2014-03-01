using GW2DotNET.V1.Core.Drawing;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.DynamicEventsInformationTests.DetailsTests.LocationsTests
{
    [TestFixture]
    public class CylinderLocationTest
    {
        private CylinderLocation cylinderLocation;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"cylinder\",\"center\":[-5867.86,-3511.69,-2316.88],\"height\":421.177,\"radius\":1042.44,\"rotation\":1.2224}";
            this.cylinderLocation = JsonConvert.DeserializeObject<CylinderLocation>(input);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_TypeReflectsInput()
        {
            const LocationType expectedLocationType = LocationType.Cylinder;
            Assert.AreEqual(expectedLocationType, this.cylinderLocation.Type);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_CenterReflectsInput()
        {
            var expectedCenter = new Point3D(-5867.86D, -3511.69D, -2316.88D);
            Assert.AreEqual(expectedCenter, this.cylinderLocation.Center);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_HeightReflectsInput()
        {
            const double expectedHeight = 421.177D;
            Assert.AreEqual(expectedHeight, this.cylinderLocation.Height);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_RadiusReflectsInput()
        {
            const double expectedRadius = 1042.44D;
            Assert.AreEqual(expectedRadius, this.cylinderLocation.Radius);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_RotationReflectsInput()
        {
            const double expectedRotation = 1.2224D;
            Assert.AreEqual(expectedRotation, this.cylinderLocation.Rotation);
        }
    }
}
