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
using System.Threading.Tasks;

using GW2DotNET.V1;
using GW2DotNET.V1.Infrastructure;

using NUnit.Framework;

namespace GW2DotNET_Tests
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
        private IDataManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new DataManager(Language.En);
        }

        [Test]
        public void CheckCache()
        {
            var colourData = this.manager.ColourData;

            var dyes = colourData.Dyes.ToList();

            Assert.IsNotEmpty(dyes);

            Trace.WriteLine(dyes.Count);
        }

        /// <summary>
        /// Gets all colours from the api.
        /// </summary>
        [Test]
        public void GetDyes()
        {
            var stopwatch = Stopwatch.StartNew();

            var colourData = this.manager.ColourData;

            var dyes = colourData.GetDyes().ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(dyes);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total colours: {0}", dyes.Count));
        }

        /// <summary>
        /// Gets all colours asynchronously from the api.
        /// </summary>
        [Test]
        public async Task GetDyesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var colourData = this.manager.ColourData;

            var dyes = (await colourData.GetDyesAsync().ConfigureAwait(false)).ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(dyes);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total colours: {0}", dyes.Count()));
        }
    }
}
