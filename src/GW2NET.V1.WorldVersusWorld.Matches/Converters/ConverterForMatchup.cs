// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMatchup.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MatchupDataContract" /> to objects of type <see cref="Matchup" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="MatchupDataContract"/> to objects of type <see cref="Matchup"/>.</summary>
    internal sealed class ConverterForMatchup : IConverter<MatchupDataContract, Matchup>
    {
        /// <summary>Converts the given object of type <see cref="MatchupDataContract"/> to an object of type <see cref="Matchup"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Matchup Convert(MatchupDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            // Create a new matchup object
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

            // Return the matchup object
            return matchup;
        }
    }
}