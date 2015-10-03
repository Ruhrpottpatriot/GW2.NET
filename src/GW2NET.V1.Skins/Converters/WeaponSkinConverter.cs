// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponSkinConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinDTO" /> to objects of type <see cref="WeaponSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Skins;
    using GW2NET.V1.Skins.Json;

    public partial class WeaponSkinConverter
    {
        private readonly IConverter<string, DamageType> damageTypeConverter;

        /// <summary>Initializes a new instance of the <see cref="WeaponSkinConverter" /> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="damageTypeConverter">The converter for <see cref="DamageType" />.</param>
        public WeaponSkinConverter(
            ITypeConverterFactory<SkinDTO, WeaponSkin> converterFactory,
            IConverter<string, DamageType> damageTypeConverter)
            : this(converterFactory)
        {
            if (damageTypeConverter == null)
            {
                throw new ArgumentNullException("damageTypeConverter");
            }

            this.damageTypeConverter = damageTypeConverter;
        }

        partial void Merge(WeaponSkin entity, SkinDTO dto, object state)
        {
            var weapon = dto.Weapon;
            if (weapon == null)
            {
                return;
            }

            entity.DamageType = this.damageTypeConverter.Convert(weapon.DamageType, weapon);
        }
    }
}