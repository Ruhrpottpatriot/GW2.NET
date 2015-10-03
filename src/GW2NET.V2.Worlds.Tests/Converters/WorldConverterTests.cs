// <copyright file="WorldConverterTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Worlds.Converters
{
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.V2.Worlds.Json;

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
            var value = new WorldDTO
            {
                Id = id,
                Name = name
            };

            var state = new Response<WorldDTO>
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
