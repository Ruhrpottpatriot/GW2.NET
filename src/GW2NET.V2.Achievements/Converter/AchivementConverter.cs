// <copyright file="AchivementConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Converters;
    using GW2NET.Achievements;

    public class AchivementConverter : IConverter<Types.Achievement, Achievement>
    {
        public IConverter<Tuple<string, int, string>, AchievementBit> BitConverter { get; set; }

        public IConverter<string, AchivementType> TypeConverter { get; set; }

        public IConverter<Tuple<int, int>, AchivementTier> TierConverter { get; set; }

        public IConverter<IEnumerable<string>, AchivementFlags> FlagConverter { get; set; }

        public IConverter<Tuple<string, int?, int?, string>, AchievementReward> RewardConverter { get; set; }

        /// <inheritdoc />
        public Achievement Convert(Types.Achievement value, object state = null)
        {
            var achievement = new Achievement
            {
                Id = value.Id,
                Type = this.TypeConverter.Convert(value.Type),
                PrerequisiteIds = value.Prerequisites,
                Bits = value.Bits.Select(b => this.BitConverter.Convert(b)),
                Description = value.Description,
                Flags = this.FlagConverter.Convert(value.Flags),
                LockedText = value.LockedText,
                Name = value.Name,
                PointCap = value.PointCap,
                Requirement = value.Requirement,
                Rewards = value.Rewards.Select(r => this.RewardConverter.Convert(r)),
                Tiers = value.Tiers.Select(t => this.TierConverter.Convert(t))
            };

            return achievement;
        }
    }
}
