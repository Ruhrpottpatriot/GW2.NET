// <copyright file="ColorConverterTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Colors.Converters
{
    using Xunit;

    public class ColorConverterTests
    {
        private readonly ColorConverter converter = new ColorConverter();

        [Theory]
        [InlineData(128, 26, 26)]
        [InlineData(124, 108, 83)]
        [InlineData(65, 49, 29)]
        [InlineData(96, 91, 83)]
        public void CanConvert(int red, int green, int blue)
        {
            var value = new[] { red, green, blue };
            var result = this.converter.Convert(value, null);
            Assert.NotNull(result);
            Assert.Equal(red, result.R);
            Assert.Equal(green, result.G);
            Assert.Equal(blue, result.B);
        }
    }
}
