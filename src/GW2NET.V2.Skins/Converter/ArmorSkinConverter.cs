// <copyright file="ArmorSkinConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Skins.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Skins;
    using GW2NET.V2.Skins.Json;

    public partial class ArmorSkinConverter
    {
        private readonly IConverter<string, WeightClass> weightClassConverter;

        /// <summary>Initializes a new instance of the <see cref="ArmorSkinConverter" /> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="weightClassConverter">The converter for <see cref="WeightClass" />.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ArmorSkinConverter(
            ITypeConverterFactory<SkinDTO, ArmorSkin> converterFactory,
            IConverter<string, WeightClass> weightClassConverter)
            : this(converterFactory)
        {
            if (weightClassConverter == null)
            {
                throw new ArgumentNullException("weightClassConverter");
            }

            this.weightClassConverter = weightClassConverter;
        }

        partial void Merge(ArmorSkin entity, SkinDTO dto, object state)
        {
            var details = dto.Details;
            if (details == null)
            {
                return;
            }

            if (details.WeightClass != null)
            {
                entity.WeightClass = this.weightClassConverter.Convert(details.WeightClass, details);
            }
        }
    }
}