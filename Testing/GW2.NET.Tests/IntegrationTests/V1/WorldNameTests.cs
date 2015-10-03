// <copyright file="WorldNameTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.IntegrationTests.V1
{
    using System;

    using Xunit;

    public class WorldNameTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        [Fact]
        public void Discover_NotSupported()
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.Discover());
        }

        [Fact]
        public async void DiscoverAsync_NotSupported()
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.DiscoverAsync());
        }

        [Theory]
        [InlineData(1001)]
        [InlineData(1002)]
        [InlineData(1003)]
        public void Find_NotSupported(int identifier)
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.Find(identifier));
        }

        [Theory]
        [InlineData(1001)]
        [InlineData(1002)]
        [InlineData(1003)]
        public async void FindAsync_NotSupported(int identifier)
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAsync(identifier));
        }

        [Fact]
        public void FindAll()
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            var result = repository.FindAll();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var kvp in result)
            {
                Assert.NotNull(kvp.Value);
                Assert.StrictEqual(kvp.Key, kvp.Value.WorldId);
            }
        }

        [Fact]
        public async void FindAllAsync()
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            var result = await repository.FindAllAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var kvp in result)
            {
                Assert.NotNull(kvp.Value);
                Assert.StrictEqual(kvp.Key, kvp.Value.WorldId);
            }
        }

        [Theory]
        [InlineData(new[] { 1001, 1002, 1003 })]
        public void FindAll_WithIdList_NotSupported(int[] filter)
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindAll(filter));
        }

        [Theory]
        [InlineData(new[] { 1001, 1002, 1003 })]
        public async void FindAllAsync_WithIdList_NotSupported(int[] filter)
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync(filter));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPage_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void FindPageAsync_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 10010)]
        [InlineData(0, 200)]
        public void FindPage_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex, pageSize));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 10010)]
        [InlineData(0, 200)]
        public async void FindPageAsync_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Worlds.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex, pageSize));
        }
    }
}
