// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinDTO" /> to objects of type <see cref="WeaponSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Skins;
    using GW2NET.V2.Skins.Json;

    /// <summary>Converts objects of type <see cref="SkinDTO" /> to objects of type <see cref="WeaponSkin" />.</summary>
    public partial class WeaponSkinConverter
    {
        private readonly IConverter<string, DamageType> damageClassConverter;

        /// <summary>Initializes a new instance of the <see cref="WeaponSkinConverter" /> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="damageTypeConverter">The converter for <see cref="DamageType" />.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WeaponSkinConverter(
            ITypeConverterFactory<SkinDTO, WeaponSkin> converterFactory,
            IConverter<string, DamageType> damageTypeConverter)
            : this(converterFactory)
        {
            if (damageTypeConverter == null)
            {
                throw new ArgumentNullException("damageTypeConverter");
            }

            this.damageClassConverter = damageTypeConverter;
        }

        partial void Merge(WeaponSkin entity, SkinDTO dto, object state)
        {
            var details = dto.Details;
            if (details == null)
            {
                return;
            }

            if (details.DamageClass != null)
            {
                entity.DamageType = this.damageClassConverter.Convert(details.DamageClass, details);
            }
        }
    }
}