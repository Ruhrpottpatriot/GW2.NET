using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregion;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregion.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.MapsInformation.Floors.Regions.Subregion
{
    [TestFixture]
    public class MapTest
    {
        private Map map;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"min_level\":0,\"max_level\":0,\"default_floor\":0,\"map_rect\":[[],[]],\"continent_rect\":[[],[]],\"points_of_interest\":[],\"tasks\":[],\"skill_challenges\":[],\"sectors\":[]}";
            this.map = JsonConvert.DeserializeObject<Map>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.map.Name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_MinimumLevelReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.map.MinimumLevel;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_MaximumLevelReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.map.MaximumLevel;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_DefaultFloorReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.map.DefaultFloor;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_MapRectangleReflectsInput()
        {
            var expected = default(Rectangle);
            var actual   = this.map.MapRectangle;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_ContinentRectangleReflectsInput()
        {
            var expected = default(Rectangle);
            var actual   = this.map.ContinentRectangle;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_PointsOfInterestReflectsInput()
        {
            var expected = new PointsOfInterest();
            var actual   = this.map.PointsOfInterest;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_TasksReflectsInput()
        {
            var expected = new RenownTasks();
            var actual   = this.map.Tasks;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_SkillChallengesReflectsInput()
        {
            var expected = new SkillChallenges();
            var actual   = this.map.SkillChallenges;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Map_SectorsReflectsInput()
        {
            var expected = new Sectors();
            var actual   = this.map.Sectors;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Map_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.map.ExtensionData);
        }
    }
}
