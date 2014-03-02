using System;
using GW2DotNET.V1.Core.DynamicEventsInformation.Status;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.DynamicEventsInformation.Status
{
    [TestFixture]
    public class DynamicEventTest
    {
        private DynamicEvent dynamicEvent;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"world_id\":1001,\"map_id\":73,\"event_id\":\"893057AB-695C-4553-9D8C-A4CC04557C84\",\"state\":\"Preparation\"}";
            this.dynamicEvent = JsonConvert.DeserializeObject<DynamicEvent>(input);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_WorldIdReflectsInput()
        {
            const int expectedWorldId = 1001;
            Assert.AreEqual(expectedWorldId, this.dynamicEvent.WorldId);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_MapIdReflectsInput()
        {
            const int expectedMapId = 73;
            Assert.AreEqual(expectedMapId, this.dynamicEvent.MapId);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_EventIdReflectsInput()
        {
            var expectedEventId = Guid.Parse("893057AB-695C-4553-9D8C-A4CC04557C84");
            Assert.AreEqual(expectedEventId, this.dynamicEvent.EventId);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_StateReflectsInput()
        {
            const DynamicEventState expectedState = DynamicEventState.Preparation;
            Assert.AreEqual(expectedState, this.dynamicEvent.State);
        }

        [Test]
        [Category("events.json")]
        [Category("ExtensionData")]
        public void DynamicEvent_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dynamicEvent.ExtensionData);
        }
    }
}
