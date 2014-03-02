using GW2DotNET.V1.Core.Drawing;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.DynamicEventsInformation.Details.Locations
{
    [TestFixture]
    public class CylinderLocationTest
    {
        private CylinderLocation cylinderLocation;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"cylinder\",\"center\":[],\"height\":0,\"radius\":0,\"rotation\":0}";
            this.cylinderLocation = JsonConvert.DeserializeObject<CylinderLocation>(input);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_TypeReflectsInput()
        {
            const LocationType expected = LocationType.Cylinder;
            var actual                  = this.cylinderLocation.Type;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_CenterReflectsInput()
        {
            var expected = default(Point3D);
            var actual   = this.cylinderLocation.Center;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_HeightReflectsInput()
        {
            const double expected = default(double);
            var actual            = this.cylinderLocation.Height;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_RadiusReflectsInput()
        {
            const double expected = default(double);
            var actual            = this.cylinderLocation.Radius;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_RotationReflectsInput()
        {
            const double expected = default(double);
            var actual            = this.cylinderLocation.Rotation;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        [Category("ExtensionData")]
        public void CylinderLocation_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.cylinderLocation.ExtensionData);
        }
    }
}
