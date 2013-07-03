// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldDataTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventDataTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using GW2DotNET.V1;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    /// <summary>
    /// The event data tests.
    /// </summary>
    [TestFixture]
    public class WorldDataTests
    {
        /// <summary>
        /// The world manager.
        /// </summary>
        private ApiManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new ApiManager(Language.En);
        }

        /// <summary>
        ///  Gets all events from the server.
        /// </summary>
        [Test]
        public void GetAllEvents()
        {
            var stopwatch = Stopwatch.StartNew();

            var events = this.manager.Events.ToList();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of Events: {0}", events.Count));
        }

        /// <summary>
        ///  Gets all events from the server.
        /// </summary>
        [Test]
        public void GetAllEventsAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Events.GetAllEventsAsync(CancellationToken.None);
            task.Wait();

            var events = task.Result.ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(events);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of Events: {0}", events.Count));
        }

        /// <summary>
        /// Gets an event by world id.
        /// </summary>
        [Test]
        public void GetEventsByWorld()
        {
            Trace.WriteLine("Gets the events from multiple worlds to test the new caching on the event data provider.");

            Trace.WriteLine(string.Empty);

            var worldList = new List<GwWorld>
            {
                new GwWorld(1001, "Anvil Rock"), 
                new GwWorld(1023, "Devona's Rest"), 
                new GwWorld(2207, "Dzagonur [DE]")
            };

            Trace.WriteLine("Worlds to get the events from:");
            Debug.Indent();

            foreach (var gwWorld in worldList)
            {
                Trace.WriteLine(gwWorld.Name);
            }

            Debug.Unindent();
            Trace.WriteLine(string.Empty);
            
            var stopwatch = new Stopwatch();

            foreach (var gwWorld in worldList)
            {
                Trace.WriteLine(string.Format("{0} (Id: {1})", gwWorld.Name, gwWorld.Id));

                Debug.Indent();
                Trace.WriteLine("Starting stopwatch");
                stopwatch.Start();

                var eventsByWorld = this.manager.Events[gwWorld];

                stopwatch.Stop();

                Trace.WriteLine(string.Format("Elapsed time: {0} ms", stopwatch.ElapsedMilliseconds));
                Trace.WriteLine(string.Format("Total number of events on {0}: {1}", gwWorld.Name, eventsByWorld.Count()));

                stopwatch.Restart();
                Trace.WriteLine(string.Empty);
                Debug.Unindent();
            }
        }

        /// <summary>
        /// Gets an event by world id.
        /// </summary>
        [Test]
        public void GetEventsByWorldAsync()
        {
            Trace.WriteLine("Gets the events from multiple worlds asynchronously to test the new caching on the event data provider.");

            Trace.WriteLine(string.Empty);

            var worldList = new List<GwWorld>
            {
                new GwWorld(1001, "Anvil Rock"), 
                new GwWorld(1023, "Devona's Rest"), 
                new GwWorld(2207, "Dzagonur [DE]")
            };

            Trace.WriteLine("Worlds to get the events from:");
            Debug.Indent();

            foreach (var gwWorld in worldList)
            {
                Trace.WriteLine(gwWorld.Name);
            }

            Debug.Unindent();
            Trace.WriteLine(string.Empty);

            var stopwatch = new Stopwatch();

            foreach (var gwWorld in worldList)
            {
                Trace.WriteLine(string.Format("{0} (Id: {1})", gwWorld.Name, gwWorld.Id));

                Debug.Indent();
                Trace.WriteLine("Starting stopwatch");
                stopwatch.Start();

                var task = this.manager.Events.GetEventsFromWorldAsync(gwWorld, CancellationToken.None);
                task.Wait();

                var eventsByWorld = task.Result.ToList();

                stopwatch.Stop();

                Assert.IsNotEmpty(eventsByWorld);

                Trace.WriteLine(string.Format("Elapsed time: {0} ms", stopwatch.ElapsedMilliseconds));
                Trace.WriteLine(string.Format("Total number of events on {0}: {1}", gwWorld.Name, eventsByWorld.Count()));

                stopwatch.Restart();
                Trace.WriteLine(string.Empty);
                Debug.Unindent();
            }
        }

        /// <summary>Gets all continents</summary>
        [Test]
        public void GetAllContinents()
        {
            var stopwatch = Stopwatch.StartNew();

            var continents = this.manager.Continents.ToList();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of continents: {0}", continents.Count));
        }

        /// <summary>Gets all continentsAsynchronously</summary>
        [Test]
        public void GetAllContinentsAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Continents.GetAllContinentsAsync(CancellationToken.None);
            task.Wait();

            var continents = task.Result.ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(continents);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of continents: {0}", continents.Count));
        }

        /// <summary>Gets all maps.</summary>
        [Test]
        public void GetAllMaps()
        {
            var stopwatch = Stopwatch.StartNew();

            var maps = this.manager.Maps.ToList();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of maps: {0}", maps.Count));
        }

        /// <summary>Gets all maps.</summary>
        [Test]
        public void GetAllMapsAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Maps.GetAllMapsAsync(CancellationToken.None);
            task.Wait();

            var maps = task.Result.ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(maps);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of maps: {0}", maps.Count));
        }

        /// <summary>Gets a map by its id.</summary>
        [Test]
        public void GetMapById()
        {
            var stopwatch = Stopwatch.StartNew();

            var map1 = this.manager.Maps[80];

            var map2 = this.manager.Maps[80];

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("The two maps are equal: {0}", map1 == map2));
        }

        /// <summary>Gets a map by its id asynchronously.</summary>
        [Test]
        public void GetMapByIdAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task1 = this.manager.Maps.GetMapFromIdAsync(80, CancellationToken.None);

            var task2 = this.manager.Maps.GetMapFromIdAsync(80, CancellationToken.None);

            task1.Wait();
            task2.Wait();

            var map1 = task1.Result;
            var map2 = task2.Result;

            stopwatch.Stop();

            Assert.IsNotNullOrEmpty(map1.Name);

            Assert.IsNotNullOrEmpty(map2.Name);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("The two maps are equal: {0}", map1 == map2));
        }

        /// <summary>Gets a complete map floor.</summary>
        [Test]
        public void GetMapFloor()
        {
            var stopwatch = Stopwatch.StartNew();

            var floor = this.manager.FloorData[1, 1];

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));
        }

        /// <summary>Gets a complete map floor asynchronously.</summary>
        [Test]
        public void GetMapFloorAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.FloorData.GetMapFloorAsync(1, 1, CancellationToken.None);
            task.Wait();

            var mapFloor = task.Result;

            stopwatch.Stop();

            Assert.IsNotEmpty(mapFloor.Regions);

            Assert.IsNotEmpty(mapFloor.TextureDims);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));
        }
    }
}
