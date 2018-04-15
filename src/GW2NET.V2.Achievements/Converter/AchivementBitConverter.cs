// <copyright file="AchivementBitConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Converter
{
    using System;
    using Converters;
    using GW2NET.Achievements;
    using GW2NET.Types.Achievements;

    class AchivementBitConverter : IConverter<Tuple<string, int, string>, AchievementBit>
    {
        /// <inheritdoc />
        public AchievementBit Convert(Tuple<string, int, string> value, object state = null)
        {
            switch (value.Item1.ToLower())
            {
                case "text":
                    return new TextBit { Text = value.Item3 };
                case "item":
                    return new ItemBit { ItemId = value.Item2 };
                case "minipet":
                    return new MinipetBit { MinipetId = value.Item2 };
                case "skin":
                    return new SkinBit { SkinId = value.Item2 };
                default:
                    throw new ArgumentException("The passed bit type is invalid");
            }
        }
    }
}
