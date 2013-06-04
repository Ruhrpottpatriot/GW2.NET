// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The guild tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Linq;

using GW2DotNET.V1.Guilds;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    /// <summary>
    /// The guild tests.
    /// </summary>
    [TestFixture]
    public class GuildTests
    {
        /// <summary>
        /// The guild manager.
        /// </summary>
        private GuildManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new GuildManager();
        }

        /// <summary>
        /// Gets a single guild from the api.
        /// </summary>
        [Test]
        public void GetSingleGuild()
        {
            Stopwatch watch = Stopwatch.StartNew();

            var guild = this.manager.GuildData[new Guid("FBEACB6E-975B-4E10-9E52-B4E140F1C3B8")];

            watch.Stop();

            Debug.WriteLine("Elapsed time: {0}", watch.ElapsedMilliseconds);
            Debug.WriteLine("Guild Name: {0}", guild.Name);
        }

        /// <summary>
        /// Gets all guilds from the api.
        /// </summary>
        [Test]
        public void GetGuilds()
        {
            Stopwatch watch = Stopwatch.StartNew();

            var guilds = this.manager.GuildData.ToList();

            watch.Stop();
            
            Debug.WriteLine("Elapsed time: {0}", watch.ElapsedMilliseconds);
            Debug.WriteLine("Number of guilds: {0}", guilds.Count);
        }
    }
}
