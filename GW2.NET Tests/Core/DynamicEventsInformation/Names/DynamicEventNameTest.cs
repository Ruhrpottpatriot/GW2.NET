using System;
using GW2DotNET.V1.Core.DynamicEventsInformation.Names;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.DynamicEventsInformation.Names
{
    [TestFixture]
    public class DynamicEventNameTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input =
                "{\"ID\":\"893057AB-695C-4553-9D8C-A4CC04557C84\",\"name\":\"Kill the Risen commander to avenge Forgal.\"}";
            this.dynamicEventName = JsonConvert.DeserializeObject<DynamicEventName>(input);
        }

        private DynamicEventName dynamicEventName;

        [Test]
        [Category("event_names.json")]
        [Category("ExtensionData")]
        public void DynamicEventName_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dynamicEventName.ExtensionData);
        }

        [Test]
        [Category("event_names.json")]
        public void DynamicEventName_IdReflectsInput()
        {
            Guid expectedId = Guid.Parse("893057AB-695C-4553-9D8C-A4CC04557C84");
            Assert.AreEqual(expectedId, this.dynamicEventName.Id);
        }

        [Test]
        [Category("event_names.json")]
        public void DynamicEventName_NameReflectsInput()
        {
            const string expectedName = "Kill the Risen commander to avenge Forgal.";
            Assert.AreEqual(expectedName, this.dynamicEventName.Name);
        }
    }
}