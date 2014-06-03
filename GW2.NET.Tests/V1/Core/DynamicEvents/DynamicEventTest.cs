// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventTest.cs" company="">
//   
// </copyright>
// <summary>
//   The dynamic event test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents
{
    using System;

    using GW2DotNET.V1.DynamicEvents.Contracts;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The dynamic event test.</summary>
    [TestFixture]
    public class DynamicEventTest
    {
        /// <summary>The dynamic event.</summary>
        private DynamicEvent dynamicEvent;

        /// <summary>The dynamic event_ event id reflects input.</summary>
        [Test]
        [Category("events.json")]
        public void DynamicEvent_EventIdReflectsInput()
        {
            Guid expectedEventId = Guid.Parse("893057AB-695C-4553-9D8C-A4CC04557C84");
            Assert.AreEqual(expectedEventId, this.dynamicEvent.EventId);
        }

        /// <summary>The dynamic event_ extension data is empty.</summary>
        [Test]
        [Category("events.json")]
        [Category("ExtensionData")]
        public void DynamicEvent_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dynamicEvent.ExtensionData);
        }

        /// <summary>The dynamic event_ map id reflects input.</summary>
        [Test]
        [Category("events.json")]
        public void DynamicEvent_MapIdReflectsInput()
        {
            const int expectedMapId = 73;
            Assert.AreEqual(expectedMapId, this.dynamicEvent.MapId);
        }

        /// <summary>The dynamic event_ state reflects input.</summary>
        [Test]
        [Category("events.json")]
        public void DynamicEvent_StateReflectsInput()
        {
            const DynamicEventState expectedState = DynamicEventState.Preparation;
            Assert.AreEqual(expectedState, this.dynamicEvent.State);
        }

        /// <summary>The dynamic event_ world id reflects input.</summary>
        [Test]
        [Category("events.json")]
        public void DynamicEvent_WorldIdReflectsInput()
        {
            const int expectedWorldId = 1001;
            Assert.AreEqual(expectedWorldId, this.dynamicEvent.WorldId);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"world_id\":1001,\"map_id\":73,\"event_id\":\"893057AB-695C-4553-9D8C-A4CC04557C84\",\"state\":\"Preparation\"}";
            this.dynamicEvent = JsonConvert.DeserializeObject<DynamicEvent>(input);
        }
    }
}