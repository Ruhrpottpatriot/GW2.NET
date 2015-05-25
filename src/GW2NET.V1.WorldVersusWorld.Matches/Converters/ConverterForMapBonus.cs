// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMapBonus.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MapBonusDataContract" /> to objects of type <see cref="MapBonus" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using GW2NET.Common;
using GW2NET.V1.WorldVersusWorld.Matches.Json;
using GW2NET.WorldVersusWorld;

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    /// <summary>Converts objects of type <see cref="MapBonusDataContract"/> to objects of type <see cref="MapBonus"/>.</summary>
    internal sealed class ConverterForMapBonus : IConverter<MapBonusDataContract, MapBonus>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, TeamColor> converterForTeamColor;

        /// <summary>Initializes a new instance of the <see cref="ConverterForMapBonus"/> class.</summary>
        public ConverterForMapBonus()
            : this(new ConverterForTeamColor())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForMapBonus"/> class.</summary>
        /// <param name="converterForTeamColor">The converter for <see cref="TeamColor"/>.</param>
        public ConverterForMapBonus(IConverter<string, TeamColor> converterForTeamColor)
        {
            if (converterForTeamColor == null)
            {
                throw new ArgumentNullException("converterForTeamColor", "Precondition: converterForTeamColor != null");
            }

            this.converterForTeamColor = converterForTeamColor;
        }

        /// <summary>Converts the given object of type <see cref="MapBonusDataContract"/> to an object of type <see cref="MapBonus"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public MapBonus Convert(MapBonusDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            MapBonus mapBonus;
            if (string.Equals(value.Type, "bloodlust", StringComparison.OrdinalIgnoreCase))
            {
                mapBonus = new Bloodlust();
            }
            else
            {
                mapBonus = new UnknownMapBonus();
            }

            var owner = value.Owner;
            if (owner != null)
            {
                mapBonus.Owner = this.converterForTeamColor.Convert(owner, state);
            }

            return mapBonus;
        }
    }
}