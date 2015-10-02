// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDTO" /> to objects of type <see cref="UpgradeComponent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Json;

    public partial class UpgradeComponentConverter
    {
        private readonly IConverter<InfixUpgradeDTO, InfixUpgrade> infixUpgradeConverter;

        private readonly IConverter<ICollection<string>, InfusionSlotFlags> infusionSlotFlagCollectionConverter;

        private readonly IConverter<ICollection<string>, UpgradeComponentFlags> upgradeComponentFlagCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponentConverter"/> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="upgradeComponentFlagCollectionConverter">The converter for <see cref="UpgradeComponentFlags"/>.</param>
        /// <param name="infusionSlotFlagCollectionConverter">The converter for <see cref="ICollection{InfusionSlotFlags}"/>.</param>
        /// <param name="infixUpgradeConverter">The converter for <see cref="InfixUpgrade"/>.</param>
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
            var details = dto.Details;
            if (details == null)
            {
                return;
            }

            var flags = details.Flags;
            if (flags != null)
            {
                entity.UpgradeComponentFlags = this.upgradeComponentFlagCollectionConverter.Convert(flags, details);
            }

            var infusionUpgradeFlags = details.InfusionUpgradeFlags;
            if (infusionUpgradeFlags != null)
            {
                entity.InfusionUpgradeFlags = this.infusionSlotFlagCollectionConverter.Convert(infusionUpgradeFlags, details);
            }

            entity.Suffix = details.Suffix;

            var infixUpgrade = details.InfixUpgrade;
            if (infixUpgrade != null)
            {
                entity.InfixUpgrade = this.infixUpgradeConverter.Convert(infixUpgrade, details);
            }

            entity.Bonuses = details.Bonuses;
        }
    }
}