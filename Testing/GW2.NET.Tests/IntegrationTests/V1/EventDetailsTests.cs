namespace GW2NET.IntegrationTests.V1
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    public class EventDetailsTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        [Fact]
        public void Discover_NotSupported()
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.Discover());
        }

        [Fact]
        public async void DiscoverAsync_NotSupported()
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.DiscoverAsync());
        }

        [Theory]
        [MemberData("GetIdentifiers")]
        public void Find(Guid identifier)
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            var result = repository.Find(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.EventId);
        }

        [Theory]
        [MemberData("GetIdentifiers")]
        public async void FindAsync(Guid identifier)
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            var result = await repository.FindAsync(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.EventId);
        }

        [Fact]
        public void FindAll()
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            var result = repository.FindAll();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var kvp in result)
            {
                Assert.NotNull(kvp.Value);
                Assert.StrictEqual(kvp.Key, kvp.Value.EventId);
            }
        }

        [Fact]
        public async void FindAllAsync()
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            var result = await repository.FindAllAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var kvp in result)
            {
                Assert.NotNull(kvp.Value);
                Assert.StrictEqual(kvp.Key, kvp.Value.EventId);
            }
        }

        public static IEnumerable<object[]> GetIdentifiers()
        {
            yield return new object[]
            {
                Guid.Parse("EED8A79F-B374-4AE6-BA6F-B7B98D9D7142"),
            };

            yield return new object[]
            {
                Guid.Parse("3A2B85C5-DE73-4402-BD84-8F53AA394A52"),
            };

            yield return new object[]
            {
                Guid.Parse("CEA84FBF-2368-467C-92EA-7FA60D527C7B")
            };
        }

        public static IEnumerable<object[]> GetFilters()
        {
            yield return new object[]
            {
                new[]
                {
                    Guid.Parse("EED8A79F-B374-4AE6-BA6F-B7B98D9D7142"),
                    Guid.Parse("3A2B85C5-DE73-4402-BD84-8F53AA394A52"),
                    Guid.Parse("CEA84FBF-2368-467C-92EA-7FA60D527C7B")
                }
            };
        }

        [Theory]
        [MemberData("GetFilters")]
        public void FindAll_WithIdList_NotSupported(Guid[] filter)
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindAll(filter));
        }

        [Theory]
        [MemberData("GetFilters")]
        public async void FindAllAsync_WithIdList_NotSupported(Guid[] filter)
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync(filter));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPage_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void FindPageAsync_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public void FindPage_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex, pageSize));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public async void FindPageAsync_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Events.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex, pageSize));
        }
    }
}
