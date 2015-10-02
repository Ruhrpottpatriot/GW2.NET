namespace GW2NET.V2.Colors.Converters
{
    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.V2.Colors.Json;

    public class ColorModelConverterMock : IConverter<ColorModelDTO, ColorModel>
    {
        public int ConvertCount { get; set; }

        public ColorModel Convert(ColorModelDTO value, object state)
        {
            this.ConvertCount += 1;
            return default(ColorModel);
        }
    }
}
