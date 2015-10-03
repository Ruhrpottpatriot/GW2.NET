// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDTO" /> to objects of type <see cref="Armor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDTO" /> to objects of type <see cref="Armor" />.</summary>
    public partial class ArmorConverter
    {
        private readonly IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter;

        private readonly IConverter<ICollection<InfusionSlotDTO>, ICollection<InfusionSlot>> infusionSlotCollectionConverter;

        private readonly IConverter<string, WeightClass> weightClassConverter;

        /// <summary>Initializes a new instance of the <see cref="ArmorConverter" /> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="weightClassConverter"></param>
        /// <param name="infusionSlotCollectionConverter"></param>
        /// <param name="infixUpgradeConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ArmorConverter(
            ITypeConverterFactory<ItemDTO, Armor> converterFactory,
            IConverter<string, WeightClass> weightClassConverter,
            IConverter<ICollection<InfusionSlotDTO>, ICollection<InfusionSlot>> infusionSlotCollectionConverter,
            IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter)
            : this(converterFactory)
        {
            if (weightClassConverter == null)
            {
                throw new ArgumentNullException("weightClassConverter");
            }

            if (infusionSlotCollectionConverter == null)
            {
                throw new ArgumentNullException("infusionSlotCollectionConverter");
            }

            if (infixUpgradeConverter == null)
            {
                throw new ArgumentNullException("infixUpgradeConverter");
            }

            this.weightClassConverter = weightClassConverter;
            this.infusionSlotCollectionConverter = infusionSlotCollectionConverter;
            this.infixUpgradeConverter = infixUpgradeConverter;
        }

        partial void Merge(Armor entity, ItemDTO dto, object state)
        {
            int defaultSkinId;
            if (int.TryParse(dto.DefaultSkin, out defaultSkinId))
            {
                entity.DefaultSkinId = defaultSkinId;
            }

            var armor = dto.Armor;
            entity.WeightClass = this.weightClassConverter.Convert(armor.WeightClass, armor);
            int defense;
            if (int.TryParse(armor.Defense, out defense))
            {
                entity.Defense = defense;
            }

            var infusionSlots = armor.InfusionSlots;
            if (infusionSlots != null)
            {
                entity.InfusionSlots = this.infusionSlotCollectionConverter.Convert(infusionSlots, armor);
            }

            var infixUpgrade = armor.InfixUpgrade;
            if (infixUpgrade != null)
            {
                entity.InfixUpgrade = this.infixUpgradeConverter.Convert(infixUpgrade, armor);
            }

            int suffixItemId;
            if (int.TryParse(armor.SuffixItemId, out suffixItemId))
            {
                entity.SecondarySuffixItemId = suffixItemId;
            }

            int secondarySuffixItemId;
            if (int.TryParse(armor.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                entity.SecondarySuffixItemId = secondarySuffixItemId;
            }
        }
    }
}