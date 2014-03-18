// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CylinderLocationTest.cs" company="">
//   
// </copyright>
// <summary>
//   The cylinder location test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents.Details.Locations.LocationTypes
{
    using GW2DotNET.V1.Core.Common.Drawing;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The cylinder location test.</summary>
    [TestFixture]
    public class CylinderLocationTest
    {
        /// <summary>The cylinder location.</summary>
        private CylinderLocation cylinderLocation;

        /// <summary>The cylinder location_ center reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_CenterReflectsInput()
        {
            Point3D expected = default(Point3D);
            Point3D actual = this.cylinderLocation.Center;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The cylinder location_ extension data is empty.</summary>
        [Test]
        [Category("event_details.json")]
        [Category("ExtensionData")]
        public void CylinderLocation_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.cylinderLocation.ExtensionData);
        }

        /// <summary>The cylinder location_ height reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_HeightReflectsInput()
        {
            const double expected = default(double);
            double actual = this.cylinderLocation.Height;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The cylinder location_ radius reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_RadiusReflectsInput()
        {
            const double expected = default(double);
            double actual = this.cylinderLocation.Radius;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The cylinder location_ rotation reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_RotationReflectsInput()
        {
            const double expected = default(double);
            double actual = this.cylinderLocation.Rotation;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The cylinder location_ type reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void CylinderLocation_TypeReflectsInput()
        {
            const LocationType expected = LocationType.Cylinder;
            LocationType actual = this.cylinderLocation.Type;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"type\":\"cylinder\",\"center\":[],\"height\":0,\"radius\":0,\"rotation\":0}";
            this.cylinderLocation = (CylinderLocation)JsonConvert.DeserializeObject<Location>(input);
        }
    }
}