// <copyright file="FileTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.IntegrationTests.V1
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    public class FileTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        public static IEnumerable<object[]> GetFilters()
        {
            yield return new object[] { new[] { "map_complete", "map_dungeon", "map_heart_empty" } };
        }

        [Fact]
        public void Discover_NotSupported()
        {
            var repository = GW2.V1.Files;
            Assert.Throws<NotSupportedException>(() => repository.Discover());
        }

        [Fact]
        public async void DiscoverAsync_NotSupported()
        {
            var repository = GW2.V1.Files;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.DiscoverAsync());
        }

        [Theory]
        [InlineData("map_complete")]
        [InlineData("map_dungeon")]
        [InlineData("map_heart_empty")]
        public void Find_NotSupported(string identifier)
        {
            var repository = GW2.V1.Files;
            Assert.Throws<NotSupportedException>(() => repository.Find(identifier));
        }

        [Theory]
        [InlineData("map_complete")]
        [InlineData("map_dungeon")]
        [InlineData("map_heart_empty")]
        public async void FindAsync_NotSupported(string identifier)
        {
            var repository = GW2.V1.Files;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAsync(identifier));
        }

        [Fact]
        public void FindAll()
        {
            var repository = GW2.V1.Files;
            var result = repository.FindAll();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var kvp in result)
            {
                Assert.NotNull(kvp.Value);
                Assert.StrictEqual(kvp.Key, kvp.Value.Identifier);
            }
        }

        [Fact]
        public async void FindAllAsync()
        {
            var repository = GW2.V1.Files;
            var result = await repository.FindAllAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var kvp in result)
            {
                Assert.NotNull(kvp.Value);
                Assert.StrictEqual(kvp.Key, kvp.Value.Identifier);
            }
        }

        [Theory]
        [MemberData("GetFilters")]
        public void FindAll_WithIdList_NotSupported(string[] filter)
        {
            var repository = GW2.V1.Files;
            Assert.Throws<NotSupportedException>(() => repository.FindAll(filter));
        }

        [Theory]
        [MemberData("GetFilters")]
        public async void FindAllAsync_WithIdList_NotSupported(string[] filter)
        {
            var repository = GW2.V1.Files;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync(filter));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPage_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Files;
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void FindPageAsync_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Files;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public void FindPage_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Files;
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex, pageSize));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public async void FindPageAsync_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Files;
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex, pageSize));
        }
    }
}
