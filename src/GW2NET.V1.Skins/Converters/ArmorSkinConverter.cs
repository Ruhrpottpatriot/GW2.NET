// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorSkinConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinDTO" /> to objects of type <see cref="ArmorSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Skins;
    using GW2NET.V1.Skins.Json;

    public partial class ArmorSkinConverter
    {
        private readonly IConverter<string, WeightClass> weightClassConverter;

        /// <summary>Initializes a new instance of the <see cref="ArmorSkinConverter" /> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="weightClassConverter">The converter for <see cref="WeightClass" />.</param>
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
            var armor = dto.Armor;
            if (armor == null)
            {
                return;
            }

            entity.WeightClass = this.weightClassConverter.Convert(armor.WeightClass, armor);
        }
    }
}