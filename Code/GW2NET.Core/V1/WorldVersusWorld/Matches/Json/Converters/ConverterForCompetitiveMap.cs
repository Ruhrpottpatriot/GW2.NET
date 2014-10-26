// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCompetitiveMap.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CompetitiveMapDataContract" /> to objects of type <see cref="CompetitiveMap" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches.Json.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using GW2NET.Common;
    using GW2NET.Entities.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="CompetitiveMapDataContract"/> to objects of type <see cref="CompetitiveMap"/>.</summary>
    internal sealed class ConverterForCompetitiveMap : IConverter<CompetitiveMapDataContract, CompetitiveMap>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<MapBonusDataContract, MapBonus> converterForMapBonus;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ObjectiveDataContract, Objective> converterForObjective;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<int[], Scoreboard> converterForScoreboard;

        /// <summary>Initializes a new instance of the <see cref="ConverterForCompetitiveMap"/> class.</summary>
        public ConverterForCompetitiveMap()
            : this(new ConverterForScoreboard(), new ConverterForObjective(), new ConverterForMapBonus())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForCompetitiveMap"/> class.</summary>
        /// <param name="converterForScoreboard">The converter for <see cref="Scoreboard"/>.</param>
        /// <param name="converterForObjective">The converter for <see cref="Objective"/>.</param>
        /// <param name="converterForMapBonus">The converter for <see cref="MapBonus"/>.</param>
        public ConverterForCompetitiveMap(IConverter<int[], Scoreboard> converterForScoreboard, IConverter<ObjectiveDataContract, Objective> converterForObjective, IConverter<MapBonusDataContract, MapBonus> converterForMapBonus)
        {
            this.converterForScoreboard = converterForScoreboard;
            this.converterForObjective = converterForObjective;
            this.converterForMapBonus = converterForMapBonus;
        }

        /// <summary>Converts the given object of type <see cref="CompetitiveMapDataContract"/> to an object of type <see cref="CompetitiveMap"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CompetitiveMap Convert(CompetitiveMapDataContract value)
        {
            Contract.Requires(value != null);

            // Create a new map object
            CompetitiveMap competitiveMap;
            switch (value.Type)
            {
                case "RedHome":
                    competitiveMap = new RedBorderlands();
                    break;
                case "GreenHome":
                    competitiveMap = new GreenBorderlands();
                    break;
                case "BlueHome":
                    competitiveMap = new BlueBorderlands();
                    break;
                case "Center":
                    competitiveMap = new EternalBattlegrounds();
                    break;
                default:
                    throw new NotSupportedException(string.Format("Map type '{0}' is not supported.", value.Type));
            }

            // Set the scoreboard
            if (value.Scores != null && value.Scores.Length == 3)
            {
                competitiveMap.Scores = this.converterForScoreboard.Convert(value.Scores);
            }

            // Set the status of each objective
            if (value.Objectives != null)
            {
                var objectives = new List<Objective>(value.Objectives.Count);
                objectives.AddRange(value.Objectives.Select(this.converterForObjective.Convert));
                competitiveMap.Objectives = objectives;
            }

            // Set the status of each map bonus
            if (value.Bonuses != null)
            {
                var bonuses = new List<MapBonus>(value.Bonuses.Count);
                bonuses.AddRange(value.Bonuses.Select(this.converterForMapBonus.Convert));
                competitiveMap.Bonuses = bonuses;
            }

            // Return the map object
            return competitiveMap;
        }
    }
}