using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Floors.Regions.Subregions
{
    [TestFixture]
    public class SubregionTest
    {
        private Subregion subregion;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"min_level\":0,\"max_level\":0,\"default_floor\":0,\"map_rect\":[[],[]],\"continent_rect\":[[],[]],\"points_of_interest\":[],\"tasks\":[],\"skill_challenges\":[],\"sectors\":[]}";
            this.subregion = JsonConvert.DeserializeObject<GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Subregion>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.subregion.Name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_MinimumLevelReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.subregion.MinimumLevel;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_MaximumLevelReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.subregion.MaximumLevel;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_DefaultFloorReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.subregion.DefaultFloor;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_MapRectangleReflectsInput()
        {
            var expected = default(Rectangle);
            var actual   = this.subregion.MapRectangle;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_ContinentRectangleReflectsInput()
        {
            var expected = default(Rectangle);
            var actual   = this.subregion.ContinentRectangle;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_PointsOfInterestReflectsInput()
        {
            var expected = new PointOfInterestCollection();
            var actual   = this.subregion.PointsOfInterest;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_TasksReflectsInput()
        {
            var expected = new RenownTaskCollection();
            var actual   = this.subregion.Tasks;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_SkillChallengesReflectsInput()
        {
            var expected = new SkillChallengeCollection();
            var actual   = this.subregion.SkillChallenges;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Subregion_SectorsReflectsInput()
        {
            var expected = new SectorCollection();
            var actual   = this.subregion.Sectors;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Subregion_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.subregion.ExtensionData);
        }
    }
}
