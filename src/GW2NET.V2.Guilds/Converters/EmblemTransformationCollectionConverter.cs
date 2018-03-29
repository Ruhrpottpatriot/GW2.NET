// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemTransformationCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="EmblemTransformations" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Guilds.Converters
{
    using System;
    using System.Collections.Generic;
    using Common;
    using GW2NET.Guilds;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="EmblemTransformations"/>.</summary>
    public sealed class EmblemTransformationCollectionConverter : IConverter<ICollection<string>, EmblemTransformations>
    {
        private readonly IConverter<string, EmblemTransformations> emblemTransformationConverter;

        /// <summary>Initializes a new instance of the <see cref="EmblemTransformationCollectionConverter"/> class.</summary>
        /// <param name="emblemTransformationConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EmblemTransformationCollectionConverter(IConverter<string, EmblemTransformations> emblemTransformationConverter)
        {
            if (emblemTransformationConverter == null)
            {
                throw new ArgumentNullException("emblemTransformationConverter");
            }

            this.emblemTransformationConverter = emblemTransformationConverter;
        }

        /// <inheritdoc />
        public EmblemTransformations Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var result = default(EmblemTransformations);
            foreach (var s in value)
            {
                result |= this.emblemTransformationConverter.Convert(s, state);
            }

            return result;
        }
    }
}