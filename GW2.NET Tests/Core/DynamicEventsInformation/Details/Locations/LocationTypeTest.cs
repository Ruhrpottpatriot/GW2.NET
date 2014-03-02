using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.DynamicEventsInformation.Details.Locations
{
    [TestFixture]
    public class LocationTypeTest
    {
        [Test]
        [Category("event_details.json")]
        public void LocationType_Cylinder_TypeReflectsInput()
        {
            const string input          = "{\"type\":\"cylinder\"}";
            var location                = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expected = LocationType.Cylinder;
            var actual                  = location.Type;

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<CylinderLocation>(location);
        }

        [Test]
        [Category("event_details.json")]
        public void LocationType_Polygon_TypeReflectsInput()
        {
            const string input          = "{\"type\":\"poly\"}";
            var location                = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expected = LocationType.Polygon;
            var actual                  = location.Type;

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<PolygonLocation>(location);
        }

        [Test]
        [Category("event_details.json")]
        public void LocationType_Sphere_TypeReflectsInput()
        {
            const string input          = "{\"type\":\"sphere\"}";
            var location                = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expected = LocationType.Sphere;
            var actual                  = location.Type;

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<SphereLocation>(location);
        }
    }
}
