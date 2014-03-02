using System.Drawing;
using Newtonsoft.Json;
using NUnit.Framework;
using SizeConverter = GW2DotNET.V1.Core.Converters.SizeConverter;

namespace GW2DotNET_Tests.Core.Converters
{
    [TestFixture]
    public class SizeConverterTest
    {
        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void SizeConverter_ReadEmpty_ExceptionIsThrownForValueType()
        {
            var input = string.Empty;
            JsonConvert.DeserializeObject<Size>(input, new SizeConverter());
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadEmpty_ReturnsNullForNullableType()
        {
            var input  = string.Empty;
            var output = JsonConvert.DeserializeObject<Size?>(input, new SizeConverter());

            Assert.IsNull(output);
        }


        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadNull_ReturnsDefaultForValueType()
        {
            const string input = "null";
            var expected       = default(Size);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadNull_ReturnsNullForNullableType()
        {
            const string input = "null";
            var output         = JsonConvert.DeserializeObject<Size?>(input, new SizeConverter());

            Assert.IsNull(output);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadEmptyArray_ReturnsDefault()
        {
            const string input = "[]";
            var expected       = default(Size);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadSingleNil_ReturnsDefault()
        {
            const string input = "[0]";
            var expected       = default(Size);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadBothNil_ReturnsDefault()
        {
            const string input = "[0,0]";
            var expected       = default(Size);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadPositiveValues_SizeRefectsInput()
        {
            const string input = "[1,2]";
            var expected       = new Size(1, 2);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadNegativeValues_SizeRefectsInput()
        {
            const string input = "[-1,-2]";
            var expected       = new Size(-1, -2);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadSingleValue_ConverterAssumesXEqualsY()
        {
            const string input = "[1]";
            var expected       = new Size(1, 1);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void SizeConverter_ReadMoreThanTwoValues_ConverterThrowsJsonSerializationException()
        {
            const string input = "[1,2,3]";
            JsonConvert.DeserializeObject<Size>(input, new SizeConverter());
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadPositiveExtremes_SizeReflectsInput()
        {
            const string input = "[2147483647,2147483647]";
            var expected       = new Size(int.MaxValue, int.MaxValue);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_ReadNegativeExtremes_SizeReflectsInput()
        {
            const string input = "[-2147483648,-2147483648]";
            var expected       = new Size(int.MinValue, int.MinValue);
            var actual         = JsonConvert.DeserializeObject<Size>(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_WriteDefaultSize_JsonReflectsInput()
        {
            const string expected = "[0,0]";
            var input             = default(Size);
            var actual            = JsonConvert.SerializeObject(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_WritePositiveValues_JsonReflectsInput()
        {
            const string expected = "[1,2]";
            var input             = new Size(1, 2);
            var actual            = JsonConvert.SerializeObject(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_WriteNegativeValues_JsonReflectsInput()
        {
            const string expected = "[-1,-2]";
            var input             = new Size(-1, -2);
            var actual            = JsonConvert.SerializeObject(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }


        [Test]
        [Category("Converters")]
        public void SizeConverter_WritePositiveExtremes_JsonReflectsInput()
        {
            const string expected = "[2147483647,2147483647]";
            var input             = new Size(int.MaxValue, int.MaxValue);
            var actual            = JsonConvert.SerializeObject(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void SizeConverter_WriteNegativeExtremes_JsonReflectsInput()
        {
            const string expected = "[-2147483648,-2147483648]";
            var input             = new Size(int.MinValue, int.MinValue);
            var actual            = JsonConvert.SerializeObject(input, new SizeConverter());

            Assert.AreEqual(expected, actual);
        }
    }
}
