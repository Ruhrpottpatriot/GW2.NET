﻿// <copyright file="SkinTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.IntegrationTests.V1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    public class SkinTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        private static readonly Lazy<IEnumerable<object[]>> LazyIdentifiers = new Lazy<IEnumerable<object[]>>(() => GW2.V1.Skins.ForDefaultCulture().Discover().Select(id => new object[] { id }));

        public static IEnumerable<object[]> GetIdentifiers()
        {
            return LazyIdentifiers.Value;
        }

        [Fact]
        public void Discover()
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            var result = repository.Discover();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void DiscoverAsync()
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            var result = await repository.DiscoverAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(1275)]
        [InlineData(959)]
        [InlineData(3721)]
        public void Find(int identifier)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            var result = repository.Find(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.SkinId);
        }

        [Theory]
        [InlineData(1275)]
        [InlineData(959)]
        [InlineData(3721)]
        public async void FindAsync(int identifier)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            var result = await repository.FindAsync(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.SkinId);
        }

        [Theory(Skip = "Long running")]
        [MemberData("GetIdentifiers")]
        public void CustomFindAll(int identifier)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            var result = repository.Find(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.SkinId);
        }

        [Theory(Skip = "Long running")]
        [MemberData("GetIdentifiers")]
        public async void CustomFindAllAsync(int identifier)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            var result = await repository.FindAsync(identifier);
            Assert.NotNull(result);
            Assert.StrictEqual(identifier, result.SkinId);
        }

        [Fact]
        public void FindAll_NotSupported()
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindAll());
        }

        [Fact]
        public async void FindAllAsync_NotSupported()
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync());
        }

        [Theory]
        [InlineData(new[] { 1275, 959, 3721 })]
        public void FindAll_WithIdList_NotSupported(int[] filter)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindAll(filter));
        }

        [Theory]
        [InlineData(new[] { 1275, 959, 3721 })]
        public async void FindAllAsync_WithIdList_NotSupported(int[] filter)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindAllAsync(filter));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPage_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void FindPageAsync_NotSupported(int pageIndex)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public void FindPage_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            Assert.Throws<NotSupportedException>(() => repository.FindPage(pageIndex, pageSize));
        }

        [Theory]
        [InlineData(0, 50)]
        [InlineData(0, 100)]
        [InlineData(0, 150)]
        [InlineData(0, 200)]
        public async void FindPageAsync_WithPageSize_NotSupported(int pageIndex, int pageSize)
        {
            var repository = GW2.V1.Skins.ForDefaultCulture();
            await Assert.ThrowsAsync<NotSupportedException>(() => repository.FindPageAsync(pageIndex, pageSize));
        }
    }
}
