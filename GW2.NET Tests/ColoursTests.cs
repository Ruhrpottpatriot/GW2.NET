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
        private Gw2ApiManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new Gw2ApiManager(Language.En);
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

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Total colours: {0}", colours.Count);
        }

        /// <summary>
        /// Gets a single single colour.
        /// </summary>
        [Test]
        public void GetSingleColour()
        {
            var stopwatch = Stopwatch.StartNew();

            var colour = this.manager.Colours[1231];

            stopwatch.Stop();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Single colour name: {0}", colour.Name);
        }
    }
}
