// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EmblemDTO" /> to objects of type <see cref="Emblem" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Guilds.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.Guilds;
    using GW2NET.V1.Guilds.Json;

    /// <summary>Converts objects of type <see cref="EmblemDTO"/> to objects of type <see cref="Emblem"/>.</summary>
    public sealed class EmblemConverter : IConverter<EmblemDTO, Emblem>
    {
        private readonly IConverter<ICollection<string>, EmblemTransformations> emblemTransformationsConverter;

        /// <summary>Initializes a new instance of the <see cref="EmblemConverter"/> class.</summary>
        /// <param name="emblemTransformationsConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EmblemConverter(IConverter<ICollection<string>, EmblemTransformations> emblemTransformationsConverter)
        {
            if (emblemTransformationsConverter == null)
            {
                throw new ArgumentNullException("emblemTransformationsConverter");
            }

            this.emblemTransformationsConverter = emblemTransformationsConverter;
        }

        /// <inheritdoc />
        public Emblem Convert(EmblemDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
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
                emblem.Flags = this.emblemTransformationsConverter.Convert(flags, state);
            }

            return emblem;
        }
    }
}