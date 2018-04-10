// <copyright file="DailyAchievement.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Types
{
    using System;
    using System.Collections.Generic;

    public class DailyAchievement
    {
        public IEnumerable<Tuple<int, Tuple<int, int>,string[]>> Pve { get; set; }

        public IEnumerable<Tuple<int, Tuple<int, int>, string[]>> Pvp { get; set; }

        public IEnumerable<Tuple<int, Tuple<int, int>, string[]>> Wvw { get; set; }

        public IEnumerable<Tuple<int, Tuple<int, int>, string[]>> Fractals { get; set; }

        public IEnumerable<Tuple<int, Tuple<int, int>, string[]>> Special { get; set; }
    }
}
