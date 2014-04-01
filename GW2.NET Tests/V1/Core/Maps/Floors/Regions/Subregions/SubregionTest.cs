// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubregionTest.cs" company="">
//   
// </copyright>
// <summary>
//   The subregion test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions.Subregions
{
    using System.Drawing;

    using GW2DotNET.V1.MapsFloors.Types.Regions.Subregions;
    using GW2DotNET.V1.MapsFloors.Types.Regions.Subregions.PointsOfInterest;
    using GW2DotNET.V1.MapsFloors.Types.Regions.Subregions.Sectors;
    using GW2DotNET.V1.MapsFloors.Types.Regions.Subregions.SkillChallenges;
    using GW2DotNET.V1.MapsFloors.Types.Regions.Subregions.Tasks;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The subregion test.</summary>
    [TestFixture]
    public class SubregionTest
    {
        /// <summary>The subregion.</summary>
        private Subregion subregion;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input =
                "{\"name\":\"\",\"min_level\":0,\"max_level\":0,\"default_floor\":0,\"map_rect\":[[],[]],\"continent_rect\":[[],[]],\"points_of_interest\":[],\"tasks\":[],\"skill_challenges\":[],\"sectors\":[]}";
            this.subregion = JsonConvert.DeserializeObject<Subregion>(input);
        }

        /// <summary>The subregion_ continent rectangle reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_ContinentRectangleReflectsInput()
        {
            Rectangle expected = default(Rectangle);
            Rectangle actual = this.subregion.ContinentRectangle;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ default floor reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_DefaultFloorReflectsInput()
        {
            const int expected = default(int);
            int actual = this.subregion.DefaultFloor;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ extension data is empty.</summary>
        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Subregion_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.subregion.ExtensionData);
        }

        /// <summary>The subregion_ map rectangle reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_MapRectangleReflectsInput()
        {
            Rectangle expected = default(Rectangle);
            Rectangle actual = this.subregion.MapRectangle;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ maximum level reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_MaximumLevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.subregion.MaximumLevel;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ minimum level reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_MinimumLevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.subregion.MinimumLevel;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ name reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.subregion.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ points of interest reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_PointsOfInterestReflectsInput()
        {
            var expected = new PointOfInterestCollection();
            PointOfInterestCollection actual = this.subregion.PointsOfInterest;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ sectors reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_SectorsReflectsInput()
        {
            var expected = new SectorCollection();
            SectorCollection actual = this.subregion.Sectors;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ skill challenges reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_SkillChallengesReflectsInput()
        {
            var expected = new SkillChallengeCollection();
            SkillChallengeCollection actual = this.subregion.SkillChallenges;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The subregion_ tasks reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Subregion_TasksReflectsInput()
        {
            var expected = new RenownTaskCollection();
            RenownTaskCollection actual = this.subregion.Tasks;
            Assert.AreEqual(expected, actual);
        }
    }
}