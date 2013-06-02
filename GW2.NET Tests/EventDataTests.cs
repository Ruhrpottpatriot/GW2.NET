// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventDataTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventDataTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Linq;

using GW2DotNET.V1.World;
using GW2DotNET.V1.World.Models;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    /// <summary>
    /// The event data tests.
    /// </summary>
    [TestFixture]
    public class EventDataTests
    {
        /// <summary>
        /// The world manager.
        /// </summary>
        private WorldManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new WorldManager();
        }

        /// <summary>
        ///  Gets all events from the server.
        /// </summary>
        [Test]
        public void GetAllEvents()
        {
            var stopwatch = Stopwatch.StartNew();

            var events = this.manager.Events.ToList();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Total Number of Events: {0}", events.Count);
        }

        /// <summary>
        /// Gets an event by world id.
        /// </summary>
        [Test]
        public void GetEventsByWorld()
        {
            var stopwatch = Stopwatch.StartNew();

            var events = this.manager.Events.ToList();

            stopwatch.Stop();

            Debug.WriteLine("Time passed until all events are returned: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Restarting stopwatch.");

            stopwatch.Restart();

            var eventsByWorld1001 = this.manager.Events[new GwWorld(1001, string.Empty)].ToList();

            var eventsByWorld1023 = this.manager.Events[new GwWorld(1023, string.Empty)].ToList();

            var eventsByWorld2207 = this.manager.Events[new GwWorld(2101, string.Empty)].ToList();

            stopwatch.Stop();

            Debug.WriteLine("Elapsed time since stopwatch restart: {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Stop();
            
            Debug.WriteLine("Elapsed time since stopwatch restart: {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();

            Debug.WriteLine("Total number of events on world 1001: {0}", eventsByWorld1001.Count);

            stopwatch.Stop();

            Debug.WriteLine("Elapsed time since stopwatch restart: {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            
            Debug.WriteLine("Total number of events on world 1023: {0}", eventsByWorld1023.Count);

            stopwatch.Stop();

            Debug.WriteLine("Elapsed time since stopwatch restart: {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
        
            Debug.WriteLine("Total number of events on world 2207: {0}", eventsByWorld2207.Count);

            stopwatch.Stop();

            Debug.WriteLine("Elapsed time since stopwatch restart: {0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
