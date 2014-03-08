using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    [TestFixture]
    public class SkillChallengeTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"coord\":[]}";
            this.skillChallenge = JsonConvert.DeserializeObject<SkillChallenge>(input);
        }

        private SkillChallenge skillChallenge;

        [Test]
        [Category("map_floor.json")]
        public void SkillChallenge_CoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.skillChallenge.Coordinates;
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