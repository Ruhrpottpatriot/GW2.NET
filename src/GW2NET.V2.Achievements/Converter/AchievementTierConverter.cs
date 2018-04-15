// <copyright file="AchievementTierConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Converter
{
    using System;
    using Converters;
    using GW2NET.Achievements;

    public class AchievementTierConverter : IConverter<Tuple<int, int>, AchivementTier>
    {
        /// <inheritdoc />
        public AchivementTier Convert(Tuple<int, int> value, object state = null)
        {
            return new AchivementTier
            {
                Count = value.Item1,
                Points = value.Item2
            };
        }
    }
}
