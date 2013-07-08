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
        /// Gets an event by world id.
        /// </summary>
        [Test]
        public void GetEventsByWorld()
        {
            Debug.WriteLine("Gets the events from multiple worlds to test the new caching on the event data provider.");

            Debug.WriteLine(string.Empty);

            var worldList = new List<GwWorld>
            {
                new GwWorld(1001, "Anvil Rock"), 
                new GwWorld(1023, "Devona's Rest"), 
                new GwWorld(2207, "Dzagonur [DE]")
            };

            Debug.WriteLine("Worlds to get the events from:");
            Debug.Indent();

            foreach (var gwWorld in worldList)
            {
                Debug.WriteLine(gwWorld.Name);
            }

            Debug.Unindent();
            Debug.WriteLine(string.Empty);
            
            var stopwatch = new Stopwatch();

            foreach (var gwWorld in worldList)
            {
                Debug.WriteLine("{0} (Id: {1})", gwWorld.Name, gwWorld.Id);

                Debug.Indent();
                Debug.WriteLine("Starting stopwatch");
                stopwatch.Start();

                var eventsByWorld = this.manager.Events[gwWorld];

                stopwatch.Stop();

                Debug.WriteLine("Elapsed time: {0} ms", stopwatch.ElapsedMilliseconds);
                Debug.WriteLine("Total number of events on {0}: {1}", gwWorld.Name, eventsByWorld.Count());

                stopwatch.Restart();
                Debug.WriteLine(string.Empty);
                Debug.Unindent();
            }
        }

        /// <summary>Gets all continents</summary>
        [Test]
        public void GetAllContinents()
        {
            var stopwatch = Stopwatch.StartNew();

            var continents = this.manager.Continents.ToList();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Total Number of continents: {0}", continents.Count);
        }

        /// <summary>Gets all maps.</summary>
        [Test]
        public void GetAllMaps()
        {
            var stopwatch = Stopwatch.StartNew();

            var maps = this.manager.Maps.ToList();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Total Number of maps: {0}", maps.Count);
        }

        /// <summary>Gets a map by its id.</summary>
        [Test]
        public void GetMapById()
        {
            var stopwatch = Stopwatch.StartNew();

            var map1 = this.manager.Maps[80];

            var map2 = this.manager.Maps[80];

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("The two maps are equal: {0}", map1 == map2);
        }

        /// <summary>Gets a map by its name.</summary>
        [Test]
        public void GetMapByName()
        {
            var stopwatch = Stopwatch.StartNew();

            var map1 = this.manager.Maps["A Society Function"];

            var map2 = this.manager.Maps["A Society Function"];

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("The two maps are equal: {0}", map1 == map2);
        }

        /// <summary>Gets a complete map floor.</summary>
        [Test]
        public void GetMapFloor()
        {
            var stopwatch = Stopwatch.StartNew();

            var floor = this.manager.FloorData[1, 1];

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
