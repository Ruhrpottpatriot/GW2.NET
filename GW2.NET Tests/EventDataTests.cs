// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventDataTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventDataTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
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
    }
}
