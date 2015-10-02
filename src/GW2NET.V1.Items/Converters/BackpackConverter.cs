// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackpackConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDTO" /> to objects of type <see cref="Backpack" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Backpack"/>.</summary>
    public partial class BackpackConverter
    {
        private readonly IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter;

        private readonly IConverter<ICollection<InfusionSlotDTO>, ICollection<InfusionSlot>> infusionSlotCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="BackpackConverter"/> class.</summary>
        /// <param name="infusionSlotCollectionConverter"></param>
        /// <param name="infixUpgradeConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public BackpackConverter(IConverter<ICollection<InfusionSlotDTO>, ICollection<InfusionSlot>> infusionSlotCollectionConverter, IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter)
        {
            if (infusionSlotCollectionConverter == null)
            {
                throw new ArgumentNullException("infusionSlotCollectionConverter");
            }

            if (infixUpgradeConverter == null)
            {
                throw new ArgumentNullException("infixUpgradeConverter");
            }

            this.infusionSlotCollectionConverter = infusionSlotCollectionConverter;
            this.infixUpgradeConverter = infixUpgradeConverter;
        }

        partial void Merge(Backpack entity, ItemDTO dto, object state)
        {
            int defaultSkinId;
            if (int.TryParse(dto.DefaultSkin, out defaultSkinId))
            {
                entity.DefaultSkinId = defaultSkinId;
            }

            var backpack = dto.Backpack;
            if (backpack == null)
            {
                return;
            }

            var infusionSlots = backpack.InfusionSlots;
            if (infusionSlots != null)
            {
                entity.InfusionSlots = this.infusionSlotCollectionConverter.Convert(infusionSlots, dto);
            }

            var infixUpgrade = backpack.InfixUpgrade;
            if (infixUpgrade != null)
            {
                entity.InfixUpgrade = this.infixUpgradeConverter.Convert(infixUpgrade, dto);
            }

            int suffixItemId;
            if (int.TryParse(backpack.SuffixItemId, out suffixItemId))
            {
                entity.SuffixItemId = suffixItemId;
            }

            int secondarySuffixItemId;
            if (int.TryParse(backpack.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                entity.SecondarySuffixItemId = secondarySuffixItemId;
            }
        }
    }
}