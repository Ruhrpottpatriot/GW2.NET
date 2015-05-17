// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSkillChallenge.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkillChallengeDataContract" /> to objects of type <see cref="SkillChallenge" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="SkillChallengeDataContract"/> to objects of type <see cref="SkillChallenge"/>.</summary>
    internal sealed class ConverterForSkillChallenge : IConverter<SkillChallengeDataContract, SkillChallenge>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForSkillChallenge"/> class.</summary>
        public ConverterForSkillChallenge()
            : this(new ConverterForVector2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForSkillChallenge"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForVector2D"/> is a null reference.</exception>
        public ConverterForSkillChallenge(IConverter<double[], Vector2D> converterForVector2D)
        {
            if (converterForVector2D == null)
            {
                throw new ArgumentNullException("converterForVector2D", "Precondition: converterForVector2D != null");
            }

            this.converterForVector2D = converterForVector2D;
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
                skillChallenge.Coordinates = this.converterForVector2D.Convert(coordinates);
            }

            return skillChallenge;
        }
    }
}