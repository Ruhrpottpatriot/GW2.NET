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

using GW2DotNET.V1.WvW;

using NUnit.Framework;
using GW2DotNET.V1;

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
        private GW2ApiManager manager;

        /// <summary>
        /// Runs before each test run
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new GW2ApiManager(GW2DotNET.V1.Infrastructure.Language.En);
        }

        /// <summary>
        /// Gets all matches from the api.
        /// </summary>
        [Test]
        public void GetMatches()
        {
            var matches = this.manager.WvWMatches.ToList();

            Debug.WriteLine("Total number of matches: {0}", matches.Count);
        }

        /// <summary>
        /// Gets a single match from the api.
        /// </summary>
        [Test]
        public void GetMatch()
        {
            var match = this.manager.WvWMatches["1-1"];

            Debug.WriteLine("Start Time: {0}, End Time: {1}", match.StartTime, match.EndTime);
        }
    }
}
