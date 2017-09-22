// <copyright file="ConsumableConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V2
{
    using System;
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    public class ConsumableConverterFactory : ITypeConverterFactory<ItemDTO, Consumable>
    {
        private readonly ITypeConverterFactory<ItemDTO, Unlocker> unlockerConverterFactory;

        public ConsumableConverterFactory(ITypeConverterFactory<ItemDTO, Unlocker> unlockerConverterFactory)
        {
            if (unlockerConverterFactory == null)
            {
                throw new ArgumentNullException("unlockerConverterFactory");
            }

            this.unlockerConverterFactory = unlockerConverterFactory;
        }

        public IConverter<ItemDTO, Consumable> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "AppearanceChange":
                    return new AppearanceChangerConverter();
                case "Booze":
                    return new AlcoholConverter();
                case "ContractNpc":
                    return new ContractNpcConverter();
                case "Food":
                    return new FoodConverter();
                case "Generic":
                    return new GenericConsumableConverter();
                case "Halloween":
                    return new HalloweenConsumableConverter();
                case "Immediate":
                    return new ImmediateConsumableConverter();
                case "Transmutation":
                    return new TransmutationConverter();
                case "Unlock":
                    return new UnlockerConverter(this.unlockerConverterFactory);
                case "UnTransmutation":
                    return new UnTransmutationConverter();
                case "UpgradeRemoval":
                    return new UpgradeRemovalConverter();
                case "Utility":
                    return new UtilityConverter();
                case "TeleportToFriend":
                    return new TeleportToFriendConverter();
                case "RandomUnlock":
                    return new RandomUnlockConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownConsumableConverter();
            }
        }
    }
}