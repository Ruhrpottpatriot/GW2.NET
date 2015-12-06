// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="Unlocker" />.
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

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="Unlocker"/>.</summary>
    internal sealed class ConverterForUnlocker : IConverter<ConsumableDataContract, Unlocker>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<ConsumableDataContract, Unlocker>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForUnlocker"/> class.</summary>
        public ConverterForUnlocker()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForUnlocker"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        public ConverterForUnlocker(IDictionary<string, IConverter<ConsumableDataContract, Unlocker>> typeConverters)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public Unlocker Convert(ConsumableDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            IConverter<ConsumableDataContract, Unlocker> converter;
            if (this.typeConverters.TryGetValue(value.UnlockType, out converter))
            {
                return converter.Convert(value);
            }

            Debug.Assert(false, "Unknown type discriminator: " + value.UnlockType);
            return new UnknownUnlocker();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<ConsumableDataContract, Unlocker>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<ConsumableDataContract, Unlocker>>
            {
                { "BagSlot", new ConverterForBagSlotUnlocker() },
                { "BankTab", new ConverterForBankTabUnlocker() },
                { "Champion", new ConverterForChampionUnlocker() },
                { "CollectibleCapacity", new ConverterForCollectibleCapacityUnlocker() },
                { "Content", new ConverterForContentUnlocker() },
                { "CraftingRecipe", new ConverterForCraftingRecipeUnlocker() },
                { "Dye", new ConverterForDyeUnlocker() },
                { "GliderSkin", new ConverterForGliderSkinUnlocker() },
                { "Outfit", new ConverterForOutfitUnlocker() }
            };
        }
    }
}