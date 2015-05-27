// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CharacterDataContract" /> to objects of type <see cref="Character" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts.Characters
{
    using System;
    using GW2NET.Characters;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="CharacterDataContract"/> to objects of type <see cref="Character"/>.</summary>
    internal sealed class CharacterConverter : IConverter<CharacterDataContract, Character>
    {
        /// <summary>Infrastructure. Holds a reference to the gender converter.</summary>
        private readonly IConverter<string, Gender> genderConverter;

        /// <summary>Infrastructure. Holds a reference to the profession converter.</summary>
        private readonly IConverter<string, Profession> professionConverter;

        /// <summary>Infrastructure. Holds a reference to the race converter.</summary>
        private readonly IConverter<string, Race> raceConverter;

        /// <summary>Initializes a new instance of the <see cref="CharacterConverter"/> class.</summary>
        public CharacterConverter()
            : this(new GenderConverter(), new ProfesionConverter(), new RaceConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CharacterConverter"/> class.</summary>
        /// <param name="genderConverter">The gender converter.</param>
        /// <param name="professionConverter">The profession converter.</param>
        /// <param name="raceConverter">The race converter.</param>
        private CharacterConverter(IConverter<string, Gender> genderConverter, IConverter<string, Profession> professionConverter, IConverter<string, Race> raceConverter)
        {
            this.genderConverter = genderConverter;
            this.professionConverter = professionConverter;
            this.raceConverter = raceConverter;
        }

        /// <inheritdoc />
        public Character Convert(CharacterDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            Character character = new Character
            {
                Level = (short)value.Level,
                Name = value.Name,
                Gender = this.genderConverter.Convert(value.Gender, null),
                Profession = this.professionConverter.Convert(value.Profession, null),
                Race = this.raceConverter.Convert(value.Race, null)
            };

            if (!string.IsNullOrEmpty(value.Guild))
            {
                character.Guild = Guid.Parse(value.Guild);
            }

            return character;
        }
    }
}