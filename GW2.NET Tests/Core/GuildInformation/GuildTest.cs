using System;
using GW2DotNET.V1.Core.GuildInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.GuildInformation
{
    [TestFixture]
    public class GuildTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input =
                "{\"guild_id\":\"00000000-0000-0000-0000-000000000000\",\"guild_name\":\"\",\"tag\":\"\",\"emblem\":{}}";
            this.guild = JsonConvert.DeserializeObject<Guild>(input);
        }

        private Guild guild;

        [Test]
        [Category("guild_details.json")]
        public void Guild_EmblemReflectsInput()
        {
            var expected = new Emblem();
            Emblem actual = this.guild.Emblem;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        [Category("ExtensionData")]
        public void Guild_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.guild.ExtensionData);
        }

        [Test]
        [Category("guild_details.json")]
        public void Guild_GuildIdReflectsInput()
        {
            Guid expected = default(Guid);
            Guid actual = this.guild.GuildId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Guild_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.guild.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("guild_details.json")]
        public void Guild_TagReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.guild.Tag;

            Assert.AreEqual(expected, actual);
        }
    }
}