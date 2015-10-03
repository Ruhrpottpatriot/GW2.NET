// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDTO" /> to objects of type <see cref="Trinket" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class TrinketConverter
    {
        private readonly IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter;

        private readonly IConverter<ICollection<InfusionSlotDTO>, ICollection<InfusionSlot>> infusionSlotCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="TrinketConverter"/> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="infusionSlotCollectionConverter"></param>
        /// <param name="infixUpgradeConverter"></param>
        public TrinketConverter(
            ITypeConverterFactory<ItemDTO, Trinket> converterFactory,
            IConverter<ICollection<InfusionSlotDTO>, ICollection<InfusionSlot>> infusionSlotCollectionConverter,
            IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter)
            : this(converterFactory)
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

        partial void Merge(Trinket entity, ItemDTO dto, object state)
        {
            var trinket = dto.Trinket;
            if (trinket == null)
            {
                return;
            }

            var infusionSlots = trinket.InfusionSlots;
            if (infusionSlots != null)
            {
                entity.InfusionSlots = this.infusionSlotCollectionConverter.Convert(infusionSlots, trinket);
            }

            var infixUpgrade = trinket.InfixUpgrade;
            if (infixUpgrade != null)
            {
                entity.InfixUpgrade = this.infixUpgradeConverter.Convert(infixUpgrade, trinket);
            }

            int suffixItemId;
            if (int.TryParse(trinket.SuffixItemId, out suffixItemId))
            {
                entity.SuffixItemId = suffixItemId;
            }

            int secondarySuffixItemId;
            if (int.TryParse(trinket.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                entity.SecondarySuffixItemId = secondarySuffixItemId;
            }
        }
    }
}