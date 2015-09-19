// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallengeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkillChallengeDTO" /> to objects of type <see cref="SkillChallenge" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="SkillChallengeDTO"/> to objects of type <see cref="SkillChallenge"/>.</summary>
    public sealed class SkillChallengeConverter : IConverter<SkillChallengeDTO, SkillChallenge>
    {
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="SkillChallengeConverter"/> class.</summary>
        /// <param name="vector2DConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public SkillChallengeConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter");
            }

            this.vector2DConverter = vector2DConverter;
        }

        /// <inheritdoc />
        public SkillChallenge Convert(SkillChallengeDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var skillChallenge = new SkillChallenge();
            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                skillChallenge.Coordinates = this.vector2DConverter.Convert(coordinates, value);
            }

            return skillChallenge;
        }
    }
}