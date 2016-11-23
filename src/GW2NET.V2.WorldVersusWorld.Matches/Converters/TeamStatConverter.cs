// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScoreboardConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:int[]" /> to objects of type <see cref="Scoreboard" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Matches.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.WorldVersusWorld;
    using GW2NET.V2.WorldVersusWorld.Matches.Json;

    /// <summary>Converts objects of type <see cref="T:int[]"/> to objects of type <see cref="Scoreboard"/>.</summary>
    public sealed class TeamStatConverter : IConverter<TeamStatDTO, Scoreboard>
    {
        /// <summary>Converts the given object of type <see cref="T:int[]"/> to an object of type <see cref="Scoreboard"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Scoreboard Convert(TeamStatDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new Scoreboard
            {
                Red = value.Red,
                Blue = value.Blue,
                Green = value.Green
            };
        }
    }
}