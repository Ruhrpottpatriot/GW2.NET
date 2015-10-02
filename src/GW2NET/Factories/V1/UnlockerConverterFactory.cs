namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class UnlockerConverterFactory : ITypeConverterFactory<ItemDTO, Unlocker>
    {
        public IConverter<ItemDTO, Unlocker> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "BagSlot":
                    return new BagSlotUnlockerConverter();
                case "BankTab":
                    return new BankTabUnlockerConverter();
                case "CollectibleCapacity":
                    return new CollectibleCapacityUnlockerConverter();
                case "Content":
                    return new ContentUnlockerConverter();
                case "CraftingRecipe":
                    return new CraftingRecipeUnlockerConverter();
                case "Dye":
                    return new DyeUnlockerConverter();
                default:
                    return new UnknownUnlockerConverter();
            }
        }
    }
}