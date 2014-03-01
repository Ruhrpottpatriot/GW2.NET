using GW2DotNET.V1.Core.GuildInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.GuildInformationTests
{
    [TestFixture]
    public class EmblemTest
    {
        private Emblem emblem;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"background_id\":27,\"foreground_id\":114,\"flags\":[],\"background_color_id\":11,\"foreground_primary_color_id\":584,\"foreground_secondary_color_id\":64}";
            this.emblem = JsonConvert.DeserializeObject<Emblem>(input);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_BackgroundIdReflectsInput()
        {
            const int expectedBackgroundId = 27;
            Assert.AreEqual(expectedBackgroundId, emblem.BackgroundId);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundIdReflectsInput()
        {
            const int expectedForegroundId = 114;
            Assert.AreEqual(expectedForegroundId, this.emblem.ForegroundId);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_FlagsReflectsInput()
        {
            const EmblemTransformations expectedFlags = EmblemTransformations.None;
            Assert.AreEqual(expectedFlags, this.emblem.Flags);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_BackgroundColorIdReflectsInput()
        {
            const int expectedBackgroundColorId = 11;
            Assert.AreEqual(expectedBackgroundColorId, this.emblem.BackgroundColorId);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundPrimaryColorIdReflectsInput()
        {
            const int expectedForegroundPrimaryColorId = 584;
            Assert.AreEqual(expectedForegroundPrimaryColorId, this.emblem.ForegroundPrimaryColorId);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundSecondaryColorIdReflectsInput()
        {
            const int expectedForegroundSecondaryColorId = 64;
            Assert.AreEqual(expectedForegroundSecondaryColorId, this.emblem.ForegroundSecondaryColorId);
        }

        [Test]
        [Category("guild_details.json")]
        [Category("ExtensionData")]
        public void Emblem_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.emblem.ExtensionData);
        }
    }
}
