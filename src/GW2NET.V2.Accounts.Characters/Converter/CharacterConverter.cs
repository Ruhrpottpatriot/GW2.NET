// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CharacterDTO" /> to objects of type <see cref="Character" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts.Characters.Converter
{
    using System;

    using GW2NET.Characters;
    using GW2NET.Common;
    using GW2NET.V2.Accounts.Characters.Json;

    /// <summary>Converts objects of type <see cref="CharacterDTO" /> to objects of type <see cref="Character" />.</summary>
    public sealed class CharacterConverter : IConverter<CharacterDTO, Character>
    {
        private readonly IConverter<string, Gender> genderConverter;

        private readonly IConverter<string, Profession> professionConverter;

        private readonly IConverter<string, Race> raceConverter;

        /// <summary>Initializes a new instance of the <see cref="CharacterConverter" /> class.</summary>
        /// <param name="genderConverter">The gender converter.</param>
        /// <param name="professionConverter">The profession converter.</param>
        /// <param name="raceConverter">The race converter.</param>
        public CharacterConverter(
            IConverter<string, Gender> genderConverter,
            IConverter<string, Profession> professionConverter,
            IConverter<string, Race> raceConverter)
        {
            if (genderConverter == null)
            {
                throw new ArgumentNullException("genderConverter");
            }

            if (professionConverter == null)
            {
                throw new ArgumentNullException("professionConverter");
            }

            if (raceConverter == null)
            {
                throw new ArgumentNullException("raceConverter");
            }

            this.genderConverter = genderConverter;
            this.professionConverter = professionConverter;
            this.raceConverter = raceConverter;
        }

        /// <inheritdoc />
        public Character Convert(CharacterDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var character = new Character
            {
                Level = (short)value.Level,
                Name = value.Name,
                Gender = this.genderConverter.Convert(value.Gender, value),
                Profession = this.professionConverter.Convert(value.Profession, value),
                Race = this.raceConverter.Convert(value.Race, value)
            };

            Guid guild;
            if (Guid.TryParse(value.Guild, out guild))
            {
                character.Guild = guild;
            }

            return character;
        }
    }
}