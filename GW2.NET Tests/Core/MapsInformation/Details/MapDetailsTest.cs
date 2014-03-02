using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Common;
using GW2DotNET.V1.Core.MapsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Details
{
    [TestFixture]
    public class MapDetailsTest
    {
        private MapDetails mapDetails;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"map_name\":\"\",\"min_level\":0,\"max_level\":0,\"default_floor\":0,\"floors\":[],\"region_id\":0,\"region_name\":\"\",\"continent_id\":0,\"continent_name\":\"\",\"map_rect\":[[],[]],\"continent_rect\":[[],[]]}";
            this.mapDetails = JsonConvert.DeserializeObject<MapDetails>(input);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_MapNameReflectsInput()
        {
            string expected = string.Empty;
            var actual      = this.mapDetails.MapName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_MinimumLevelReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.mapDetails.MinimumLevel;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_MaximumLevelReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.mapDetails.MaximumLevel;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_DefaultFloorReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.mapDetails.DefaultFloor;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_FloorsReflectsInput()
        {
            var expected = new MapFloors();
            var actual   = this.mapDetails.Floors;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_RegionIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.mapDetails.RegionId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_RegionNameReflectsInput()
        {
            string expected = string.Empty;
            var actual      = this.mapDetails.RegionName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_ContinentIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.mapDetails.ContinentId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_ContinentNameReflectsInput()
        {
            string expected = string.Empty;
            var actual      = this.mapDetails.ContinentName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        public void MapDetails_MapRectangleReflectsInput()
        {
            var expected = default(Rectangle);
            var actual   = this.mapDetails.MapRectangle;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        [Category("maps.json")]
        public void MapDetails_ContinentRectangleReflectsInput()
        {
            var expected = default(Rectangle);
            var actual = this.mapDetails.ContinentRectangle;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("maps.json")]
        [Category("ExtensionData")]
        public void MapDetails_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.mapDetails.ExtensionData);
        }
    }
}
