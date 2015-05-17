// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForEmblem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EmblemDataContract" /> to objects of type <see cref="Emblem" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Guilds;
using GW2NET.V1.Guilds.Json;

namespace GW2NET.V1.Guilds.Converters
{
    using System;

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
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForEmblemTransformations"/> is a null reference.</exception>
        internal ConverterForEmblem(IConverter<ICollection<string>, EmblemTransformations> converterForEmblemTransformations)
        {
            if (converterForEmblemTransformations == null)
            {
                throw new ArgumentNullException("converterForEmblemTransformations", "Precondition: converterForEmblemTransformations != null");
            }

            this.converterForEmblemTransformations = converterForEmblemTransformations;
        }

        /// <inheritdoc />
        public Emblem Convert(EmblemDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

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
    }
}