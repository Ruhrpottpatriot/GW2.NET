// <copyright file="IdentityConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MumbleLink.Converters
{
    using System;

    using GW2NET.Common;

    public sealed class IdentityConverter : IConverter<IdentityDTO, Identity>
    {
        private readonly IConverter<int, Profession> professionConverter;

        private readonly IConverter<int, Race> raceConverter;

        public IdentityConverter(IConverter<int, Profession> professionConverter, IConverter<int, Race> raceConverter)
        {
            if (professionConverter == null)
            {
                throw new ArgumentNullException("professionConverter");
            }

            if (raceConverter == null)
            {
                throw new ArgumentNullException("raceConverter");
            }

            this.professionConverter = professionConverter;
            this.raceConverter = raceConverter;
        }

        public Identity Convert(IdentityDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new Identity
            {
                Name = value.Name,
                Profession = this.professionConverter.Convert(value.Profession, value),
                Race = this.raceConverter.Convert(value.Race, value),
                MapId = value.MapId,
                WorldId = value.WorldId,
                TeamColorId = value.TeamColorId,
                Commander = value.Commander,
                FieldOfView = value.FieldOfView
            };
        }
    }
}