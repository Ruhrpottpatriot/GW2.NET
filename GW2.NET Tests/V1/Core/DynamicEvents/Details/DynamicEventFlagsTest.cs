// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventFlagsTest.cs" company="">
//   
// </copyright>
// <summary>
//   The dynamic event flags test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents.Details
{
    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The dynamic event flags test.</summary>
    [TestFixture]
    public class DynamicEventFlagsTest
    {
        /// <summary>The dynamic event styles_ group event_ flags reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void DynamicEventStyles_GroupEvent_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"group_event\"]}";
            var dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
            const DynamicEventFlags expectedFlags = DynamicEventFlags.GroupEvent;

            Assert.AreEqual(expectedFlags, dynamicEventDetails.Flags);
        }

        /// <summary>The dynamic event styles_ map wide_ flags reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void DynamicEventStyles_MapWide_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"map_wide\"]}";
            var dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
            const DynamicEventFlags expectedFlags = DynamicEventFlags.MapWide;

            Assert.AreEqual(expectedFlags, dynamicEventDetails.Flags);
        }

        /// <summary>The dynamic event styles_ multiple_ flags reflects input.</summary>
        [Test]
        [Category("event_details.json")]
        public void DynamicEventStyles_Multiple_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"group_event\",\"map_wide\"]}";
            var dynamicEventDetails = JsonConvert.DeserializeObject<DynamicEventDetails>(input);
            const DynamicEventFlags expectedFlags = DynamicEventFlags.GroupEvent | DynamicEventFlags.MapWide;

            Assert.AreEqual(expectedFlags, dynamicEventDetails.Flags);
        }

        /// <summary>The dynamic event styles_ none_ flags reflects input.</summary>
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