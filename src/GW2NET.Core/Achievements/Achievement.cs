// <copyright file="Achievement.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Achievements
{
    using System.Collections.Generic;

    public class Achievement
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Requirement { get; set; }

        public string LockedText { get; set; }

        public AchivementType Type { get; set; }

        public AchivementFlags Flags { get; set; }

        public IEnumerable<AchivementTier> Tiers { get; set; }

        public IEnumerable<Achievement> Prerequisites { get; set; }

        public IEnumerable<AchievementReward> Rewards { get; set; }

        public IEnumerable<Bit> Bits { get; set; }

        public int PointCap { get; set; }
    }
}
