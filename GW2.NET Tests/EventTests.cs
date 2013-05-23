using System.Diagnostics;

using GW2DotNET.Events;

using NUnit.Framework;
using System;

namespace GW2.NET_Tests
{
    [TestFixture]
    public class EventTests
    {
        private EventData data;

        [SetUp]
        public void Init()
        {
            data = EventData.Instance;
        }

        [Test]
        public void GetAllEventsTest()
        {
            var result = data.GetEvents(1001);

            Assert.IsFalse(result == null);
            Debug.Write(result);
        }

        [Test]
        public void GetEvent()
        {
            var result = data.GetEvent(1001, new Guid("E0D7E88D-4FF6-42FA-AFFC-0DF4111C2CCD"));

            // Assert.IsFalse(result == null);

            Debug.Write(result);
        }

        [Test]
        public void GetEventsByMap()
        {
            var result = data.GetEventsByMap(1001, 28);
        }
    }
}
