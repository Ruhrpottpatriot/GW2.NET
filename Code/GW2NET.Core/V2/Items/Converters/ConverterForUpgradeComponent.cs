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

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, UpgradeComponent>> typeConverters;

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
        public ConverterForUpgradeComponent(IDictionary<string, IConverter<DetailsDataContract, UpgradeComponent>> typeConverters, IConverter<ICollection<string>, UpgradeComponentFlags> converterForUpgradeComponentFlagCollection, IConverter<ICollection<string>, InfusionSlotFlags> converterForInfusionSlotFlagCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            Contract.Requires(converterForUpgradeComponentFlagCollection != null);
            Contract.Requires(converterForInfusionSlotFlagCollection != null);
            Contract.Requires(converterForInfixUpgrade != null);
            this.converterForUpgradeComponentFlagCollection = converterForUpgradeComponentFlagCollection;
            this.converterForInfusionSlotFlagCollection = converterForInfusionSlotFlagCollection;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="UpgradeComponent"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public UpgradeComponent Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            UpgradeComponent upgradeComponent;
            IConverter<DetailsDataContract, UpgradeComponent> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                upgradeComponent = converter.Convert(value);
            }
            else
            {
                upgradeComponent = new UnknownUpgradeComponent();
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

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, UpgradeComponent>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, UpgradeComponent>>
            {
                { "Default", new ConverterForDefaultUpgradeComponent() }, 
                { "Gem", new ConverterForGem() }, 
                { "Sigil", new ConverterForSigil() }, 
                { "Rune", new ConverterForRune() }
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
            Contract.Invariant(this.converterForUpgradeComponentFlagCollection != null);
            Contract.Invariant(this.converterForInfusionSlotFlagCollection != null);
            Contract.Invariant(this.converterForInfixUpgrade != null);
        }
    }
}