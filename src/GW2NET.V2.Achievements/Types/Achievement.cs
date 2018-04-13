// <copyright file="Achievement.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Types
{
    using System;
    using System.Collections.Generic;

    public class Achievement
    {
        public int Id { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Requirement { get; set; }

        public string LockedText { get; set; }

        public string Type { get; set; }

        public IEnumerable<string> Flags { get; set; }

        public IEnumerable<Tuple<int, int>> Tiers { get; set; }

        public IEnumerable<int> Prerequisites { get; set; }

        public IEnumerable<Tuple<string, int?, int?, string>> Rewards { get; set; }

        public IEnumerable<Tuple<string, int, string>> Bits { get; set; }

        public int PointCap { get; set; }
    }
}
