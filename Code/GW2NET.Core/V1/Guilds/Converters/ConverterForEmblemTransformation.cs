// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForEmblemTransformation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="EmblemTransformations" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Entities.Guilds;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="EmblemTransformations"/>.</summary>
    internal sealed class ConverterForEmblemTransformation : IConverter<string, EmblemTransformations>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="EmblemTransformations"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public EmblemTransformations Convert(string value)
        {
            EmblemTransformations result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(EmblemTransformations);
        }
    }
}