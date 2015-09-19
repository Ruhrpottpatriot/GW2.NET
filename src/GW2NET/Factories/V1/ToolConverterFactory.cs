namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class ToolConverterFactory : ITypeConverterFactory<ItemDTO, Tool>
    {
        public IConverter<ItemDTO, Tool> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Salvage":
                    return new SalvageToolConverter();
                default:
                    return new UnknownToolConverter();
            }
        }
    }
}