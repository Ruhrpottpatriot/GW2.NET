using GW2DotNET.V1.Core.DynamicEventsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.DynamicEventsInformation.Details
{
    [TestFixture]
    public class DynamicEventFlagsTest
    {
        [Test]
        [Category("event_details.json")]
        public void DynamicEventStyles_GroupEvent_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"group_event\"]}";
            var dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
            const DynamicEventFlags expectedFlags = DynamicEventFlags.GroupEvent;

            Assert.AreEqual(expectedFlags, dynamicEventDetails.Flags);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventStyles_MapWide_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"map_wide\"]}";
            var dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
            const DynamicEventFlags expectedFlags = DynamicEventFlags.MapWide;

            Assert.AreEqual(expectedFlags, dynamicEventDetails.Flags);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventStyles_Multiple_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"group_event\",\"map_wide\"]}";
            var dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
            const DynamicEventFlags expectedFlags = DynamicEventFlags.GroupEvent | DynamicEventFlags.MapWide;

            Assert.AreEqual(expectedFlags, dynamicEventDetails.Flags);
        }

        [Test]
        [Category("event_details.json")]
        public void DynamicEventStyles_None_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[]}";
            var dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
            const DynamicEventFlags expectedFlags = DynamicEventFlags.None;

            Assert.AreEqual(expectedFlags, dynamicEventDetails.Flags);
        }
    }
}