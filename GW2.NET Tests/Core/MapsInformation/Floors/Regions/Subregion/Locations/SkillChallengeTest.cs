using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Floors.Regions.Subregion.Locations
{
    [TestFixture]
    public class SkillChallengeTest
    {
        private SkillChallenge skillChallenge;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"coord\":[]}";
            this.skillChallenge = JsonConvert.DeserializeObject<SkillChallenge>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void SkillChallenge_CoordinatesReflectsInput()
        {
            var expected = default(PointF);
            var actual   = this.skillChallenge.Coordinates;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void SkillChallenge_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.skillChallenge.ExtensionData);
        }
    }
}
