// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ObjectiveDTO" /> to objects of type <see cref="Objective" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;
    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="ObjectiveDTO"/> to objects of type <see cref="MatchObjective"/>.</summary>
    public sealed class ObjectiveConverter : IConverter<ObjectiveDTO, MatchObjective>
    {
        private readonly IConverter<string, TeamColor> teamColorConverter;

        /// <summary>Initializes a new instance of the <see cref="ObjectiveConverter"/> class.</summary>
        /// <param name="teamColorConverter">The converter for <see cref="TeamColor"/>.</param>
        public ObjectiveConverter(IConverter<string, TeamColor> teamColorConverter)
        {
            if (teamColorConverter == null)
            {
                throw new ArgumentNullException("teamColorConverter");
            }

            this.teamColorConverter = teamColorConverter;
        }

        /// <summary>Converts the given object of type <see cref="ObjectiveDTO"/> to an object of type <see cref="MatchObjective"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public MatchObjective Convert(ObjectiveDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var objective = new MatchObjective
            {
                ObjectiveId = value.Id.ToString()
            };

            var owner = value.Owner;
            if (owner != null)
            {
                objective.Owner = this.teamColorConverter.Convert(owner, value);
            }

            var ownerGuild = value.OwnerGuild;
            if (ownerGuild != null)
            {
                objective.OwnerGuildId = Guid.Parse(ownerGuild);
            }

            return objective;
        }
    }
}