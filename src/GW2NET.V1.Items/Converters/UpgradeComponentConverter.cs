// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="V2.Items.Json.ItemDTO" /> to objects of type <see cref="UpgradeComponent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class UpgradeComponentConverter
    {
        private readonly IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter;

        private readonly IConverter<ICollection<string>, InfusionSlotFlags> infusionSlotFlagCollectionConverter;

        private readonly IConverter<ICollection<string>, UpgradeComponentFlags> upgradeComponentFlagCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponentConverter"/> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="upgradeComponentFlagCollectionConverter"></param>
        /// <param name="infusionSlotFlagCollectionConverter"></param>
        /// <param name="infixUpgradeConverter"></param>
        public UpgradeComponentConverter(
            ITypeConverterFactory<ItemDTO, UpgradeComponent> converterFactory,
            IConverter<ICollection<string>, UpgradeComponentFlags> upgradeComponentFlagCollectionConverter,
            IConverter<ICollection<string>, InfusionSlotFlags> infusionSlotFlagCollectionConverter,
            IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter)
            : this(converterFactory)
        {
            if (upgradeComponentFlagCollectionConverter == null)
            {
                throw new ArgumentNullException("upgradeComponentFlagCollectionConverter");
            }

            if (infusionSlotFlagCollectionConverter == null)
            {
                throw new ArgumentNullException("infusionSlotFlagCollectionConverter");
            }

            if (infixUpgradeConverter == null)
            {
                throw new ArgumentNullException("infixUpgradeConverter");
            }

            this.upgradeComponentFlagCollectionConverter = upgradeComponentFlagCollectionConverter;
            this.infusionSlotFlagCollectionConverter = infusionSlotFlagCollectionConverter;
            this.infixUpgradeConverter = infixUpgradeConverter;
        }

        partial void Merge(UpgradeComponent entity, ItemDTO dto, object state)
        {
            var upgradeComponent = dto.UpgradeComponent;
            if (upgradeComponent == null)
            {
                return;
            }

            var flags = upgradeComponent.Flags;
            if (flags != null)
            {
                entity.UpgradeComponentFlags = this.upgradeComponentFlagCollectionConverter.Convert(flags, upgradeComponent);
            }

            var infusionUpgradeFlags = upgradeComponent.InfusionUpgradeFlags;
            if (infusionUpgradeFlags != null)
            {
                entity.InfusionUpgradeFlags = this.infusionSlotFlagCollectionConverter.Convert(infusionUpgradeFlags, upgradeComponent);
            }

            entity.Suffix = upgradeComponent.Suffix;

            var infixUpgrade = upgradeComponent.InfixUpgrade;
            if (infixUpgrade != null)
            {
                entity.InfixUpgrade = this.infixUpgradeConverter.Convert(infixUpgrade, upgradeComponent);
            }

            entity.Bonuses = upgradeComponent.Bonuses;
        }
    }
}