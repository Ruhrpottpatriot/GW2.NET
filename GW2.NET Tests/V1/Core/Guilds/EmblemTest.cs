// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemTest.cs" company="">
//   
// </copyright>
// <summary>
//   The emblem test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Guilds
{
    using GW2DotNET.V1.GuildsDetails.Details.Types.Emblems;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The emblem test.</summary>
    [TestFixture]
    public class EmblemTest
    {
        /// <summary>The emblem.</summary>
        private Emblem emblem;

        /// <summary>The emblem_ background color id reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void Emblem_BackgroundColorIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.emblem.BackgroundColorId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The emblem_ background id reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void Emblem_BackgroundIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.emblem.BackgroundId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The emblem_ extension data is empty.</summary>
        [Test]
        [Category("guild_details.json")]
        [Category("ExtensionData")]
        public void Emblem_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.emblem.ExtensionData);
        }

        /// <summary>The emblem_ flags reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void Emblem_FlagsReflectsInput()
        {
            const EmblemTransformations expectedFlags = default(EmblemTransformations);
            EmblemTransformations actual = this.emblem.Flags;

            Assert.AreEqual(expectedFlags, actual);
        }

        /// <summary>The emblem_ foreground id reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.emblem.ForegroundId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The emblem_ foreground primary color id reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundPrimaryColorIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.emblem.ForegroundPrimaryColorId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The emblem_ foreground secondary color id reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void Emblem_ForegroundSecondaryColorIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.emblem.ForegroundSecondaryColorId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input =
                "{\"background_id\":0,\"foreground_id\":0,\"flags\":[],\"background_color_id\":0,\"foreground_primary_color_id\":0,\"foreground_secondary_color_id\":0}";
            this.emblem = JsonConvert.DeserializeObject<Emblem>(input);
        }
    }
}