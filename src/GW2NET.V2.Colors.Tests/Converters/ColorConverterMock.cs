// <copyright file="ColorConverterMock.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Colors.Converters
{
    using GW2NET.Colors;
    using GW2NET.Common;

    public class ColorConverterMock : IConverter<int[], Color>
    {
        public int ConvertCount { get; set; }

        public Color Convert(int[] value, object state)
        {
            this.ConvertCount += 1;
            return default(Color);
        }
    }
}
