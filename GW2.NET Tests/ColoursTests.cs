// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColoursTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The colours tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Linq;
using System.Threading;
using GW2DotNET.V1;
using GW2DotNET.V1.Infrastructure;
using NUnit.Framework;

namespace GW2.NET_Tests
{
    /// <summary>
    /// The colours tests.
    /// </summary>
    [TestFixture]
    public class ColoursTests
    {
        /// <summary>
        /// The item manager.
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
        /// Gets all colours from the api.
        /// </summary>
        [Test]
        public void GetColours()
        {
            var stopwatch = Stopwatch.StartNew();

            var colours = this.manager.Colours.ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(colours);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total colours: {0}", colours.Count));
        }

        /// <summary>
        /// Gets all colours asynchronously from the api.
        /// </summary>
        [Test]
        public void GetAllColoursAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Colours.GetAllColoursAsync(CancellationToken.None);
            task.Wait();

            stopwatch.Stop();

            Assert.IsNotEmpty(task.Result);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total colours: {0}", task.Result.Count()));
        }

        /// <summary>
        /// Gets a single single colour by ID.
        /// </summary>
        [Test]
        public void GetSingleColourFromId()
        {
            var stopwatch = Stopwatch.StartNew();

            var colour = this.manager.Colours[1231];

            stopwatch.Stop();

            Assert.IsNotNullOrEmpty(colour.Name);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Single colour name: {0}", colour.Name));
        }

        [Test]
        public void GetColourFromIdAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Colours.GetColourFromIdAsync(1231, CancellationToken.None);
            task.Wait();

            stopwatch.Stop();

            Assert.IsNotNullOrEmpty(task.Result.Name);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Single colour name: {0}", task.Result.Name));
        }

        /// <summary>
        /// Gets a single colour by name.
        /// </summary>
        [Test]
        public void GetSingleColourFromName()
        {
            var stopwatch = Stopwatch.StartNew();

            var colour = this.manager.Colours["Abyss"];

            stopwatch.Stop();

            Assert.Greater(colour.Id, 0);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Single colour name: {0}", colour.Name));
        }

        [Test]
        public void GetColourFromNameAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Colours.GetColourFromNameAsync("Abyss", CancellationToken.None);
            task.Wait();

            stopwatch.Stop();

            Assert.Greater(task.Result.Id, 0);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Single colour ID: {0}", task.Result.Id));
        }
    }
}
