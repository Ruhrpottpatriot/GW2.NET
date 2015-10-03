// <copyright file="BuildTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.IntegrationTests.V1
{
    using System;

    using Xunit;

    public class BuildTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        [Fact]
        public void GetBuild()
        {
            var result = GW2.V1.Builds.GetBuild();
            Assert.NotNull(result);
            Assert.NotInRange(result.BuildId, int.MinValue, 0);
            Assert.NotStrictEqual(default(DateTimeOffset), result.Timestamp);
        }

        [Fact]
        public async void GetBuildAsync()
        {
            var result = await GW2.V1.Builds.GetBuildAsync();
            Assert.NotNull(result);
            Assert.NotInRange(result.BuildId, int.MinValue, 0);
            Assert.NotStrictEqual(default(DateTimeOffset), result.Timestamp);
        }
    }
}