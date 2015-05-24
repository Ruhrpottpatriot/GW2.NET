namespace GW2NET.V1.Files.Converters
{
    using GW2NET.V1.Files.Json;

    using Xunit;

    public class ConverterForAssetTests
    {
        private readonly ConverterForAsset converter = new ConverterForAsset();

        [Theory]
        [InlineData("map_complete", 528724, "5A4E663071250EC72668C09E3C082E595A380BF7")]
        public void CanConvert(string identifier, int fileId, string fileSignature)
        {
            var value = new FileDataContract
            {
                FileId = fileId,
                Signature = fileSignature
            };

            var result = this.converter.Convert(value);
            Assert.NotNull(result);
            Assert.NotNull(result.IconFileUrl);
            Assert.Equal(fileId, result.FileId);
            Assert.Equal(fileSignature, result.FileSignature);
            Assert.Equal(string.Format("https://render.guildwars2.com/file/{0}/{1}.png", fileSignature, fileId), result.IconFileUrl.ToString());
        }
    }
}
