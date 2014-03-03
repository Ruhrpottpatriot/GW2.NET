// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventsTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Tests for the dynamic events part of the api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1;

using NUnit.Framework;

namespace GW2DotNET_Tests
{
    /// <summary>Tests for the dynamic events part of the api.</summary>
    [TestFixture]
    public class DynamicEventsTests
    {
        /// <summary>The server id to query.</summary>
        private const int ServerIdToQuery = 1001;

        /// <summary>The manager.</summary>
        private IDataManager manager;

        /// <summary>Runs before the test run.</summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new DataManager();
        }

        /// <summary>Test for the GetEventList method.</summary>
        [Test]
        public void GetEventList()
        {
            var stopwatch = Stopwatch.StartNew();

            var events = this.manager.DynamicEventsData.GetEventList(ServerIdToQuery).ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(events);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total events running on server {1}: {0}", events.Count, ServerIdToQuery));
        }

        /// <summary>Test for the GetEventListAsync method.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [Test]
        public async Task GetEventListAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var events = (await this.manager.DynamicEventsData.GetEventListAsync(ServerIdToQuery)).ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(events);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total events running on server {1}: {0}", events.Count, ServerIdToQuery));
        }

        /// <summary>Test for the GetEventDetails method.</summary>
        [Test]
        public void GetEventDetails()
        {
            var events = this.manager.DynamicEventsData.GetEventList(ServerIdToQuery).ToList();

            var stopwatch = Stopwatch.StartNew();

            var sphereEvent = this.manager.DynamicEventsData.GetEventDetails(events.Single(evnt => evnt.EventId == new Guid("EED8A79F-B374-4AE6-BA6F-B7B98D9D7142")));

            // Not called since apparently no such event exists and I know no event which is cylindric.
            // var cylinderEvent = this.manager.DynamicEventsData.GetEventDetails(events.Single(evnt => evnt.EventId == new Guid("3A2B85C5-DE73-4402-BD84-8F53AA394A52")));
            var polyEvent = this.manager.DynamicEventsData.GetEventDetails(events.Single(evnt => evnt.EventId == new Guid("CEA84FBF-2368-467C-92EA-7FA60D527C7B")));

            stopwatch.Stop();

            Assert.IsNotNull(sphereEvent);

            // Assert.IsNotNull(cylinderEvent);
            Assert.IsNotNull(polyEvent);
            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));
        }

        /// <summary>Test for the GetEventDetailsAsync method.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [Test]
        public async Task GetEventDetailsAsync()
        {
            var events = this.manager.DynamicEventsData.GetEventList(ServerIdToQuery).ToList();

            var stopwatch = Stopwatch.StartNew();

            var sphereEvent = await this.manager.DynamicEventsData.GetEventDetailsAsync(events.Single(evnt => evnt.EventId == new Guid("EED8A79F-B374-4AE6-BA6F-B7B98D9D7142")));

            // Not called since apparently no such event exists and I know no event which is cylindric.
            // var cylinderEvent = this.manager.DynamicEventsData.GetEventDetails(events.Single(evnt => evnt.EventId == new Guid("3A2B85C5-DE73-4402-BD84-8F53AA394A52")));
            var polyEvent = await this.manager.DynamicEventsData.GetEventDetailsAsync(events.Single(evnt => evnt.EventId == new Guid("CEA84FBF-2368-467C-92EA-7FA60D527C7B")));

            stopwatch.Stop();

            Assert.IsNotNull(sphereEvent);

            // Assert.IsNotNull(cylinderEvent);
            Assert.IsNotNull(polyEvent);
            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));
        }
    }
}
