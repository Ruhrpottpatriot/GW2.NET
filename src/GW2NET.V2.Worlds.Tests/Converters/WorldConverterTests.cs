namespace GW2NET.V2.Worlds.Converters
{
    using System.Globalization;

    using GW2NET.Common;

    using Xunit;

    public class WorldConverterTests
    {
        private readonly WorldConverter worldConverter = new WorldConverter();

        [Theory]
        [InlineData(1001, "Amboss-Stein", "de")]
        [InlineData(1001, "Anvil Rock", "en")]
        [InlineData(1001, "Roca del Yunque", "es")]
        [InlineData(1001, "Rocher de l'enclume", "fr")]
        public void CanConvert(int id, string name, string contentLanguage)
        {
            var value = new WorldDataContract
            {
                Id = id,
                Name = name
            };

            var state = new Response<WorldDataContract>
            {
                Culture = new CultureInfo(contentLanguage),
                Content = value
            };

            var result = this.worldConverter.Convert(value, state);
            Assert.NotNull(result);
            Assert.Equal(id, result.WorldId);
            Assert.Equal(name, result.Name);
            Assert.Equal(state.Culture, result.Culture);
        }
    }
}
