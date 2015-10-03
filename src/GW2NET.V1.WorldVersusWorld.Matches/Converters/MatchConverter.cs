// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MatchDTO" /> to objects of type <see cref="Match" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="MatchDTO"/> to objects of type <see cref="Match"/>.</summary>
    public sealed class MatchConverter : IConverter<MatchDTO, Match>
    {
        private readonly IConverter<CompetitiveMapDTO, CompetitiveMap> competitiveMapConverter;

        private readonly IConverter<int[], Scoreboard> scoreboardConverter;

        /// <summary>Initializes a new instance of the <see cref="MatchConverter"/> class.</summary>
        /// <param name="scoreboardConverter">The scoreboard converter.</param>
        /// <param name="competitiveMapConverter">The competitive map data contract converter.</param>
        public MatchConverter(IConverter<int[], Scoreboard> scoreboardConverter, IConverter<CompetitiveMapDTO, CompetitiveMap> competitiveMapConverter)
        {
            if (scoreboardConverter == null)
            {
                throw new ArgumentNullException("scoreboardConverter");
            }

            if (competitiveMapConverter == null)
            {
                throw new ArgumentNullException("competitiveMapConverter");
            }

            this.scoreboardConverter = scoreboardConverter;
            this.competitiveMapConverter = competitiveMapConverter;
        }

        /// <summary>Converts the given object of type <see cref="MatchDTO"/> to an object of type <see cref="Match"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Match Convert(MatchDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var match = new Match
            {
                MatchId = value.MatchId
            };

            var scores = value.Scores;
            if (scores != null && scores.Length == 3)
            {
                match.Scores = this.scoreboardConverter.Convert(scores, value);
            }

            var maps = value.Maps;
            if (maps != null)
            {
                var values = new List<CompetitiveMap>(maps.Count);
                values.AddRange(maps.Select(map => this.competitiveMapConverter.Convert(map, value)));
                match.Maps = values;
            }

            return match;
        }
    }
}