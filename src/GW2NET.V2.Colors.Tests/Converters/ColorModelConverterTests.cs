// <copyright file="ColorModelConverterTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Colors.Converters
{
    using GW2NET.V2.Colors.Json;

    using Xunit;

    public class ColorModelConverterTests
    {
        private readonly ColorConverterMock colorConverter;

        private readonly ColorModelConverter converter;

        public ColorModelConverterTests()
        {
            this.colorConverter = new ColorConverterMock();
            this.converter = new ColorModelConverter(this.colorConverter);
        }

        [Theory]
        [InlineData(15, 1.25, 38, 0.28125, 1.44531, new[] { 124, 108, 83 })]
        [InlineData(-8, 1, 34, 0.3125, 1.09375, new[] { 65, 49, 29 })]
        [InlineData(5, 1.05469, 38, 0.101563, 1.36719, new[] { 96, 91, 83 })]
        public void CanConvert(int brightness, double contrast, int hue, double saturation, double lightness, int[] rgb)
        {
            var value = new ColorModelDTO
            {
                Brightness = brightness,
                Contrast = contrast,
                Hue = hue,
                Saturation = saturation,
                Lightness = lightness,
                Rgb = rgb
            };
            var result = this.converter.Convert(value, null);
            Assert.NotNull(result);
            Assert.Equal(brightness, result.Brightness);
            Assert.Equal(contrast, result.Contrast);
            Assert.Equal(hue, result.Hue);
            Assert.Equal(saturation, result.Saturation);
            Assert.Equal(lightness, result.Lightness);
            Assert.Equal(1, this.colorConverter.ConvertCount);
        }
    }
}
