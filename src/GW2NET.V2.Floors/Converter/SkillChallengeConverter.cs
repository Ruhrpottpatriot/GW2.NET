// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallengeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkillChallengeDataContract" /> to objects of type <see cref="SkillChallenge" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="SkillChallengeDataContract"/> to objects of type <see cref="SkillChallenge"/>.</summary>
    internal sealed class SkillChallengeConverter : IConverter<SkillChallengeDataContract, SkillChallenge>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="SkillChallengeConverter"/> class.</summary>
        public SkillChallengeConverter()
            : this(new Vector2DConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkillChallengeConverter"/> class.</summary>
        /// <param name="vector2DConverter">The converter for <see cref="SkillChallengeConverter"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="vector2DConverter"/> is a null reference.</exception>
        public SkillChallengeConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter", "Precondition: vector2DConverter != null");
            }

            this.vector2DConverter = vector2DConverter;
        }

        /// <inheritdoc />
        public SkillChallenge Convert(SkillChallengeDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var skillChallenge = new SkillChallenge();
            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                skillChallenge.Coordinates = this.vector2DConverter.Convert(coordinates);
            }

            return skillChallenge;
        }
    }
}