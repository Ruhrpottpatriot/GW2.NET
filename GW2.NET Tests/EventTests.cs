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
            this.data = EventData.Instance;
        }

        [Test]
        public void GetAllEventsTest()
        {
            var result = this.data.GetEvents(1001);

            Assert.IsFalse(result == null);

            Debug.Write(result);
        }

        [Test]
        public void GetEvent()
        {
            var result = this.data.GetEvent(1001, new Guid("E0D7E88D-4FF6-42FA-AFFC-0DF4111C2CCD"));

            Assert.IsFalse(result == null);

            Debug.Write(result.Name);
        }

        [Test]
        public void GetEventsByMap()
        {
            var result = this.data.GetEventsByMap(1001, 28);

            foreach (var gwEvent in result)
            {
                Debug.WriteLine(gwEvent.Name);
            }
        }
    }
}
