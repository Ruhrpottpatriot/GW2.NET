// <copyright file="RaceConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MumbleLink.Converters
{
    using GW2NET.Common;

    public sealed class RaceConverter : IConverter<int, Race>
    {
        public Race Convert(int value, object state)
        {
            switch (value)
            {
                case 0:
                    return Race.Asura;
                case 1:
                    return Race.Charr;
                case 2:
                    return Race.Human;
                case 3:
                    return Race.Norn;
                case 4:
                    return Race.Sylvari;
                default:
                    return Race.Unknown;
            }
        }
    }
}