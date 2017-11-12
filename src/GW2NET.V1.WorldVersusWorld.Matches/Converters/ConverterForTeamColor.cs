﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTeamColor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="TeamColor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2NET.Common;
using GW2NET.WorldVersusWorld;

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System.Diagnostics;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="TeamColor"/>.</summary>
    internal sealed class ConverterForTeamColor : IConverter<string, TeamColor>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="TeamColor"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public TeamColor Convert(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            TeamColor teamColor;
            if (Enum.TryParse(value, true, out teamColor))
            {
                return teamColor;
            }

            Debug.Assert(false, "Unknown TeamColor: " + value);
            return TeamColor.Unknown;
        }
    }
}