using System;
using GW2DotNET.V1.Core.GuildInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.GuildInformationTests
{
    [TestFixture]
    public class GuildDetailsTest
    {
        private GuildDetails guildDetails;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"guild_id\":\"75FD83CF-0C45-4834-BC4C-097F93A487AF\",\"guild_name\":\"Veterans Of Lions Arch\",\"tag\":\"LA\"}";
            this.guildDetails = JsonConvert.DeserializeObject<GuildDetails>(input);
        }

        [Test]
        [Category("guild_details.json")]
        public void GuildDetails_GuildIdReflectsInput()
        {
            var expectedGuildId = Guid.Parse("75FD83CF-0C45-4834-BC4C-097F93A487AF");
            Assert.AreEqual(expectedGuildId, this.guildDetails.GuildId);
        }

        [Test]
        [Category("guild_details.json")]
        public void GuildDetails_GuildNameReflectsInput()
        {
            const string expectedGuildName = "Veterans Of Lions Arch";
            Assert.AreEqual(expectedGuildName, this.guildDetails.GuildName);
        }

        [Test]
        [Category("guild_details.json")]
        public void GuildDetails_TagReflectsInput()
        {
            const string expectedTag = "LA";
            Assert.AreEqual(expectedTag, this.guildDetails.GuildTag);
        }

        [Test]
        [Category("guild_details.json")]
        [Category("ExtensionData")]
        public void GuildDetails_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.guildDetails.ExtensionData);
        }
    }
}
