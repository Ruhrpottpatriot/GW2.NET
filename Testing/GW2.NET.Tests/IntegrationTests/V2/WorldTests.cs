namespace GW2NET.IntegrationTests.V2
{
    using System.Linq;

    using GW2NET.Common;

    using Xunit;
    using Xunit.Abstractions;

    public class WorldTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        private readonly ITestOutputHelper logger;

        public WorldTests(ITestOutputHelper logger)
        {
            this.logger = logger;
        }

        [Fact]
        public void Discover()
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var result = repository.Discover();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void DiscoverAsync()
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var result = await repository.DiscoverAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(1001)]
        [InlineData(1002)]
        [InlineData(1003)]
        public void Find(int identifier)
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var result = repository.Find(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.WorldId);
        }

        [Theory]
        [InlineData(1001)]
        [InlineData(1002)]
        [InlineData(1003)]
        public async void FindAsync(int identifier)
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var result = await repository.FindAsync(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.WorldId);
        }

        [Fact]
        public void FindAll()
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
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
            var repository = GW2.Services.Worlds.ForDefaultCulture();
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
        public void FindAll_WithIdList(int[] filter)
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var result = repository.FindAll(filter);
            Assert.NotNull(result);
            Assert.StrictEqual(filter.Length, result.Count);
            foreach (var identifier in filter)
            {
                Assert.NotNull(result[identifier]);
                Assert.StrictEqual(identifier, result[identifier].WorldId);
            }
        }

        [Theory]
        [InlineData(new[] { 1001, 1002, 1003 })]
        public async void FindAllAsync_WithIdList(int[] filter)
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var result = await repository.FindAllAsync(filter);
            Assert.NotNull(result);
            Assert.StrictEqual(filter.Length, result.Count);
            foreach (var identifier in filter)
            {
                Assert.NotNull(result[identifier]);
                Assert.StrictEqual(identifier, result[identifier].WorldId);
            }
        }

        [Fact]
        public void FindAll_WithIdListTooLong_ServceException()
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var filter = Enumerable.Range(1, 201).ToArray();
            var exception = Assert.Throws<ServiceException>(() => repository.FindAll(filter));
            this.logger.WriteLine(exception.Message);
        }

        [Fact]
        public async void FindAllAsync_WithIdListTooLong_ServceException()
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var filter = Enumerable.Range(1, 201).ToArray();
            var exception = await Assert.ThrowsAsync<ServiceException>(() => repository.FindAllAsync(filter));
            this.logger.WriteLine(exception.Message);
        }

        [Theory]
        [InlineData(0)]
        public void FindPage(int pageIndex)
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var result = repository.FindPage(pageIndex);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.StrictEqual(pageIndex, result.PageIndex);
        }

        [Theory]
        [InlineData(0)]
        public async void FindPageAsync(int pageIndex)
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
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
            var repository = GW2.Services.Worlds.ForDefaultCulture();
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
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var result = await repository.FindPageAsync(pageIndex, pageSize);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.StrictEqual(pageIndex, result.PageIndex);
            Assert.StrictEqual(pageSize, result.PageSize);
        }

        [Fact]
        public void FindPage_WithPageSizeOutOfRange_ServiceException()
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var exception = Assert.Throws<ServiceException>(() => repository.FindPage(0, 201));
            this.logger.WriteLine(exception.Message);
        }

        [Fact]
        public async void FindPageAsync_WithPageSizeOutOfRange_ServiceException()
        {
            var repository = GW2.Services.Worlds.ForDefaultCulture();
            var exception = await Assert.ThrowsAsync<ServiceException>(() => repository.FindPageAsync(0, 201));
            this.logger.WriteLine(exception.Message);
        }
    }
}