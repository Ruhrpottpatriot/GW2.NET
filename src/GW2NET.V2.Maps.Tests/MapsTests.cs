// <copyright file="MapTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Maps.Tests
{
    using Xunit;

    public class MapsTests
    {
        private static readonly GW2Bootstrapper GW2 = new GW2Bootstrapper();

        [Theory]
        [InlineData(95)]
        public void ConversionIncludesTypeName(int id)
        {
            var repository = GW2.V2.Maps.ForDefaultCulture();
            var map = repository.Find(id);
            Assert.Equal(map.MapId, 95);
            Assert.Equal(map.MapName, " Alpine Borderlands");
            Assert.Equal(map.TypeName, "GreenHome");
            Assert.Equal(map.RegionName, "World vs. World");
        }
    }
}