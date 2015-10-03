// <copyright file="MatchTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.IntegrationTests.V1
{
    using System;
    using System.Collections.Generic;

    using GW2NET.WorldVersusWorld;

    using Xunit;

    public class MatchTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        public static IEnumerable<object[]> GetIdentifiers()
        {
            yield return new object[] { new Matchup { MatchId = "2-4" } };
            yield return new object[] { new Matchup { MatchId = "2-2" } };
            yield return new object[] { new Matchup { MatchId = "2-3" } };
        }

        public static IEnumerable<object[]> GetFilters()
        {
            yield return
                new object[]
                {
                    new[]
                    {
                        new Matchup { MatchId = "2-4" },
                        new Matchup { MatchId = "2-2" },
                        new Matchup { MatchId = "2-3" },
                    }
                };
        }

        [Fact]
        public void Discover()
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            var result = repository.Discover();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void DiscoverAsync()
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            var result = await repository.DiscoverAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [MemberData("GetIdentifiers")]
        public void Find(Matchup identifier)
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            var result = repository.Find(new Matchup { MatchId = identifier.MatchId });
            Assert.NotNull(result);
            Assert.StrictEqual(identifier.MatchId, result.MatchId);
        }

        [Theory]
        [MemberData("GetIdentifiers")]
        public async void FindAsync(Matchup identifier)
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            var result = await repository.FindAsync(new Matchup { MatchId = identifier.MatchId });
            Assert.NotNull(result);
            Assert.StrictEqual(identifier.MatchId, result.MatchId);
        }

        [Fact]
        public void FindAll_NotSupported()
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            Assert.Throws<NotSupportedException>(() => repository.FindAll());
        }

        [Fact]
        public async void FindAllAsync_NotSupported()
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync());
        }

        [Theory]
        [MemberData("GetFilters")]
        public void FindAll_WithIdList_NotSupported(Matchup[] filter)
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            Assert.Throws<NotSupportedException>(() => repository.FindAll(filter));
        }

        [Theory]
        [MemberData("GetFilters")]
        public async void FindAllAsync_WithIdList_NotSupported(Matchup[] filter)
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync(filter));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPage_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void FindPageAsync_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public void FindPage_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex, pageSize));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public async void FindPageAsync_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.WorldVersusWorld.Matches;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex, pageSize));
        }
    }
}
