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
using System.Threading;
using GW2DotNET.V1;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    using System.Threading.Tasks;

    /// <summary>
    /// The guild tests.
    /// </summary>
    [TestFixture]
    public class GuildTests
    {
        /// <summary>
        /// The guild manager.
        /// </summary>
        private ApiManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new ApiManager(GW2DotNET.V1.Infrastructure.Language.En);
        }

        /// <summary>
        /// Gets a single guild from the api.
        /// </summary>
        [Test]
        public void GetSingleGuild()
        {
            Stopwatch watch = Stopwatch.StartNew();

            var guild = this.manager.GuildData.GetSingleGuildAsync(new Guid("FBEACB6E-975B-4E10-9E52-B4E140F1C3B8")).Result;

            watch.Stop();

            Assert.IsNotNullOrEmpty(guild.Name);

            Trace.WriteLine(string.Format("Elapsed time: {0}", watch.ElapsedMilliseconds));
            Trace.WriteLine(string.Format("Guild Name: {0}", guild.Name));
        }

        /// <summary>
        /// Gets a single guild from the api.
        /// </summary>
        [Test]
        public async Task GetSingleGuildFromIdAsync()
        {
            Stopwatch watch = Stopwatch.StartNew();

            var guild = await this.manager.GuildData.GetSingleGuildAsync(new Guid("FBEACB6E-975B-4E10-9E52-B4E140F1C3B8"));

            watch.Stop();

            Assert.IsNotNullOrEmpty(guild.Name);

            Trace.WriteLine(string.Format("Elapsed time: {0}", watch.ElapsedMilliseconds));
            Trace.WriteLine(string.Format("Guild Name: {0}", guild.Name));
        }

        /// <summary>
        /// Gets a single guild from the api.
        /// </summary>
        [Test]
        public async Task GetSingleGuildFromNameAsync()
        {
            Stopwatch watch = Stopwatch.StartNew();

            var guild = await this.manager.GuildData.GetSingleGuildAsync("Wayward Blade");

            watch.Stop();

            Assert.AreNotEqual(guild.Id, Guid.Empty);

            Trace.WriteLine(string.Format("Elapsed time: {0}", watch.ElapsedMilliseconds));
            Trace.WriteLine(string.Format("Guild Name: {0}", guild.Id));
        }
    }
}
