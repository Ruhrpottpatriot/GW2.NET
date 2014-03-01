using GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.DynamicEventsInformationTests.DetailsTests.LocationsTests
{
    [TestFixture]
    public class LocationTypeTest
    {
        [Test]
        [Category("event_details.json")]
        public void LocationType_Cylinder_TypeReflectsInput()
        {
            const string input                        = "{\"type\":\"cylinder\"}";
            var location                              = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expectedLocationType   = LocationType.Cylinder;

            Assert.AreEqual(expectedLocationType, location.Type);
            Assert.IsInstanceOf<CylinderLocation>(location);
        }

        [Test]
        [Category("event_details.json")]
        public void LocationType_Polygon_TypeReflectsInput()
        {
            const string input                        = "{\"type\":\"poly\"}";
            var location                              = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expectedLocationType   = LocationType.Polygon;

            Assert.AreEqual(expectedLocationType, location.Type);
            Assert.IsInstanceOf<PolygonLocation>(location);
        }

        [Test]
        [Category("event_details.json")]
        public void LocationType_Sphere_TypeReflectsInput()
        {
            const string input                        = "{\"type\":\"sphere\"}";
            var location                              = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expectedLocationType   = LocationType.Sphere;

            Assert.AreEqual(expectedLocationType, location.Type);
            Assert.IsInstanceOf<SphereLocation>(location);
        }
    }
}
