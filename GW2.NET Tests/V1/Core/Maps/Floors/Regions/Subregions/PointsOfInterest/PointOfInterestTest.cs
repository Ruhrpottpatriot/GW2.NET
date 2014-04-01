// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestTest.cs" company="">
//   
// </copyright>
// <summary>
//   The point of interest test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions.Subregions.PointsOfInterest
{
    using System.Drawing;

    using GW2DotNET.V1.MapsFloors.Types.Regions.Subregions.PointsOfInterest;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The point of interest test.</summary>
    [TestFixture]
    public class PointOfInterestTest
    {
        /// <summary>The point of interest.</summary>
        private PointOfInterest pointOfInterest;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"poi_id\":0,\"name\":\"\",\"type\":\"unknown\",\"floor\":0,\"coord\":[]}";
            this.pointOfInterest = JsonConvert.DeserializeObject<PointOfInterest>(input);
        }

        /// <summary>The point of interest_ coordinates reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void PointOfInterest_CoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.pointOfInterest.Coordinates;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The point of interest_ extension data is empty.</summary>
        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void PointOfInterest_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.pointOfInterest.ExtensionData);
        }

        /// <summary>The point of interest_ floor reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void PointOfInterest_FloorReflectsInput()
        {
            const int expected = default(int);
            int actual = this.pointOfInterest.Floor;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The point of interest_ name reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void PointOfInterest_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.pointOfInterest.Name;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The point of interest_ type reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void PointOfInterest_TypeReflectsInput()
        {
            const PointOfInterestType expected = default(PointOfInterestType);
            PointOfInterestType actual = this.pointOfInterest.Type;

            Assert.AreEqual(expected, actual);
        }
    }
}