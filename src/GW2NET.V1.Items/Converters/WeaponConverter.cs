// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDTO" /> to objects of type <see cref="Weapon" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class WeaponConverter
    {
        private readonly IConverter<string, DamageType> damageTypeConverter;

        private readonly IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter;

        private readonly IConverter<ICollection<InfusionSlotDTO>, ICollection<InfusionSlot>> infusionSlotCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="WeaponConverter"/> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="damageTypeConverter"></param>
        /// <param name="infusionSlotCollectionConverter"></param>
        /// <param name="infixUpgradeConverter"></param>
        public WeaponConverter(
            ITypeConverterFactory<ItemDTO, Weapon> converterFactory,
            IConverter<string, DamageType> damageTypeConverter,
            IConverter<ICollection<InfusionSlotDTO>, ICollection<InfusionSlot>> infusionSlotCollectionConverter,
            IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter)
            : this(converterFactory)
        {
            if (damageTypeConverter == null)
            {
                throw new ArgumentNullException("damageTypeConverter");
            }

            if (infixUpgradeConverter == null)
            {
                throw new ArgumentNullException("infixUpgradeConverter");
            }

            if (infusionSlotCollectionConverter == null)
            {
                throw new ArgumentNullException("infusionSlotCollectionConverter");
            }

            this.damageTypeConverter = damageTypeConverter;
            this.infixUpgradeConverter = infixUpgradeConverter;
            this.infusionSlotCollectionConverter = infusionSlotCollectionConverter;
        }

        partial void Merge(Weapon entity, ItemDTO dto, object state)
        {
            int defaultSkinId;
            if (int.TryParse(dto.DefaultSkin, out defaultSkinId))
            {
                entity.DefaultSkinId = defaultSkinId;
            }

            var weapon = dto.Weapon;
            if (weapon == null)
            {
                return;
            }

            entity.DamageType = this.damageTypeConverter.Convert(weapon.DamageType, state);

            int minimumPower;
            if (int.TryParse(weapon.MinimumPower, out minimumPower))
            {
                entity.MinimumPower = minimumPower;
            }

            int maximumPower;
            if (int.TryParse(weapon.MaximumPower, out maximumPower))
            {
                entity.MaximumPower = maximumPower;
            }

            int defense;
            if (int.TryParse(weapon.Defense, out defense))
            {
                entity.Defense = defense;
            }

            var infusionSlots = weapon.InfusionSlots;
            if (infusionSlots != null)
            {
                entity.InfusionSlots = this.infusionSlotCollectionConverter.Convert(infusionSlots, weapon);
            }

            var infixUpgrade = weapon.InfixUpgrade;
            if (infixUpgrade != null)
            {
                entity.InfixUpgrade = this.infixUpgradeConverter.Convert(infixUpgrade, weapon);
            }

            int suffixItemId;
            if (int.TryParse(weapon.SuffixItemId, out suffixItemId))
            {
                entity.SuffixItemId = suffixItemId;
            }

            int secondarySuffixItemId;
            if (int.TryParse(weapon.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                entity.SecondarySuffixItemId = secondarySuffixItemId;
            }
        }
    }
}