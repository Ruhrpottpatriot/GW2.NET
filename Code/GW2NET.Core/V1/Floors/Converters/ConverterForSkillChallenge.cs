// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSkillChallenge.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkillChallengeDataContract" /> to objects of type <see cref="SkillChallenge" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors.Converters
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Json;

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
        public ConverterForSkillChallenge(IConverter<double[], Vector2D> converterForVector2D)
        {
            this.converterForVector2D = converterForVector2D;
        }

        /// <summary>Converts the given object of type <see cref="SkillChallengeDataContract"/> to an object of type <see cref="SkillChallenge"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public SkillChallenge Convert(SkillChallengeDataContract value)
        {
            Contract.Assume(value != null);
            var skillChallenge = new SkillChallenge();
            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                skillChallenge.Coordinates = this.converterForVector2D.Convert(coordinates);
            }

            return skillChallenge;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForVector2D != null);
        }
    }
}