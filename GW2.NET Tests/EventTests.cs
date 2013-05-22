using System.Collections.Generic;
using System.Diagnostics;

using GW2DotNET.Events;
using GW2DotNET.Infrastructure;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    [TestFixture]
    public class EventTests
    {
        private EventData data;

        [SetUp]
        public void Init()
        {
            data = new EventData();
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
            var result = data.GetEvet(1001, "E0D7E88D-4FF6-42FA-AFFC-0DF4111C2CCD");

            // Assert.IsFalse(result == null);

            Debug.Write(result);
        }
    }
}
