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
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

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
        public SkillChallengeConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            this.vector2DConverter = vector2DConverter;
        }

        /// <summary>Converts the given object of type <see cref="SkillChallengeDataContract"/> to an object of type <see cref="SkillChallenge"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public SkillChallenge Convert(SkillChallengeDataContract value)
        {
            Contract.Assume(value != null);
            var skillChallenge = new SkillChallenge();
            // ReSharper disable once PossibleNullReferenceException
            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                skillChallenge.Coordinates = this.vector2DConverter.Convert(coordinates);
            }

            return skillChallenge;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when DataContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.vector2DConverter != null);
        }
    }
}