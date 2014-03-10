// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsTest.cs" company="">
//   
// </copyright>
// <summary>
//   The dynamic event details test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Core.DynamicEventsInformation.Details
{
    using GW2DotNET.V1.Core.DynamicEventsInformation.Details;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The dynamic event details test.</summary>
    [TestFixture]
    public class DynamicEventDetailsTest
    {
        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"level\":0,\"map_id\":0,\"flags\":[],\"location\":{}}";
            this.dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
        }

        /// <summary>The dynamic event details.</summary>
        private DynamicEventDetails dynamicEventDetails;

        /// <summary>The dynamic event details_ extension data is empty.</summary>
        [Test]
        [Category("event_details.json")]
        [Category("ExtensionData")]
        public void DynamicEventDetails_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dynamicEventDetails.ExtensionData);
        }

        /// <summary>The dynamic event details_ flags reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_FlagsReflectsInput()
        {
            const DynamicEventFlags expected = default(DynamicEventFlags);
            DynamicEventFlags actual = this.dynamicEventDetails.Flags;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The dynamic event details_ level reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_LevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.dynamicEventDetails.Level;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The dynamic event details_ map id reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_MapIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.dynamicEventDetails.MapId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The dynamic event details_ name reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.dynamicEventDetails.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}