namespace GW2NET.V2.Builds.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.V2.Builds.Json;

    using Xunit;

    public class BuildConverterTests
    {
        private readonly BuildConverter converter = new BuildConverter();

        [Theory]
        [InlineData(0, "Tue, 26 May 2015 18:46:01 GMT")]
        [InlineData(1, "Tue, 26 May 2015 18:46:01 GMT")]
        [InlineData(-1, "Tue, 26 May 2015 18:46:01 GMT")]
        [InlineData(-1, "Tue, 26 May 2015 18:46:01 GMT")]
        [InlineData(10000, "Tue, 26 May 2015 18:46:01 GMT")]
        [InlineData(100000, "Tue, 26 May 2015 18:46:01 GMT")]
        public void CanConvert(int buildId, DateTime date)
        {
            var value = new BuildDataContract { BuildId = buildId };
            var state = new Response<BuildDataContract>
                            {
                                Content = value,
                                Date = date
                            };
            var result = this.converter.Convert(value, state);
            Assert.NotNull(result);
            Assert.Equal(buildId, result.BuildId);
            Assert.Equal(date, result.Timestamp);
        }
    }
}
