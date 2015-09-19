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