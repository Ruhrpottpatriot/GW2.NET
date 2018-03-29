// <copyright file="FileTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.IntegrationTests.V2
{
    using System.Collections.Generic;
    using System.Linq;

    using GW2NET.Common;

    using Xunit;
    using Xunit.Abstractions;

    public class FileTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        private readonly ITestOutputHelper logger;

        public FileTests(ITestOutputHelper logger)
        {
            this.logger = logger;
        }

        public static IEnumerable<object[]> GetIdentifiers()
        {
            yield return new object[] { new[] { "map_complete", "map_dungeon", "map_heart_empty" } };
        }

        [Fact]
        public void Discover()
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = repository.Discover();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void DiscoverAsync()
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = await repository.DiscoverAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("map_complete")]
        [InlineData("map_dungeon")]
        [InlineData("map_heart_empty")]
        public void Find(string identifier)
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = repository.Find(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.Identifier);
        }

        [Theory]
        [InlineData("map_complete")]
        [InlineData("map_dungeon")]
        [InlineData("map_heart_empty")]
        public async void FindAsync(string identifier)
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = await repository.FindAsync(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.Identifier);
        }

        [Fact]
        public void FindAll()
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
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
            var repository = GW2.Services.Files.ForDefaultCulture();
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
        [MemberData("GetIdentifiers")]
        public void FindAll_WithIdList(string[] filter)
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = repository.FindAll(filter);
            Assert.NotNull(result);
            Assert.StrictEqual(filter.Length, result.Count);
            foreach (var identifier in filter)
            {
                Assert.NotNull(result[identifier]);
                Assert.StrictEqual(identifier, result[identifier].Identifier);
            }
        }

        [Theory]
        [MemberData("GetIdentifiers")]
        public async void FindAllAsync_WithIdList(string[] filter)
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = await repository.FindAllAsync(filter);
            Assert.NotNull(result);
            Assert.StrictEqual(filter.Length, result.Count);
            foreach (var identifier in filter)
            {
                Assert.NotNull(result[identifier]);
                Assert.StrictEqual(identifier, result[identifier].Identifier);
            }
        }

        [Fact(Skip = "Not enough IDs to test with")]
        public void FindAll_WithIdListTooLong_ServceException()
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var filter = Enumerable.Repeat(string.Empty, 201).ToArray();
            var exception = Assert.Throws<ServiceException>(() => repository.FindAll(filter));
            this.logger.WriteLine(exception.Message);
        }

        [Fact(Skip = "Not enough IDs to test with")]
        public async void FindAllAsync_WithIdListTooLong_ServceException()
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var filter = Enumerable.Repeat(string.Empty, 201).ToArray();
            var exception = await Assert.ThrowsAsync<ServiceException>(() => repository.FindAllAsync(filter));
            this.logger.WriteLine(exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void FindPage(int pageIndex)
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = repository.FindPage(pageIndex);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.StrictEqual(pageIndex, result.PageIndex);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async void FindPageAsync(int pageIndex)
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = await repository.FindPageAsync(pageIndex);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.StrictEqual(pageIndex, result.PageIndex);
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public void FindPage_WithPageSize(int pageIndex, int pageSize)
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = repository.FindPage(pageIndex, pageSize);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.StrictEqual(pageIndex, result.PageIndex);
            Assert.StrictEqual(pageSize, result.PageSize);
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public async void FindPageAsync_WithPageSize(int pageIndex, int pageSize)
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var result = await repository.FindPageAsync(pageIndex, pageSize);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.StrictEqual(pageIndex, result.PageIndex);
            Assert.StrictEqual(pageSize, result.PageSize);
        }

        [Fact]
        public void FindPage_WithPageSizeOutOfRange_ServiceException()
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var exception = Assert.Throws<ServiceException>(() => repository.FindPage(0, 201));
            this.logger.WriteLine(exception.Message);
        }

        [Fact]
        public async void FindPageAsync_WithPageSizeOutOfRange_ServiceException()
        {
            var repository = GW2.Services.Files.ForDefaultCulture();
            var exception = await Assert.ThrowsAsync<ServiceException>(() => repository.FindPageAsync(0, 201));
            this.logger.WriteLine(exception.Message);
        }
    }
}