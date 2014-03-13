// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventNameTest.cs" company="">
//   
// </copyright>
// <summary>
//   The dynamic event name test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents.Names
{
    using System;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The dynamic event name test.</summary>
    [TestFixture]
    public class DynamicEventNameTest
    {
        /// <summary>The dynamic event name.</summary>
        private DynamicEventName dynamicEventName;

        /// <summary>The dynamic event name_ extension data is empty.</summary>
        [Test]
        [Category("event_names.json")]
        [Category("ExtensionData")]
        public void DynamicEventName_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dynamicEventName.ExtensionData);
        }

        /// <summary>The dynamic event name_ id reflects input.</summary>
        [Test]
        [Category("event_names.json")]
        public void DynamicEventName_IdReflectsInput()
        {
            Guid expectedId = Guid.Parse("893057AB-695C-4553-9D8C-A4CC04557C84");
            Assert.AreEqual(expectedId, this.dynamicEventName.Id);
        }

        /// <summary>The dynamic event name_ name reflects input.</summary>
        [Test]
        [Category("event_names.json")]
        public void DynamicEventName_NameReflectsInput()
        {
            const string expectedName = "Kill the Risen commander to avenge Forgal.";
            Assert.AreEqual(expectedName, this.dynamicEventName.Name);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"ID\":\"893057AB-695C-4553-9D8C-A4CC04557C84\",\"name\":\"Kill the Risen commander to avenge Forgal.\"}";
            this.dynamicEventName = JsonConvert.DeserializeObject<DynamicEventName>(input);
        }
    }
}