// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBlueBorderlands.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CompetitiveMapDataContract" /> to objects of type <see cref="BlueBorderlands" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="CompetitiveMapDataContract"/> to objects of type <see cref="BlueBorderlands"/>.</summary>
    internal sealed class ConverterForBlueBorderlands : IConverter<CompetitiveMapDataContract, BlueBorderlands>
    {
        /// <summary>Converts the given object of type <see cref="CompetitiveMapDataContract"/> to an object of type <see cref="BlueBorderlands"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public BlueBorderlands Convert(CompetitiveMapDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Type != "BlueHome")
            {
                throw new ArgumentException("Precondition: value.Type == \"BlueHome\"", "value");
            }

            return new BlueBorderlands();
        }
    }
}
