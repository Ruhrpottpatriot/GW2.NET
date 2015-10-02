// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamColorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="TeamColor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;
    using GW2NET.Common;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="TeamColor"/>.</summary>
    public sealed class TeamColorConverter : IConverter<string, TeamColor>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="TeamColor"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public TeamColor Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            TeamColor teamColor;
            if (!Enum.TryParse(value, true, out teamColor))
            {
                return TeamColor.Unknown;
            }

            return teamColor;
        }
    }
}