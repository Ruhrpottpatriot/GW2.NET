using GW2DotNET.V1.Core.Drawing;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.DynamicEventsInformationTests.DetailsTests.LocationsTests
{
    [TestFixture]
    public class SphereLocationTest
    {
        private SphereLocation sphereLocation;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"sphere\",\"center\":[13137.8,-2747.37,-2160.03],\"radius\":5000,\"rotation\":4.68689}";
            this.sphereLocation = JsonConvert.DeserializeObject<SphereLocation>(input);
        }

        [Test]
        [Category("event_details.json")]
        public void SphereLocation_TypeReflectsInput()
        {
            const LocationType expectedLocationType = LocationType.Sphere;
            Assert.AreEqual(expectedLocationType, this.sphereLocation.Type);
        }

        [Test]
        [Category("event_details.json")]
        public void SphereLocation_CenterReflectsInput()
        {
            var expectedCenter = new Point3D(13137.8D, -2747.37D, -2160.03D);
            Assert.AreEqual(expectedCenter, this.sphereLocation.Center);
        }

        [Test]
        [Category("event_details.json")]
        public void SphereLocation_RadiusReflectsInput()
        {
            const double expectedRadius = 5000D;
            Assert.AreEqual(expectedRadius, this.sphereLocation.Radius);
        }

        [Test]
        [Category("event_details.json")]
        public void SphereLocation_RotationReflectsInput()
        {
            const double expectedRotation = 4.68689D;
            Assert.AreEqual(expectedRotation, this.sphereLocation.Rotation);
        }


    }
}
