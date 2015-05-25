// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGreenBorderlands.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CompetitiveMapDataContract" /> to objects of type <see cref="GreenBorderlands" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="CompetitiveMapDataContract"/> to objects of type <see cref="GreenBorderlands"/>.</summary>
    internal sealed class ConverterForGreenBorderlands : IConverter<CompetitiveMapDataContract, GreenBorderlands>
    {
        /// <summary>Converts the given object of type <see cref="CompetitiveMapDataContract"/> to an object of type <see cref="GreenBorderlands"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public GreenBorderlands Convert(CompetitiveMapDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Type != "GreenHome")
            {
                throw new ArgumentException("Precondition: value.Type == \"GreenHome\"", "value");
            }

            return new GreenBorderlands();
        }
    }
}