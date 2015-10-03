// <copyright file="FloorTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.IntegrationTests.V1
{
    using System;

    using Xunit;

    public class FloorTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        [Fact]
        public void Discover_NotSupported()
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            Assert.Throws<NotSupportedException>(() => repository.Discover());
        }

        [Fact]
        public async void DiscoverAsync_NotSupported()
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.DiscoverAsync());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Find(int identifier)
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            var result = repository.Find(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.FloorId);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void FindAsync(int identifier)
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            var result = await repository.FindAsync(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.FloorId);
        }

        [Fact]
        public void FindAll_NotSupported()
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            Assert.Throws<NotSupportedException>(() => repository.FindAll());
        }

        [Fact]
        public async void FindAllAsync_NotSupported()
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync());
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 })]
        public void FindAll_WithIdList_NotSupported(int[] filter)
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            Assert.Throws<NotSupportedException>(() => repository.FindAll(filter));
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 })]
        public async void FindAllAsync_WithIdList_NotSupported(int[] filter)
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPage_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void FindPageAsync_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 10)]
        [InlineData(0, 200)]
        public void FindPage_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex, pageSize));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 10)]
        [InlineData(0, 200)]
        public async void FindPageAsync_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Floors.ForDefaultCulture(1);
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex, pageSize));
        }
    }
}
