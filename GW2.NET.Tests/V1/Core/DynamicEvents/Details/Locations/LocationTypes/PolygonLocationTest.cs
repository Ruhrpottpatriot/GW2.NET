// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolygonLocationTest.cs" company="">
//   
// </copyright>
// <summary>
//   The polygon location test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents.Details.Locations.LocationTypes
{
    using System.Drawing;

    using GW2DotNET.V1.Common.Drawing;
    using GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations;
    using GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations.LocationTypes;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The polygon location test.</summary>
    [TestFixture]
    public class PolygonLocationTest
    {
        /// <summary>The polygon location.</summary>
        private PolygonLocation polygonLocation;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"poly\",\"center\":[],\"z_range\":[],\"points\":[]}";
            this.polygonLocation = (PolygonLocation)JsonConvert.DeserializeObject<Location>(input);
        }

        /// <summary>The polygon location_ center reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_CenterReflectsInput()
        {
            Point3D expected = default(Point3D);
            Point3D actual = this.polygonLocation.Center;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The polygon location_ extension data is empty.</summary>
        [Test]
        [Category("event_details.json")]
        [Category("ExtensionData")]
        public void PolygonLocation_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.polygonLocation.ExtensionData);
        }

        /// <summary>The polygon location_ points reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_PointsReflectsInput()
        {
            var expected = new PointCollection();
            PointCollection actual = this.polygonLocation.Points;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The polygon location_ type reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void PolygonLocation_TypeReflectsInput()
        {
            const LocationType expected = LocationType.Polygon;
            LocationType actual = this.polygonLocation.Type;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The polygon location_ z range reflects input.</summary>
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