// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUpgradeComponent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="V2.Items.Json.ItemDataContract" /> to objects of type <see cref="UpgradeComponent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="UpgradeComponent"/>.</summary>
    internal sealed class ConverterForUpgradeComponent : IConverter<ItemDataContract, UpgradeComponent>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, InfusionSlotFlags> converterForInfusionSlotFlagCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, UpgradeComponentFlags> converterForUpgradeComponentFlagCollection;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<UpgradeComponentDataContract, UpgradeComponent>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForUpgradeComponent"/> class.</summary>
        public ConverterForUpgradeComponent()
            : this(GetKnownTypeConverters(), new ConverterForUpgradeComponentFlagCollection(), new ConverterForInfusionSlotFlagCollection(), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForUpgradeComponent"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForUpgradeComponentFlagCollection">The converter for <see cref="UpgradeComponentFlags"/>.</param>
        /// <param name="converterForInfusionSlotFlagCollection">The converter for <see cref="ICollection{InfusionSlotFlags}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForUpgradeComponent(IDictionary<string, IConverter<UpgradeComponentDataContract, UpgradeComponent>> typeConverters, IConverter<ICollection<string>, UpgradeComponentFlags> converterForUpgradeComponentFlagCollection, IConverter<ICollection<string>, InfusionSlotFlags> converterForInfusionSlotFlagCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            if (converterForUpgradeComponentFlagCollection == null)
            {
                throw new ArgumentNullException("converterForUpgradeComponentFlagCollection", "Precondition: converterForUpgradeComponentFlagCollection != null");
            }

            if (converterForInfusionSlotFlagCollection == null)
            {
                throw new ArgumentNullException("converterForInfusionSlotFlagCollection", "Precondition: converterForInfusionSlotFlagCollection != null");
            }

            if (converterForInfixUpgrade == null)
            {
                throw new ArgumentNullException("converterForInfixUpgrade", "Precondition: converterForInfixUpgrade != null");
            }

            this.converterForUpgradeComponentFlagCollection = converterForUpgradeComponentFlagCollection;
            this.converterForInfusionSlotFlagCollection = converterForInfusionSlotFlagCollection;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public UpgradeComponent Convert(ItemDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var upgradeComponentDataContract = value.UpgradeComponent;
            if (upgradeComponentDataContract == null)
            {
                return new UnknownUpgradeComponent();
            }

            UpgradeComponent upgradeComponent;
            IConverter<UpgradeComponentDataContract, UpgradeComponent> converter;
            if (this.typeConverters.TryGetValue(upgradeComponentDataContract.Type, out converter))
            {
                upgradeComponent = converter.Convert(upgradeComponentDataContract);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + upgradeComponentDataContract.Type);
                upgradeComponent = new UnknownUpgradeComponent();
            }

            var flags = upgradeComponentDataContract.Flags;
            if (flags != null)
            {
                upgradeComponent.UpgradeComponentFlags = this.converterForUpgradeComponentFlagCollection.Convert(flags);
            }

            var infusionUpgradeFlags = upgradeComponentDataContract.InfusionUpgradeFlags;
            if (infusionUpgradeFlags != null)
            {
                upgradeComponent.InfusionUpgradeFlags = this.converterForInfusionSlotFlagCollection.Convert(infusionUpgradeFlags);
            }

            upgradeComponent.Suffix = upgradeComponentDataContract.Suffix;

            var infixUpgradeDataContract = upgradeComponentDataContract.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                upgradeComponent.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            upgradeComponent.Bonuses = upgradeComponentDataContract.Bonuses;

            return upgradeComponent;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<UpgradeComponentDataContract, UpgradeComponent>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<UpgradeComponentDataContract, UpgradeComponent>>
            {
                { "Default", new ConverterForDefaultUpgradeComponent() },
                { "Gem", new ConverterForGem() },
                { "Sigil", new ConverterForSigil() },
                { "Rune", new ConverterForRune() }
            };
        }
    }
}