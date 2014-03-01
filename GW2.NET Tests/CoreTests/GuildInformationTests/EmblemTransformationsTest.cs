using GW2DotNET.V1.Core.GuildInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.GuildInformationTests
{
    [TestFixture]
    public class EmblemTransformationsTest
    {
        [Test]
        [Category("guild_details.json")]
        public void DynamicEventStyles_None_FlagsReflectsInput()
        {
            const string input                        = "{\"flags\":[]}";
            var emblem                                = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.None;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        [Test]
        [Category("guild_details.json")]
        public void DynamicEventStyles_FlipBackgroundHorizontal_FlagsReflectsInput()
        {
            const string input                        = "{\"flags\":[\"FlipBackgroundHorizontal\"]}";
            var emblem                                = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipBackgroundHorizontal;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        [Test]
        [Category("guild_details.json")]
        public void DynamicEventStyles_FlipBackgroundVertical_FlagsReflectsInput()
        {
            const string input                        = "{\"flags\":[\"FlipBackgroundVertical\"]}";
            var emblem                                = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipBackgroundVertical;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        [Test]
        [Category("guild_details.json")]
        public void DynamicEventStyles_FlipForegroundHorizontal_FlagsReflectsInput()
        {
            const string input                        = "{\"flags\":[\"FlipForegroundHorizontal\"]}";
            var emblem                                = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipForegroundHorizontal;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        [Test]
        [Category("guild_details.json")]
        public void DynamicEventStyles_FlipForegroundVertical_FlagsReflectsInput()
        {
            const string input                        = "{\"flags\":[\"FlipForegroundVertical\"]}";
            var emblem                                = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipForegroundVertical;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        [Test]
        [Category("guild_details.json")]
        public void DynamicEventStyles_Multiple_FlagsReflectsInput()
        {
            const string input                        = "{\"flags\":[\"FlipBackgroundHorizontal\",\"FlipBackgroundVertical\",\"FlipForegroundHorizontal\",\"FlipForegroundVertical\"]}";
            var emblem                                = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipBackgroundHorizontal | EmblemTransformations.FlipBackgroundVertical | EmblemTransformations.FlipForegroundHorizontal | EmblemTransformations.FlipForegroundVertical;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }
    }
}
