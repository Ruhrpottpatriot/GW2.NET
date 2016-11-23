// <copyright file="MatchTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.WorldVersusWorld.Matches
{
    using Xunit;

    public class MatchesTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        private Xunit.Abstractions.ITestOutputHelper output;

        public MatchesTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("2-2")]
        public void MatchesContainTotalKillsAndDeaths(string identifier)
        {
            var repository = GW2.V2.WorldVersusWorld.Matches;
            var result = repository.Find(identifier);
            Assert.NotNull(result.Kills);
            Assert.NotEqual(0, result.Kills.Red);
            Assert.NotEqual(0, result.Kills.Blue);
            Assert.NotEqual(0, result.Kills.Green);
            Assert.NotNull(result.Deaths);
            Assert.NotEqual(0, result.Deaths.Red);
            Assert.NotEqual(0, result.Deaths.Blue);
            Assert.NotEqual(0, result.Deaths.Green);
        }

        [Theory]
        [InlineData("2-2")]
        public void MatchesContainKillsAndDeathsPerMap(string identifier)
        {
            var repository = GW2.V2.WorldVersusWorld.Matches;
            var result = repository.Find(identifier);
            Assert.NotNull(result.Maps);
            foreach (var map in result.Maps)
            {
                Assert.NotNull(map.Kills);
                Assert.NotEqual(0, map.Kills.Red);
                Assert.NotEqual(0, map.Kills.Blue);
                Assert.NotEqual(0, map.Kills.Green);
                Assert.NotNull(map.Deaths);
                Assert.NotEqual(0, map.Deaths.Red);
                Assert.NotEqual(0, map.Deaths.Blue);
                Assert.NotEqual(0, map.Deaths.Green);
            }
        }

        [Theory]
        [InlineData("1-1")]
        public void MatchesContainListOfWorlds(string identifier)
        {
            var worldRepo = GW2.V2.Worlds.ForDefaultCulture();
            var repository = GW2.V2.WorldVersusWorld.Matches;
            var result = repository.Find(identifier);

            var world = worldRepo.Find(result.Worlds.Red);
            Assert.NotNull(world);
            Assert.NotNull(world.Name);

            world = worldRepo.Find(result.Worlds.Blue);
            Assert.NotNull(world);
            Assert.NotNull(world.Name);

            world = worldRepo.Find(result.Worlds.Green);
            Assert.NotNull(world);
            Assert.NotNull(world.Name);
        }
    }
}
