namespace GW2NET.V2.Colors.Converters
{
    using GW2NET.Colors;
    using GW2NET.Common;

    public class ColorConverterMock : IConverter<int[], Color>
    {
        public int ConvertCount { get; set; }

        public Color Convert(int[] value, object state)
        {
            this.ConvertCount += 1;
            return default(Color);
        }
    }
}
