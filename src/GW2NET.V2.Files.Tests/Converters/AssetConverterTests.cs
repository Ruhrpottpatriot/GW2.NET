namespace GW2NET.V2.Files.Converters
{
    using Xunit;

    public class AssetConverterTests
    {
        private readonly AssetConverter converter = new AssetConverter();

        [Theory]
        [InlineData("map_complete", 528724, "5A4E663071250EC72668C09E3C082E595A380BF7", "https://render.guildwars2.com/file/5A4E663071250EC72668C09E3C082E595A380BF7/528724.png")]
        public void CanConvert(string identifier, int fileId, string fileSignature, string icon)
        {
            var value = new FileDataContract
            {
                Id = identifier,
                Icon = icon
            };

            var result = this.converter.Convert(value);
            Assert.NotNull(result);
            Assert.NotNull(result.IconFileUrl);
            Assert.Equal(fileId, result.FileId);
            Assert.Equal(fileSignature, result.FileSignature);
            Assert.Equal(icon, result.IconFileUrl.ToString());
        }
    }
}
