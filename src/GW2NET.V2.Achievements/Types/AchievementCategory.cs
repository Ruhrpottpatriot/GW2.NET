// <copyright file="AchievementCategory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Types
{
    using System.Collections.Generic;

    public class AchievementCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public string Icon { get; set; }

        public IEnumerable<int> Achievements { get; set; }
    }
}
