// <copyright file="ColorPaletteConverterTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Colors.Converters
{
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.V2.Colors.Json;

    using Xunit;

    public class ColorPaletteConverterTests
    {
        private readonly ColorConverterMock colorConverterMock;
        private readonly ColorModelConverterMock colorModelConverterMock;
        private readonly ColorPaletteConverter colorPaletteConverter;

        public ColorPaletteConverterTests()
        {
            this.colorConverterMock = new ColorConverterMock();
            this.colorModelConverterMock = new ColorModelConverterMock();
            this.colorPaletteConverter = new ColorPaletteConverter(this.colorConverterMock, this.colorModelConverterMock);
        }

        [Theory]
        [InlineData("de", 1, "Farbentferner", new[] { 128, 26, 26 })]
        [InlineData("en", 1, "Dye Remover", new[] { 128, 26, 26 })]
        [InlineData("es", 1, "Disolvente de tinte", new[] { 128, 26, 26 })]
        [InlineData("fr", 1, "Dissolvant pour teinture", new[] { 128, 26, 26 })]
        public void CanConvert(string lang, int id, string name, int[] baseRgb)
        {
            var value = new ColorPaletteDTO
            {
                Id = id,
                Name = name,
                BaseRgb = baseRgb,
                Cloth = new ColorModelDTO(),
                Leather = new ColorModelDTO(),
                Metal = new ColorModelDTO()
            };

            var state = new Response<ColorPaletteDTO>
            {
                Content = value,
                Culture = new CultureInfo(lang)
            };

            var result = this.colorPaletteConverter.Convert(value, state);
            Assert.NotNull(result);
            Assert.Equal(state.Culture, result.Culture);
            Assert.Equal(id, result.ColorId);
            Assert.Equal(name, result.Name);
            Assert.Equal(1, this.colorConverterMock.ConvertCount);
            Assert.Equal(3, this.colorModelConverterMock.ConvertCount);
        }
    }
}
