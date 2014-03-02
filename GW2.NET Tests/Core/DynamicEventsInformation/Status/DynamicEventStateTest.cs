using GW2DotNET.V1.Core.DynamicEventsInformation.Status;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.DynamicEventsInformation.Status
{
    public class DynamicEventStateTest
    {
        [Test]
        [Category("events.json")]
        public void DynamicEvent_Inactive_StateReflectsInput()
        {
            const string input                    = "{ \"state\": \"Inactive\" }";
            var dynamicEvent                      = JsonConvert.DeserializeObject<DynamicEvent>(input);
            const DynamicEventState expectedState = DynamicEventState.Inactive;

            Assert.AreEqual(expectedState, dynamicEvent.State);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_Active_StateReflectsInput()
        {
            const string input                    = "{ \"state\": \"Active\" }";
            var dynamicEvent                      = JsonConvert.DeserializeObject<DynamicEvent>(input);
            const DynamicEventState expectedState = DynamicEventState.Active;

            Assert.AreEqual(expectedState, dynamicEvent.State);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_Success_StateReflectsInput()
        {
            const string input                    = "{ \"state\": \"Success\" }";
            var dynamicEvent                      = JsonConvert.DeserializeObject<DynamicEvent>(input);
            const DynamicEventState expectedState = DynamicEventState.Success;

            Assert.AreEqual(expectedState, dynamicEvent.State);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_Fail_StateReflectsInput()
        {
            const string input                    = "{ \"state\": \"Fail\" }";
            var dynamicEvent                      = JsonConvert.DeserializeObject<DynamicEvent>(input);
            const DynamicEventState expectedState = DynamicEventState.Fail;

            Assert.AreEqual(expectedState, dynamicEvent.State);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_Warmup_StateReflectsInput()
        {
            const string input                    = "{ \"state\": \"Warmup\" }";
            var dynamicEvent                      = JsonConvert.DeserializeObject<DynamicEvent>(input);
            const DynamicEventState expectedState = DynamicEventState.Warmup;

            Assert.AreEqual(expectedState, dynamicEvent.State);
        }

        [Test]
        [Category("events.json")]
        public void DynamicEvent_Preparation_StateReflectsInput()
        {
            const string input                    = "{ \"state\": \"Preparation\" }";
            var dynamicEvent                      = JsonConvert.DeserializeObject<DynamicEvent>(input);
            const DynamicEventState expectedState = DynamicEventState.Preparation;

            Assert.AreEqual(expectedState, dynamicEvent.State);
        }
    }
}
