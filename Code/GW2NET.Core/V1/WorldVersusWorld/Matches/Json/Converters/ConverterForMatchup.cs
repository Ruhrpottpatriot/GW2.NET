// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMatchup.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MatchupDataContract" /> to objects of type <see cref="Matchup" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches.Json.Converters
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="MatchupDataContract"/> to objects of type <see cref="Matchup"/>.</summary>
    internal sealed class ConverterForMatchup : IConverter<MatchupDataContract, Matchup>
    {
        /// <summary>Converts the given object of type <see cref="MatchupDataContract"/> to an object of type <see cref="Matchup"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Matchup Convert(MatchupDataContract value)
        {
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<Matchup>() != null);

            // Create a new matchup object
            var matchup = new Matchup();

            // Set the match identifier
            if (value.MatchId != null)
            {
                matchup.MatchId = value.MatchId;
            }

            // Set the red world identifier
            matchup.RedWorldId = value.RedWorldId;

            // Set the blue world identifier
            matchup.BlueWorldId = value.BlueWorldId;

            // Set the green world identifier
            matchup.GreenWorldId = value.GreenWorldId;

            // Set the start time
            if (value.StartTime != null)
            {
                matchup.StartTime = DateTimeOffset.Parse(value.StartTime);
            }

            // Set the end time
            if (value.EndTime != null)
            {
                matchup.EndTime = DateTimeOffset.Parse(value.EndTime);
            }

            // Return the matchup object
            return matchup;
        }
    }
}