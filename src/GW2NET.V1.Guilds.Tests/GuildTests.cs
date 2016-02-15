// <copyright file="GuildTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.IntegrationTests.V1
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    public class GuildTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        public static IEnumerable<object[]> GetIdentifiers()
        {
            yield return new object[]
            {
                Guid.Parse("75FD83CF-0C45-4834-BC4C-097F93A487AF"),
            };
        }

        public static IEnumerable<object[]> GetFilters()
        {
            yield return new object[]
            {
                new[]
                {
                    Guid.Parse("75FD83CF-0C45-4834-BC4C-097F93A487AF"),
                }
            };
        }

        [Fact]
        public void Discover_NotSupported()
        {
            var repository = GW2.Services.Guilds;
            Assert.Throws<NotSupportedException>(() => repository.Discover());
        }

        [Fact]
        public async void DiscoverAsync_NotSupported()
        {
            var repository = GW2.Services.Guilds;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.DiscoverAsync());
        }

        [Theory]
        [MemberData("GetIdentifiers")]
        public void Find(Guid identifier)
        {
            var repository = GW2.Services.Guilds;
            var result = repository.Find(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.GuildId);
        }

        [Theory]
        [MemberData("GetIdentifiers")]
        public async void FindAsync(Guid identifier)
        {
            var repository = GW2.Services.Guilds;
            var result = await repository.FindAsync(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.GuildId);
        }

        [Theory]
        [InlineData("Veterans Of Lions Arch")]
        public void FindByName(string name)
        {
            var repository = GW2.Services.Guilds;
            var result = repository.FindByName(name);
            Assert.NotNull(result);
            Assert.StrictEqual(name, result.Name);
        }

        [Theory]
        [InlineData("Veterans Of Lions Arch")]
        public async void FindByNameAsync(string name)
        {
            var repository = GW2.Services.Guilds;
            var result = await repository.FindByNameAsync(name);
            Assert.NotNull(result);
            Assert.StrictEqual(name, result.Name);
        }

        [Fact]
        public void FindAll_NotSupported()
        {
            var repository = GW2.Services.Guilds;
            Assert.Throws<NotSupportedException>(() => repository.FindAll());
        }

        [Fact]
        public async void FindAllAsync_NotSupported()
        {
            var repository = GW2.Services.Guilds;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync());
        }

        [Theory]
        [MemberData("GetFilters")]
        public void FindAll_WithIdList_NotSupported(Guid[] filter)
        {
            var repository = GW2.Services.Guilds;
            Assert.Throws<NotSupportedException>(() => repository.FindAll(filter));
        }

        [Theory]
        [MemberData("GetFilters")]
        public async void FindAllAsync_WithIdList_NotSupported(Guid[] filter)
        {
            var repository = GW2.Services.Guilds;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync(filter));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPage_NotSupported(int pageIndex)
        {
            var repository = GW2.Services.Guilds;
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void FindPageAsync_NotSupported(int pageIndex)
        {
            var repository = GW2.Services.Guilds;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public void FindPage_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.Services.Guilds;
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex, pageSize));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public async void FindPageAsync_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.Services.Guilds;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex, pageSize));
        }
    }
}
