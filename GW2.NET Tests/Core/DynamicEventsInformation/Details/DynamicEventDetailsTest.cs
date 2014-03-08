using GW2DotNET.V1.Core.DynamicEventsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.DynamicEventsInformation.Details
{
    [TestFixture]
    public class DynamicEventDetailsTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"level\":0,\"map_id\":0,\"flags\":[],\"location\":{}}";
            this.dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
        }

        private DynamicEventDetails dynamicEventDetails;

        [Test]
        [Category("event_details.json")]
        [Category("ExtensionData")]
        public void DynamicEventDetails_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dynamicEventDetails.ExtensionData);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_FlagsReflectsInput()
        {
            const DynamicEventFlags expected = default(DynamicEventFlags);
            DynamicEventFlags actual = this.dynamicEventDetails.Flags;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_LevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.dynamicEventDetails.Level;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_MapIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.dynamicEventDetails.MapId;

            Assert.AreEqual(expected, actual);
        }

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