// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMatch.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MatchDataContract" /> to objects of type <see cref="Match" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches.Json.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using GW2NET.Common;
    using GW2NET.Entities.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="MatchDataContract"/> to objects of type <see cref="Match"/>.</summary>
    internal sealed class ConverterForMatch : IConverter<MatchDataContract, Match>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<int[], Scoreboard> converterForScoreboard;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<CompetitiveMapDataContract, CompetitiveMap> converterForCompetitiveMap;

        /// <summary>Initializes a new instance of the <see cref="ConverterForMatch"/> class.</summary>
        public ConverterForMatch()
            : this(new ConverterForScoreboard(), new ConverterForCompetitiveMap())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForMatch"/> class.</summary>
        /// <param name="converterForScoreboard">The scoreboard converter.</param>
        /// <param name="converterForCompetitiveMap">The competitive map data contract converter.</param>
        public ConverterForMatch(IConverter<int[], Scoreboard> converterForScoreboard, IConverter<CompetitiveMapDataContract, CompetitiveMap> converterForCompetitiveMap)
        {
            this.converterForScoreboard = converterForScoreboard;
            this.converterForCompetitiveMap = converterForCompetitiveMap;
        }

        /// <summary>Converts the given object of type <see cref="MatchDataContract"/> to an object of type <see cref="Match"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Match Convert(MatchDataContract value)
        {
            Contract.Requires(value != null);

            // Create a new match object
            var match = new Match();

            // Set the match identfieier
            if (value.MatchId != null)
            {
                match.MatchId = value.MatchId;
            }

            // Set the scoreboard
            if (value.Scores != null && value.Scores.Length == 3)
            {
                match.Scores = this.converterForScoreboard.Convert(value.Scores);
            }

            //// Set a collection of maps and their status
            if (value.Maps != null)
            {
                var values = new List<CompetitiveMap>(value.Maps.Count);
                values.AddRange(value.Maps.Select(this.converterForCompetitiveMap.Convert));
                match.Maps = values;
            }

            // Return the match object
            return match;
        }
    }
}