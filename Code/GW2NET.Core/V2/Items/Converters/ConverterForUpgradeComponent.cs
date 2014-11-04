// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUpgradeComponent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="UpgradeComponent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="UpgradeComponent"/>.</summary>
    internal sealed class ConverterForUpgradeComponent : IConverter<DetailsDataContract, UpgradeComponent>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, InfusionSlotFlags> converterForInfusionSlotFlagCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, UpgradeComponentFlags> converterForUpgradeComponentFlagCollection;

        /// <summary>Initializes a new instance of the <see cref="ConverterForUpgradeComponent"/> class.</summary>
        public ConverterForUpgradeComponent()
            : this(new ConverterForUpgradeComponentFlagCollection(), new ConverterForInfusionSlotFlagCollection(), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForUpgradeComponent"/> class.</summary>
        /// <param name="converterForUpgradeComponentFlagCollection">The converter for <see cref="UpgradeComponentFlags"/>.</param>
        /// <param name="converterForInfusionSlotFlagCollection">The converter for <see cref="ICollection{InfusionSlotFlags}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForUpgradeComponent(IConverter<ICollection<string>, UpgradeComponentFlags> converterForUpgradeComponentFlagCollection, IConverter<ICollection<string>, InfusionSlotFlags> converterForInfusionSlotFlagCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            Contract.Requires(converterForUpgradeComponentFlagCollection != null);
            Contract.Requires(converterForInfusionSlotFlagCollection != null);
            Contract.Requires(converterForInfixUpgrade != null);
            this.converterForUpgradeComponentFlagCollection = converterForUpgradeComponentFlagCollection;
            this.converterForInfusionSlotFlagCollection = converterForInfusionSlotFlagCollection;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="UpgradeComponent"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public UpgradeComponent Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            UpgradeComponent upgradeComponent;
            switch (value.Type)
            {
                case "Default":
                    upgradeComponent = new DefaultUpgradeComponent();
                    break;
                case "Gem":
                    upgradeComponent = new Gem();
                    break;
                case "Sigil":
                    upgradeComponent = new Sigil();
                    break;
                case "Rune":
                    upgradeComponent = new Rune();
                    break;
                default:
                    upgradeComponent = new UnknownUpgradeComponent();
                    break;
            }

            var flags = value.Flags;
            if (flags != null)
            {
                upgradeComponent.UpgradeComponentFlags = this.converterForUpgradeComponentFlagCollection.Convert(flags);
            }

            var infusionUpgradeFlags = value.InfusionUpgradeFlags;
            if (infusionUpgradeFlags != null)
            {
                upgradeComponent.InfusionUpgradeFlags = this.converterForInfusionSlotFlagCollection.Convert(infusionUpgradeFlags);
            }

            upgradeComponent.Suffix = value.Suffix;

            var infixUpgradeDataContract = value.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                upgradeComponent.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            upgradeComponent.Bonuses = value.Bonuses;

            return upgradeComponent;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForUpgradeComponentFlagCollection != null);
            Contract.Invariant(this.converterForInfusionSlotFlagCollection != null);
            Contract.Invariant(this.converterForInfixUpgrade != null);
        }
    }
}