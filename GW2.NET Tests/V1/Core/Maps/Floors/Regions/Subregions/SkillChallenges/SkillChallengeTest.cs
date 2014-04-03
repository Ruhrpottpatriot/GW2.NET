// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallengeTest.cs" company="">
//   
// </copyright>
// <summary>
//   The skill challenge test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions.Subregions.SkillChallenges
{
    using System.Drawing;

    using GW2DotNET.V1.Maps.Floors.Types.Regions.Subregions.SkillChallenges;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The skill challenge test.</summary>
    [TestFixture]
    public class SkillChallengeTest
    {
        /// <summary>The skill challenge.</summary>
        private SkillChallenge skillChallenge;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"coord\":[]}";
            this.skillChallenge = JsonConvert.DeserializeObject<SkillChallenge>(input);
        }

        /// <summary>The skill challenge_ coordinates reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void SkillChallenge_CoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.skillChallenge.Coordinates;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The skill challenge_ extension data is empty.</summary>
        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void SkillChallenge_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.skillChallenge.ExtensionData);
        }
    }
}