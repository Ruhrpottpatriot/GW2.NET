using System;
using GW2DotNET.V1.Core.GuildInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.GuildInformation
{
    [TestFixture]
    public class GuildDetailsTest
    {
        private GuildDetails guildDetails;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"guild_id\":\"00000000-0000-0000-0000-000000000000\",\"guild_name\":\"\",\"tag\":\"\",\"emblem\":{}}";
            this.guildDetails = JsonConvert.DeserializeObject<GuildDetails>(input);
        }

        [Test]
        [Category("guild_details.json")]
        public void GuildDetails_GuildIdReflectsInput()
        {
            var expected = default(Guid);
            var actual   = this.guildDetails.GuildId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void GuildDetails_GuildNameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.guildDetails.GuildName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void GuildDetails_TagReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.guildDetails.GuildTag;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void GuildDetails_GuildEmblemReflectsInput()
        {
            var expected = new Emblem();
            var actual   = this.guildDetails.GuildEmblem;

            Assert.AreEqual(expected, actual);
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
