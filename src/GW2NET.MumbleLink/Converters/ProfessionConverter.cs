// <copyright file="ProfessionConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MumbleLink.Converters
{
    using GW2NET.Common;

    public class ProfessionConverter : IConverter<int, Profession>
    {
        public Profession Convert(int value, object state)
        {
            switch (value)
            {
                case 1:
                    return Profession.Guardian;
                case 2:
                    return Profession.Warrior;
                case 3:
                    return Profession.Engineer;
                case 4:
                    return Profession.Ranger;
                case 5:
                    return Profession.Thief;
                case 6:
                    return Profession.Elementalist;
                case 7:
                    return Profession.Mesmer;
                case 8:
                    return Profession.Necromancer;
                default:
                    return Profession.Unknown;
            }
        }
    }
}