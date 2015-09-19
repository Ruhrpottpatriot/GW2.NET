namespace GW2NET.Factories.V2
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    public class ContainerConverterFactory : ITypeConverterFactory<ItemDTO, Container>
    {
        public IConverter<ItemDTO, Container> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Default":
                    return new DefaultContainerConverter();
                case "GiftBox":
                    return new GiftBoxConverter();
                case "OpenUI":
                    return new OpenUiContainerConverter();
                default:
                    return new UnknownContainerConverter();
            }
        }
    }
}