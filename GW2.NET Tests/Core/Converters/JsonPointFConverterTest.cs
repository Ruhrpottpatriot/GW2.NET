using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.Converters
{
    [TestFixture]
    public class JsonPointFConverterTest
    {
        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadBothNil_ReturnsDefault()
        {
            const string input = "[0.0,0.0]";
            PointF expected = default(PointF);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadEmptyArray_ReturnsDefault()
        {
            const string input = "[]";
            PointF expected = default(PointF);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void JsonPointFConverter_ReadEmpty_ExceptionIsThrownForValueType()
        {
            string input = string.Empty;
            JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadEmpty_ReturnsNullForNullableType()
        {
            string input = string.Empty;
            var output = JsonConvert.DeserializeObject<PointF?>(input, new JsonPointFConverter());

            Assert.IsNull(output);
        }

        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void JsonPointFConverter_ReadMoreThanTwoValues_ConverterThrowsJsonSerializationException()
        {
            const string input = "[1.2,3.4,5.6]";
            JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadNegativeExtremes_PointFReflectsInput()
        {
            const string input = "[-2147483648.0,-2147483648.0]";
            var expected = new PointF(int.MinValue, int.MinValue);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadNegativeValues_PointFRefectsInput()
        {
            const string input = "[-1.2,-3.4]";
            var expected = new PointF(-1.2F, -3.4F);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }


        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadNull_ReturnsDefaultForValueType()
        {
            const string input = "null";
            PointF expected = default(PointF);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadNull_ReturnsNullForNullableType()
        {
            const string input = "null";
            var output = JsonConvert.DeserializeObject<PointF?>(input, new JsonPointFConverter());

            Assert.IsNull(output);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadPositiveExtremes_PointFReflectsInput()
        {
            const string input = "[2147483647.0,2147483647.0]";
            var expected = new PointF(int.MaxValue, int.MaxValue);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadPositiveValues_PointFRefectsInput()
        {
            const string input = "[1.2,3.4]";
            var expected = new PointF(1.2F, 3.4F);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadSingleNil_ReturnsDefault()
        {
            const string input = "[0.0]";
            PointF expected = default(PointF);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_ReadSingleValue_ConverterAssumesValueIsX()
        {
            const string input = "[1.2]";
            var expected = new PointF(1.2F, 0F);
            var actual = JsonConvert.DeserializeObject<PointF>(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_WriteDefaultPointF_JsonReflectsInput()
        {
            const string expected = "[0.0,0.0]";
            PointF input = default(PointF);
            string actual = JsonConvert.SerializeObject(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_WriteNegativeExtremes_JsonReflectsInput()
        {
            const string expected = "[-2147483648.0,-2147483648.0]";
            var input = new PointF(int.MinValue, int.MinValue);
            string actual = JsonConvert.SerializeObject(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_WriteNegativeValues_JsonReflectsInput()
        {
            const string expected = "[-1.2,-3.4]";
            var input = new PointF(-1.2F, -3.4F);
            string actual = JsonConvert.SerializeObject(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }


        [Test]
        [Category("Converters")]
        [Ignore(
            "Known bug: this test fails due to loss of accuracy in floating point numbers when working with large numbers."
            )]
        public void JsonPointFConverter_WritePositiveExtremes_JsonReflectsInput()
        {
            const string expected = "[2147483647.0,2147483647.0]";
            var input = new PointF(int.MaxValue, int.MaxValue);
            string actual = JsonConvert.SerializeObject(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void JsonPointFConverter_WritePositiveValues_JsonReflectsInput()
        {
            const string expected = "[1.2,3.4]";
            var input = new PointF(1.2F, 3.4F);
            string actual = JsonConvert.SerializeObject(input, new JsonPointFConverter());

            Assert.AreEqual(expected, actual);
        }
    }
}