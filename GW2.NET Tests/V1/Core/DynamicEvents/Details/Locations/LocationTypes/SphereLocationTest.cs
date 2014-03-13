// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SphereLocationTest.cs" company="">
//   
// </copyright>
// <summary>
//   The sphere location test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents.Details.Locations.LocationTypes
{
    using GW2DotNET.V1.Core.Common.Drawing;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The sphere location test.</summary>
    [TestFixture]
    public class SphereLocationTest
    {
        /// <summary>The sphere location.</summary>
        private SphereLocation sphereLocation;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"sphere\",\"center\":[],\"radius\":0,\"rotation\":0}";
            this.sphereLocation = JsonConvert.DeserializeObject<SphereLocation>(input);
        }

        /// <summary>The sphere location_ center reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void SphereLocation_CenterReflectsInput()
        {
            Point3D expected = default(Point3D);
            Point3D actual = this.sphereLocation.Center;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The sphere location_ extension data is empty.</summary>
        [Test]
        [Category("event_details.json")]
        [Category("ExtensionData")]
        public void SphereLocation_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.sphereLocation.ExtensionData);
        }

        /// <summary>The sphere location_ radius reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void SphereLocation_RadiusReflectsInput()
        {
            const double expected = default(double);
            double actual = this.sphereLocation.Radius;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The sphere location_ rotation reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void SphereLocation_RotationReflectsInput()
        {
            const double expected = default(double);
            double actual = this.sphereLocation.Rotation;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The sphere location_ type reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void SphereLocation_TypeReflectsInput()
        {
            const LocationType expected = LocationType.Sphere;
            LocationType actual = this.sphereLocation.Type;

            Assert.AreEqual(expected, actual);
        }
    }
}