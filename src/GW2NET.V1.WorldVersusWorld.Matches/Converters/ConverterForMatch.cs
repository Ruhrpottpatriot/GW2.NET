// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMatch.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MatchDataContract" /> to objects of type <see cref="Match" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GW2NET.Common;
using GW2NET.V1.WorldVersusWorld.Matches.Json;
using GW2NET.WorldVersusWorld;

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="MatchDataContract"/> to objects of type <see cref="Match"/>.</summary>
    internal sealed class ConverterForMatch : IConverter<MatchDataContract, Match>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<CompetitiveMapDataContract, CompetitiveMap> converterForCompetitiveMap;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<int[], Scoreboard> converterForScoreboard;

        /// <summary>Initializes a new instance of the <see cref="ConverterForMatch"/> class.</summary>
        internal ConverterForMatch()
            : this(new ConverterForScoreboard(), new ConverterForCompetitiveMap())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForMatch"/> class.</summary>
        /// <param name="converterForScoreboard">The scoreboard converter.</param>
        /// <param name="converterForCompetitiveMap">The competitive map data contract converter.</param>
        internal ConverterForMatch(IConverter<int[], Scoreboard> converterForScoreboard, IConverter<CompetitiveMapDataContract, CompetitiveMap> converterForCompetitiveMap)
        {
            if (converterForScoreboard == null)
            {
                throw new ArgumentNullException("converterForScoreboard", "Precondition: converterForScoreboard != null");
            }

            if (converterForCompetitiveMap == null)
            {
                throw new ArgumentNullException("converterForCompetitiveMap", "Precondition: converterForCompetitiveMap != null");
            }

            this.converterForScoreboard = converterForScoreboard;
            this.converterForCompetitiveMap = converterForCompetitiveMap;
        }

        /// <summary>Converts the given object of type <see cref="MatchDataContract"/> to an object of type <see cref="Match"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Match Convert(MatchDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            // Create a new match object
            var match = new Match
            {
                MatchId = value.MatchId
            };

            // Set the match identfieier

            // Set the scoreboard
            var scores = value.Scores;
            if (scores != null && scores.Length == 3)
            {
                match.Scores = this.converterForScoreboard.Convert(scores);
            }

            //// Set a collection of maps and their status
            var mapDataContracts = value.Maps;
            if (mapDataContracts != null)
            {
                var values = new List<CompetitiveMap>(mapDataContracts.Count);
                values.AddRange(mapDataContracts.Select(this.converterForCompetitiveMap.Convert).Where(o => o != null));
                match.Maps = values;
            }

            // Return the match object
            return match;
        }
    }
}