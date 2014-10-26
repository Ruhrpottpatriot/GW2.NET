// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForObjective.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ObjectiveDataContract" /> to objects of type <see cref="Objective" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches.Json.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Entities.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="ObjectiveDataContract"/> to objects of type <see cref="Objective"/>.</summary>
    internal sealed class ConverterForObjective : IConverter<ObjectiveDataContract, Objective>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, TeamColor> converterForTeamColor;

        /// <summary>Initializes a new instance of the <see cref="ConverterForObjective"/> class.</summary>
        public ConverterForObjective()
            : this(new ConverterForTeamColor())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForObjective"/> class.</summary>
        /// <param name="converterForTeamColor">The converter for <see cref="TeamColor"/>.</param>
        public ConverterForObjective(IConverter<string, TeamColor> converterForTeamColor)
        {
            this.converterForTeamColor = converterForTeamColor;
        }

        /// <summary>Converts the given object of type <see cref="ObjectiveDataContract"/> to an object of type <see cref="Objective"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Objective Convert(ObjectiveDataContract value)
        {
            // Create a new objective object
            var objective = new Objective();

            // Set the objective identifier
            objective.ObjectiveId = value.Id;

            // Set the status
            if (value.Owner != null)
            {
                objective.Owner = this.converterForTeamColor.Convert(value.Owner);
            }

            // Set the guild identifier of the guild that claimed the objective
            if (value.OwnerGuild != null)
            {
                objective.OwnerGuildId = Guid.Parse(value.OwnerGuild);
            }

            // Return the objective object
            return objective;
        }
    }
}