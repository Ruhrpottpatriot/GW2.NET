// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColoursTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The colours tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;

using GW2DotNET.V1.Items.DataProviders;

namespace GW2.NET_Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using GW2DotNET.V1;
    using GW2DotNET.V1.Infrastructure;
    using GW2DotNET.V1.Items.Models;

    using NUnit.Framework;

    /// <summary>
    /// The colours tests.
    /// </summary>
    [TestFixture]
    public class ColoursTests
    {
        /// <summary>
        /// The item manager.
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

        /// <summary>
        /// Gets all colours from the api.
        /// </summary>
        [Test]
        public void GetColours()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            ColourData colourData = this.manager.ColourData;

            List<GwColour> colours = colourData.GetColourList().ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(colourData.ColourList);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total colours: {0}", colours.Count));
        }

        /// <summary>
        /// Gets all colours asynchronously from the api.
        /// </summary>
        [Test]
        public async Task GetAllColoursAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            ColourData colourData = this.manager.ColourData;

            IEnumerable<GwColour> coloursTask = await colourData.GetColourListAsync();

            IEnumerable<GwColour> colours = coloursTask.ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(colours);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total colours: {0}", colours.Count()));
        }

        /// <summary>
        /// Gets a single single colour by ID.
        /// </summary>
        [Test]
        public void GetSingleColourFromId()
        {
            var stopwatch = Stopwatch.StartNew();

            var colour = this.manager.ColourData.GetSingleColour(1231);

            stopwatch.Stop();

            Assert.IsNotNullOrEmpty(colour.Name);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Single colour name: {0}", colour.Name));
        }

        /// <summary>The get colour from id asynchronously.</summary>
        [Test]
        public async Task GetColourFromIdAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.ColourData.GetSingleColourAsync(1231);
            task.Wait();

            stopwatch.Stop();

            Assert.IsNotNullOrEmpty(task.Result.Name);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Single colour name: {0}", task.Result.Name));
        }
    }
}
