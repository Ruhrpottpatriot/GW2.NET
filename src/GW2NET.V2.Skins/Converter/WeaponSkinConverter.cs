// <copyright file="WeaponSkinConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Converter
{
    using System;
    using Common;
    using Items.Weapons;
    using Json;
    using Skins;

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
                throw new ArgumentNullException(nameof(damageTypeConverter));
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