// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapTest.cs" company="">
//   
// </copyright>
// <summary>
//   The map test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Maps.Floors;
    using GW2DotNET.V1.Maps.Contracts;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The map test.</summary>
    [TestFixture]
    public class MapTest
    {
        /// <summary>The map.</summary>
        private Map map;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input =
                "{\"map_name\":\"\",\"min_level\":0,\"max_level\":0,\"default_floor\":0,\"floors\":[],\"region_id\":0,\"region_name\":\"\",\"continent_id\":0,\"continent_name\":\"\",\"map_rect\":[[],[]],\"continent_rect\":[[],[]]}";
            this.map = JsonConvert.DeserializeObject<Map>(input);
        }

        /// <summary>The map_ continent id reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_ContinentIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.map.ContinentId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ continent name reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_ContinentNameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.map.ContinentName;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ continent rectangle reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_ContinentRectangleReflectsInput()
        {
            Rectangle expected = default(Rectangle);
            Rectangle actual = this.map.ContinentRectangle;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ default floor reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_DefaultFloorReflectsInput()
        {
            const int expected = default(int);
            int actual = this.map.DefaultFloor;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ extension data is empty.</summary>
        [Test]
        [Category("maps.json")]
        [Category("ExtensionData")]
        public void Map_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.map.ExtensionData);
        }

        /// <summary>The map_ floors reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_FloorsReflectsInput()
        {
            var expected = new FloorCollection();
            FloorCollection actual = this.map.Floors;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ map name reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_MapNameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.map.MapName;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ map rectangle reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_MapRectangleReflectsInput()
        {
            Rectangle expected = default(Rectangle);
            Rectangle actual = this.map.MapRectangle;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ maximum level reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_MaximumLevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.map.MaximumLevel;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ minimum level reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_MinimumLevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.map.MinimumLevel;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ region id reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_RegionIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.map.RegionId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map_ region name reflects input.</summary>
        [Test]
        [Category("maps.json")]
        public void Map_RegionNameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.map.RegionName;

            Assert.AreEqual(expected, actual);
        }
    }
}