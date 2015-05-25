// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Consumable" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Consumable"/>.</summary>
    internal sealed class ConverterForConsumable : IConverter<ItemDataContract, Consumable>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<ConsumableDataContract, Consumable>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForConsumable"/> class.</summary>
        public ConverterForConsumable()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForConsumable"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        public ConverterForConsumable(IDictionary<string, IConverter<ConsumableDataContract, Consumable>> typeConverters)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public Consumable Convert(ItemDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var consumableDataContract = value.Consumable;
            if (consumableDataContract == null)
            {
                return new UnknownConsumable();
            }

            IConverter<ConsumableDataContract, Consumable> converter;
            if (this.typeConverters.TryGetValue(consumableDataContract.Type, out converter))
            {
                return converter.Convert(consumableDataContract, state);
            }

            return new UnknownConsumable();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<ConsumableDataContract, Consumable>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<ConsumableDataContract, Consumable>>
            {
                { "AppearanceChange", new ConverterForAppearanceChanger() }, 
                { "Booze", new ConverterForAlcohol() }, 
                { "ContractNpc", new ConverterForContractNpc() }, 
                { "Food", new ConverterForFood() }, 
                { "Generic", new ConverterForGenericConsumable() }, 
                { "Halloween", new ConverterForHalloweenConsumable() }, 
                { "Immediate", new ConverterForImmediateConsumable() }, 
                { "Transmutation", new ConverterForTransmutation() }, 
                { "Unlock", new ConverterForUnlocker() }, 
                { "UnTransmutation", new ConverterForUnTransmutation() }, 
                { "UpgradeRemoval", new ConverterForUpgradeRemoval() }, 
                { "Utility", new ConverterForUtility() }, 
            };
        }
    }
}