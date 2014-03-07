using System;
using GW2DotNET.V1.Core.GuildInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.GuildInformation
{
    [TestFixture]
    public class GuildTest
    {
        private Guild guild;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"guild_id\":\"00000000-0000-0000-0000-000000000000\",\"guild_name\":\"\",\"tag\":\"\",\"emblem\":{}}";
            this.guild = JsonConvert.DeserializeObject<Guild>(input);
        }

        [Test]
        [Category("guild_details.json")]
        public void Guild_GuildIdReflectsInput()
        {
            var expected = default(Guid);
            var actual   = this.guild.GuildId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Guild_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.guild.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Guild_TagReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.guild.Tag;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Guild_EmblemReflectsInput()
        {
            var expected = new Emblem();
            var actual   = this.guild.Emblem;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        [Category("ExtensionData")]
        public void Guild_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.guild.ExtensionData);
        }
    }
}
