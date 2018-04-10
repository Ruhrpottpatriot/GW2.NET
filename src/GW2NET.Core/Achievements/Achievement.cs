// <copyright file="Achievement.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Achievements
{
    using System;
    using System.Collections.Generic;
    using Items;

    public enum AchivementType
    {
        Default,
        ItemSet
    }

    [Flags]
    public enum AchivementFlags
    {
        Pvp = 0,
        CategoryDisplay = 1 << 0,
        MoveToTop = 1 << 1,
        IgnoreNearlyComplete = 1 << 2,
        Repeatable = 1 << 3,
        Hidden = 1 << 4,
        RequiresUnlock = 1 << 5,
        RepairOnLogin = 1 << 6,
        Daily = 1 << 7,
        Weekly = 1 << 8,
        Monthly = 1 << 9,
        Permanent = 1 << 10
    }

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

    public abstract class Bit
    {
    }

    public class TextBit
    {
        public string Text { get; set; }
    }

    public class MinipetBit
    {
        public Minipet Minipet { get; set; }

        public int Count { get; set; }
    }

    public class ItemBit
    {
        public Item Item { get; set; }

        public int Count { get; set; }
    }

    public abstract class AchievementReward
    {
    }

    public class AchievementCointReward
    {
        public int Count { get; set; }
    }

    public class AchievementItemReward
    {
        public Item Item { get; set; }

        public int Count { get; set; }
    }

    public class AchievementMasteryReward
    {
        public Mastery Mastery { get; set; }

        public MasteryRegion Region { get; set; }
    }

    public enum MasteryRegion
    {
        Tyria,
        Maguuma,
        Desert
    }

    public class Mastery
    {
        public int Id { get; set; }
    }

    public class AchievementTitleReward
    {
        public Title Title { get; set; }
    }

    public class Title
    {
        public int Id { get; set; }
    }

    public class AchivementTier
    {
        public int Count { get; set; }

        public int Points { get; set; }
    }
}
