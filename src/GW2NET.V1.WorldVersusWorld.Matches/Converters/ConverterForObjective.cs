// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForObjective.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ObjectiveDataContract" /> to objects of type <see cref="Objective" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using GW2NET.Common;
using GW2NET.V1.WorldVersusWorld.Matches.Json;
using GW2NET.WorldVersusWorld;

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
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
            if (converterForTeamColor == null)
            {
                throw new ArgumentNullException("converterForTeamColor", "Precondition: converterForTeamColor != null");
            }

            this.converterForTeamColor = converterForTeamColor;
        }

        /// <summary>Converts the given object of type <see cref="ObjectiveDataContract"/> to an object of type <see cref="Objective"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Objective Convert(ObjectiveDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            // Create a new objective object
            var objective = new Objective
            {
                ObjectiveId = value.Id
            };

            // Set the status
            var owner = value.Owner;
            if (owner != null)
            {
                objective.Owner = this.converterForTeamColor.Convert(owner);
            }

            // Set the guild identifier of the guild that claimed the objective
            var ownerGuild = value.OwnerGuild;
            if (ownerGuild != null)
            {
                objective.OwnerGuildId = Guid.Parse(ownerGuild);
            }

            // Return the objective object
            return objective;
        }
    }
}
