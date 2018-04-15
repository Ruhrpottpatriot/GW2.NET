// <copyright file="AchivementRewardConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Converter
{
    using System;
    using Converters;
    using GW2NET.Achievements;

    public class AchivementRewardConverter : IConverter<Tuple<string, int?, int?, string>, AchievementReward>
    {
        public IConverter<string, Region> RegionConverter { get; set; }

        /// <inheritdoc />
        public AchievementReward Convert(Tuple<string, int?, int?, string> value, object state = null)
        {
            switch (value.Item1.ToLower())
            {
                case "coin":
                    return new AchievementCointReward { Count = value.Item2 ?? -1 };
                case "item":
                    return new AchievementItemReward { Count = value.Item2 ?? -1, ItemId = value.Item3 ?? -1 };
                case "mastery":
                    return new AchievementMasteryReward
                    {
                        MasteryId = value.Item2 ?? -1,
                        Region = this.RegionConverter.Convert(value.Item4)
                    };
                case "title":
                default:
                    throw new ArgumentException("The achivement reward type is invalid");
            }
        }
    }
}
