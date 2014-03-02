using GW2DotNET.V1.Core.GuildInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.GuildInformation
{
    [TestFixture]
    public class EmblemTest
    {
        private Emblem emblem;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"background_id\":0,\"foreground_id\":0,\"flags\":[],\"background_color_id\":0,\"foreground_primary_color_id\":0,\"foreground_secondary_color_id\":0}";
            this.emblem = JsonConvert.DeserializeObject<Emblem>(input);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_BackgroundIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = emblem.BackgroundId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.emblem.ForegroundId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_FlagsReflectsInput()
        {
            const EmblemTransformations expectedFlags = default(EmblemTransformations);
            var actual                                = this.emblem.Flags;

            Assert.AreEqual(expectedFlags, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_BackgroundColorIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.emblem.BackgroundColorId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundPrimaryColorIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.emblem.ForegroundPrimaryColorId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundSecondaryColorIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.emblem.ForegroundSecondaryColorId;

            Assert.AreEqual(expected, actual);
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
