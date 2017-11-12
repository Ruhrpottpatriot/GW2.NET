// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Consumable" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Consumable"/>.</summary>
    internal sealed class ConverterForConsumable : IConverter<DetailsDataContract, Consumable>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, Consumable>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForConsumable"/> class.</summary>
        public ConverterForConsumable()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForConsumable"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        public ConverterForConsumable(IDictionary<string, IConverter<DetailsDataContract, Consumable>> typeConverters)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Consumable"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Consumable Convert(DetailsDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            IConverter<DetailsDataContract, Consumable> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                return converter.Convert(value);
            }

            Debug.Assert(false, "Unknown type discriminator: " + value.Type);
            return new UnknownConsumable();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, Consumable>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Consumable>>
            {
                { "AppearanceChange", new ConverterForAppearanceChanger() },
                { "Booze", new ConverterForAlcohol() },
                { "ContractNpc", new ConverterForContractNpc() },
                { "Food", new ConverterForFood() },
                { "Generic", new ConverterForGenericConsumable() },
                { "Halloween", new ConverterForHalloweenConsumable() },
                { "Immediate", new ConverterForImmediateConsumable() },
                { "TeleportToFriend", new ConverterForTeleportToFriend() },
                { "Transmutation", new ConverterForTransmutation() },
                { "Unlock", new ConverterForUnlocker() },
                { "UnTransmutation", new ConverterForUnTransmutation() },
                { "UpgradeRemoval", new ConverterForUpgradeRemoval() },
                { "Utility", new ConverterForUtility() },
            };
        }
    }
}
