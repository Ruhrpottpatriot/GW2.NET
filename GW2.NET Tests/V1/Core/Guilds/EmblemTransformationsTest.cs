// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemTransformationsTest.cs" company="">
//   
// </copyright>
// <summary>
//   The emblem transformations test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Guilds
{
    using GW2DotNET.V1.Guilds.Details.Types.Emblems;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The emblem transformations test.</summary>
    [TestFixture]
    public class EmblemTransformationsTest
    {
        /// <summary>The emblem transformations_ flip background horizontal_ flags reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void EmblemTransformations_FlipBackgroundHorizontal_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"FlipBackgroundHorizontal\"]}";
            var emblem = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipBackgroundHorizontal;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        /// <summary>The emblem transformations_ flip background vertical_ flags reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void EmblemTransformations_FlipBackgroundVertical_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"FlipBackgroundVertical\"]}";
            var emblem = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipBackgroundVertical;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        /// <summary>The emblem transformations_ flip foreground horizontal_ flags reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void EmblemTransformations_FlipForegroundHorizontal_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"FlipForegroundHorizontal\"]}";
            var emblem = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipForegroundHorizontal;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        /// <summary>The emblem transformations_ flip foreground vertical_ flags reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void EmblemTransformations_FlipForegroundVertical_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"FlipForegroundVertical\"]}";
            var emblem = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.FlipForegroundVertical;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        /// <summary>The emblem transformations_ multiple_ flags reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void EmblemTransformations_Multiple_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"FlipBackgroundHorizontal\",\"FlipBackgroundVertical\",\"FlipForegroundHorizontal\",\"FlipForegroundVertical\"]}";
            var emblem = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags =
                EmblemTransformations.FlipBackgroundHorizontal | EmblemTransformations.FlipBackgroundVertical | EmblemTransformations.FlipForegroundHorizontal
                | EmblemTransformations.FlipForegroundVertical;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }

        /// <summary>The emblem transformations_ none_ flags reflects input.</summary>
        [Test]
        [Category("guild_details.json")]
        public void EmblemTransformations_None_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[]}";
            var emblem = JsonConvert.DeserializeObject<Emblem>(input);
            const EmblemTransformations expectedFlags = EmblemTransformations.None;

            Assert.AreEqual(expectedFlags, emblem.Flags);
        }
    }
}