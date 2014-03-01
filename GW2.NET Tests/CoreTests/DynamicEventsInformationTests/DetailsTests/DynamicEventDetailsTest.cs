using GW2DotNET.V1.Core.DynamicEventsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.DynamicEventsInformationTests.DetailsTests
{
    [TestFixture]
    public class DynamicEventDetailsTest
    {
        private DynamicEventDetails dynamicEventDetails;

        [SetUp]
        public void Initialize()
        {
            const string input       = "{\"name\":\"Kill the Risen commander to avenge Forgal.\",\"level\":54,\"map_id\":73,\"flags\":[],\"location\":{\"type\":\"sphere\",\"center\":[1852.43,-29331.8,2304.68],\"radius\":2500,\"rotation\":0}}";
            this.dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_NameReflectsInput()
        {
            const string expectedName = "Kill the Risen commander to avenge Forgal.";
            Assert.AreEqual(expectedName, this.dynamicEventDetails.Name);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_LevelReflectsInput()
        {
            const int expectedLevel = 54;
            Assert.AreEqual(expectedLevel, this.dynamicEventDetails.Level);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_MapIdReflectsInput()
        {
            const int expectedMapId = 73;
            Assert.AreEqual(expectedMapId, this.dynamicEventDetails.MapId);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventDetails_FlagsReflectsInput()
        {
            const DynamicEventStyles expectedFlags = DynamicEventStyles.None;
            Assert.AreEqual(expectedFlags, this.dynamicEventDetails.Flags);
        }
    }
}
