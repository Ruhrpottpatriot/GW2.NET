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
    using System.Diagnostics.CodeAnalysis;
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
        internal ConverterForMatch()
            : this(new ConverterForScoreboard(), new ConverterForCompetitiveMap())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForMatch"/> class.</summary>
        /// <param name="converterForScoreboard">The scoreboard converter.</param>
        /// <param name="converterForCompetitiveMap">The competitive map data contract converter.</param>
        internal ConverterForMatch(IConverter<int[], Scoreboard> converterForScoreboard, IConverter<CompetitiveMapDataContract, CompetitiveMap> converterForCompetitiveMap)
        {
            Contract.Requires(converterForScoreboard != null);
            Contract.Requires(converterForCompetitiveMap != null);
            this.converterForScoreboard = converterForScoreboard;
            this.converterForCompetitiveMap = converterForCompetitiveMap;
        }

        /// <summary>Converts the given object of type <see cref="MatchDataContract"/> to an object of type <see cref="Match"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Match Convert(MatchDataContract value)
        {
            Contract.Assume(value != null);

            // Create a new match object
            var match = new Match { MatchId = value.MatchId };

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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForScoreboard != null);
            Contract.Invariant(this.converterForCompetitiveMap != null);
        }
    }
}