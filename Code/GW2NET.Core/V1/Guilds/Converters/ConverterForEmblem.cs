// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForEmblem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EmblemDataContract" /> to objects of type <see cref="Emblem" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Guilds;
    using GW2NET.V1.Guilds.Json;

    /// <summary>Converts objects of type <see cref="EmblemDataContract"/> to objects of type <see cref="Emblem"/>.</summary>
    internal sealed class ConverterForEmblem : IConverter<EmblemDataContract, Emblem>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, EmblemTransformations> converterForEmblemTransformations;

        /// <summary>Initializes a new instance of the <see cref="ConverterForEmblem"/> class.</summary>
        public ConverterForEmblem()
            : this(new ConverterForEmblemTransformations())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForEmblem"/> class.</summary>
        /// <param name="converterForEmblemTransformations">The converter For Emblem Transformations.</param>
        internal ConverterForEmblem(IConverter<ICollection<string>, EmblemTransformations> converterForEmblemTransformations)
        {
            Contract.Requires(converterForEmblemTransformations != null);
            this.converterForEmblemTransformations = converterForEmblemTransformations;
        }

        /// <summary>Converts the given object of type <see cref="EmblemDataContract"/> to an object of type <see cref="Emblem"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Emblem Convert(EmblemDataContract value)
        {
            Contract.Assume(value != null);
            var emblem = new Emblem
            {
                BackgroundId = value.BackgroundId, 
                ForegroundId = value.ForegroundId, 
                BackgroundColorId = value.BackgroundColorId, 
                ForegroundPrimaryColorId = value.ForegroundPrimaryColorId, 
                ForegroundSecondaryColorId = value.ForegroundSecondaryColorId
            };
            var flags = value.Flags;
            if (flags != null)
            {
                emblem.Flags = this.converterForEmblemTransformations.Convert(flags);
            }

            return emblem;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForEmblemTransformations != null);
        }
    }
}