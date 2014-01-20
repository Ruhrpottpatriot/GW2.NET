// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1;
using GW2DotNET.V1.DynamicEvents;
using GW2DotNET.V1.DynamicEvents.Models;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.MapInformation.Models;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    /// <summary>Tests for the dynamic events part of the api.</summary>
    [TestFixture]
    public class DynamicEventsTests
    {
        private DataManager manager;

        private const int ServerIdToQuery = 1001;

        /// <summary>Runs before the test run.</summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new DataManager();
        }

        [Test]
        public void GetEventList()
        {
            var stopwatch = Stopwatch.StartNew();

            List<GameEvent> events = this.manager.DynamicEventsData.GetEventList(ServerIdToQuery).ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(events);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total events running on server {1}: {0}", events.Count, ServerIdToQuery));
        }

        [Test]
        public async Task GetEventListAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            List<GameEvent> events = await this.manager.DynamicEventsData.GetEventListAsync(ServerIdToQuery) as List<GameEvent>;

            stopwatch.Stop();

            Assert.IsNotEmpty(events);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total events running on server {1}: {0}", events.Count, ServerIdToQuery));
        }

        [Test]
        public void GetEventDetails()
        {
            List<GameEvent> events = this.manager.DynamicEventsData.GetEventList(ServerIdToQuery).ToList();

            var stopwatch = Stopwatch.StartNew();

            GameEvent sphereEvent = this.manager.DynamicEventsData.GetEventDetails(events.Single(evnt => evnt.EventId == new Guid("EED8A79F-B374-4AE6-BA6F-B7B98D9D7142")));

            // Not called since apparently no such event exists and I know no event which is cylindric.
            // GameEvent cylinderEvent = this.manager.DynamicEventsData.GetEventDetails(events.Single(evnt => evnt.EventId == new Guid("3A2B85C5-DE73-4402-BD84-8F53AA394A52")));

            GameEvent polyEvent = this.manager.DynamicEventsData.GetEventDetails(events.Single(evnt => evnt.EventId == new Guid("CEA84FBF-2368-467C-92EA-7FA60D527C7B")));

            stopwatch.Stop();

            Assert.IsNotNull(sphereEvent);
            // Assert.IsNotNull(cylinderEvent);
            Assert.IsNotNull(polyEvent);
            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));
        }

        [Test]
        public async Task GetEventDetailsAsync()
        {
            List<GameEvent> events = this.manager.DynamicEventsData.GetEventList(ServerIdToQuery).ToList();

            var stopwatch = Stopwatch.StartNew();

            GameEvent sphereEvent = await this.manager.DynamicEventsData.GetEventDetailsAsync(events.Single(evnt => evnt.EventId == new Guid("EED8A79F-B374-4AE6-BA6F-B7B98D9D7142")));

            // Not called since apparently no such event exists and I know no event which is cylindric.
            // GameEvent cylinderEvent = this.manager.DynamicEventsData.GetEventDetails(events.Single(evnt => evnt.EventId == new Guid("3A2B85C5-DE73-4402-BD84-8F53AA394A52")));

            GameEvent polyEvent = await this.manager.DynamicEventsData.GetEventDetailsAsync(events.Single(evnt => evnt.EventId == new Guid("CEA84FBF-2368-467C-92EA-7FA60D527C7B")));

            stopwatch.Stop();

            Assert.IsNotNull(sphereEvent);
            // Assert.IsNotNull(cylinderEvent);
            Assert.IsNotNull(polyEvent);
            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));
        }
    }
}
