// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorTest.cs" company="">
//   
// </copyright>
// <summary>
//   The floor test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Maps.Floors.Regions;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The floor test.</summary>
    [TestFixture]
    public class FloorTest
    {
        /// <summary>The floor.</summary>
        private Floor floor;

        /// <summary>The floor_ extension data is empty.</summary>
        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Floor_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.floor.ExtensionData);
        }

        /// <summary>The floor_ regions reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Floor_RegionsReflectsInput()
        {
            var expected = new RegionCollection();
            RegionCollection actual = this.floor.Regions;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The floor_ texture dimensions reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Floor_TextureDimensionsReflectsInput()
        {
            Size expected = default(Size);
            Size actual = this.floor.TextureDimensions;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"texture_dims\":[],\"regions\":{}}";
            this.floor = JsonConvert.DeserializeObject<Floor>(input);
        }
    }
}