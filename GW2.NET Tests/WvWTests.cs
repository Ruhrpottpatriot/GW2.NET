// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WvWTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WvWTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Linq;

using GW2DotNET.V1;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    /// <summary>
    /// The wvw tests.
    /// </summary>
    [TestFixture]
    public class WvWTests
    {
        /// <summary>
        /// The wvw manager.
        /// </summary>
        private ApiManager manager;

        /// <summary>
        /// Runs before each test run
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new ApiManager(GW2DotNET.V1.Infrastructure.Language.En);
        }

        /// <summary>
        /// Gets all matches from the api.
        /// </summary>
        [Test]
        public void GetMatchList()
        {
            var stopwatch = Stopwatch.StartNew();

            var matches = this.manager.WvWMatches.All;

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of Matches: {0}", matches.Count));
        }

        /// <summary>
        /// Gets a single match from the api.
        /// </summary>
        [Test]
        public void GetSingleMatch()
        {
            var stopwatch = Stopwatch.StartNew();

            var singleMatch = this.manager.WvWMatches.GetSingleMatch("1-1");

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Match Id: {0}", singleMatch.MatchId));
        }
    }
}
