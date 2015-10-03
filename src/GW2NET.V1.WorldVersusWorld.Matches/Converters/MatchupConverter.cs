// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchupConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MatchupDTO" /> to objects of type <see cref="Matchup" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="MatchupDTO"/> to objects of type <see cref="Matchup"/>.</summary>
    public sealed class MatchupConverter : IConverter<MatchupDTO, Matchup>
    {
        /// <summary>Converts the given object of type <see cref="MatchupDTO"/> to an object of type <see cref="Matchup"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Matchup Convert(MatchupDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var matchup = new Matchup
            {
                MatchId = value.MatchId,
                RedWorldId = value.RedWorldId,
                BlueWorldId = value.BlueWorldId,
                GreenWorldId = value.GreenWorldId
            };

            DateTimeOffset startTime;
            if (DateTimeOffset.TryParse(value.StartTime, out startTime))
            {
                matchup.StartTime = startTime;
            }

            DateTimeOffset endTime;
            if (DateTimeOffset.TryParse(value.EndTime, out endTime))
            {
                matchup.EndTime = endTime;
            }

            return matchup;
        }
    }
}