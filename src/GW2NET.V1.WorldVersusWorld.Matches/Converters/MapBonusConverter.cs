// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonusConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MapBonusDTO" /> to objects of type <see cref="MapBonus" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    public partial class MapBonusConverter
    {
        private readonly IConverter<string, TeamColor> teamColorConverter;

        /// <summary>Initializes a new instance of the <see cref="MapBonusConverter" /> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="teamColorConverter">The converter for <see cref="TeamColor" />.</param>
        public MapBonusConverter(
            ITypeConverterFactory<MapBonusDTO, MapBonus> converterFactory,
            IConverter<string, TeamColor> teamColorConverter)
            : this(converterFactory)
        {
            if (teamColorConverter == null)
            {
                throw new ArgumentNullException("teamColorConverter");
            }

            this.teamColorConverter = teamColorConverter;
        }

        partial void Merge(MapBonus entity, MapBonusDTO dto, object state)
        {
            var owner = dto.Owner;
            if (owner != null)
            {
                entity.Owner = this.teamColorConverter.Convert(owner, dto);
            }
        }
    }
}