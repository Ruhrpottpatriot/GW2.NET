// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapInformationTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventDataTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.MapInformation.Models;

using NUnit.Framework;

namespace GW2DotNET_Tests
{
    /// <summary>
    /// The event data tests.
    /// </summary>
    [TestFixture]
    public class MapInformationTests
    {
        /// <summary>
        /// The world manager.
        /// </summary>
        private IDataManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new DataManager(Language.En);
        }

        /// <summary>Gets all continents</summary>
        [Test]
        public void GetAllContinents()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Continent> continents = this.manager.ContinentData.GetAllContinents().ToList();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of continents: {0}", continents.Count));
        }

        /// <summary>Gets all continentsAsynchronously</summary>
        [Test]
        public async void GetAllContinentsAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Task<IEnumerable<Continent>> task = this.manager.ContinentData.GetAllContinentsAsync();

            List<Continent> continents = (await task).ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(continents);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of continents: {0}", continents.Count));
        }

        /// <summary>Gets all maps.</summary>
        [Test]
        public void GetAllMaps()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Map> maps = this.manager.MapsData.GetMapList().ToList();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of maps: {0}", maps.Count));
        }

        /// <summary>Gets all maps.</summary>
        [Test]
        public async void GetAllMapsAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Task<IEnumerable<Map>> task = this.manager.MapsData.GetMapListAsync();

            List<Map> maps = (await task).ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(maps);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of maps: {0}", maps.Count));
        }

        /// <summary>Gets a map by its id.</summary>
        [Test]
        public void GetMapById()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Map map1 = this.manager.MapsData.GetMap(80);

            Map map2 = this.manager.MapsData.GetMap(80);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Assert.IsNotNull(map1, "map1 is null.");
            Assert.IsNotNull(map2, "map2 is null.");
            Assert.AreEqual(map1, map2);
        }

        /// <summary>Gets a map by its id asynchronously.</summary>
        [Test]
        public async void GetMapByIdAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Task<Map> task1 = this.manager.MapsData.GetMapAsync(80);

            Task<Map> task2 = this.manager.MapsData.GetMapAsync(80);

            Map map1 = await task1;
            Map map2 = await task2;

            stopwatch.Stop();

            Assert.IsNotNull(map1);

            Assert.IsNotNull(map2);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("The two maps are equal: {0}", map1 == map2));
        }

        /// <summary>Gets a map by its name.</summary>
        public void GetMapByName()
        {
            // var stopwatch = Stopwatch.StartNew();
            // var map1 = this.manager.MapsData.get  ["A Society Function"];
            // var map2 = this.manager.Maps["A Society Function"];
            // Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);
            // Debug.WriteLine("The two maps are equal: {0}", map1 == map2);
        }

        /// <summary>Gets a complete map floor.</summary>
        [Test]
        public void GetMapFloor()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            MapFloor floor = this.manager.MapFloorData.GetMapFloor(1, 1);

            stopwatch.Stop();

            Assert.IsNotNull(floor);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));
        }

        /// <summary>Gets a complete map floor asynchronously.</summary>
        [Test]
        public async void GetMapFloorAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.MapFloorData.GetMapFloorAsync(1, 1);

            var mapFloor = await task;

            stopwatch.Stop();

            Assert.IsNotEmpty(mapFloor.Regions);

            Assert.IsNotEmpty(mapFloor.TextureDims);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));
        }
    }
}
