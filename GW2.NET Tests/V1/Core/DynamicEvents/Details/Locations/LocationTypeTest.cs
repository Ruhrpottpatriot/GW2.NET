// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationTypeTest.cs" company="">
//   
// </copyright>
// <summary>
//   The location type test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents.Details.Locations
{
    using GW2DotNET.V1.Core.DynamicEvents.Details.Locations.LocationTypes;
    using GW2DotNET.V1.DynamicEvents.Details.Types.Locations;
    using GW2DotNET.V1.DynamicEvents.Details.Types.Locations.LocationTypes;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The location type test.</summary>
    [TestFixture]
    public class LocationTypeTest
    {
        /// <summary>The location type_ cylinder_ type reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void LocationType_Cylinder_TypeReflectsInput()
        {
            const string input = "{\"type\":\"cylinder\"}";
            var location = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expected = LocationType.Cylinder;
            LocationType actual = location.Type;

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<CylinderLocation>(location);
        }

        /// <summary>The location type_ polygon_ type reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void LocationType_Polygon_TypeReflectsInput()
        {
            const string input = "{\"type\":\"poly\"}";
            var location = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expected = LocationType.Polygon;
            LocationType actual = location.Type;

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<PolygonLocation>(location);
        }

        /// <summary>The location type_ sphere_ type reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void LocationType_Sphere_TypeReflectsInput()
        {
            const string input = "{\"type\":\"sphere\"}";
            var location = JsonConvert.DeserializeObject<Location>(input);
            const LocationType expected = LocationType.Sphere;
            LocationType actual = location.Type;

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<SphereLocation>(location);
        }
    }
}