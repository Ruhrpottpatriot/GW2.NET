// <copyright file="AchivementFlags.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Achievements
{
    using System;

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
}