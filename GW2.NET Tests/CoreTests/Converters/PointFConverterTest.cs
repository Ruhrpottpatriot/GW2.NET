using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.Converters
{
    [TestFixture]
    public class PointFConverterTest
    {
        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void PointFConverter_ReadEmpty_ExceptionIsThrownForValueType()
        {
            var input = string.Empty;
            JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadEmpty_ReturnsNullForNullableType()
        {
            var input  = string.Empty;
            var output = JsonConvert.DeserializeObject<PointF?>(input, new PointFConverter());

            Assert.IsNull(output);
        }


        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadNull_ReturnsDefaultForValueType()
        {
            const string input = "null";
            var expected       = default(PointF);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadNull_ReturnsNullForNullableType()
        {
            const string input = "null";
            var output         = JsonConvert.DeserializeObject<PointF?>(input, new PointFConverter());

            Assert.IsNull(output);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadEmptyArray_ReturnsDefault()
        {
            const string input = "[]";
            var expected       = default(PointF);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadSingleNil_ReturnsDefault()
        {
            const string input = "[0.0]";
            var expected       = default(PointF);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadBothNil_ReturnsDefault()
        {
            const string input = "[0.0,0.0]";
            var expected       = default(PointF);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadPositiveValues_PointFRefectsInput()
        {
            const string input = "[1.2,3.4]";
            var expected       = new PointF(1.2F, 3.4F);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadNegativeValues_PointFRefectsInput()
        {
            const string input = "[-1.2,-3.4]";
            var expected       = new PointF(-1.2F, -3.4F);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadSingleValue_ConverterAssumesValueIsX()
        {
            const string input = "[1.2]";
            var expected       = new PointF(1.2F, 0F);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void PointFConverter_ReadMoreThanTwoValues_ConverterThrowsJsonSerializationException()
        {
            const string input = "[1.2,3.4,5.6]";
            JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadPositiveExtremes_PointFReflectsInput()
        {
            const string input = "[2147483647.0,2147483647.0]";
            var expected       = new PointF(int.MaxValue, int.MaxValue);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_ReadNegativeExtremes_PointFReflectsInput()
        {
            const string input = "[-2147483648.0,-2147483648.0]";
            var expected       = new PointF(int.MinValue, int.MinValue);
            var actual         = JsonConvert.DeserializeObject<PointF>(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_WriteDefaultPointF_JsonReflectsInput()
        {
            const string expected = "[0.0,0.0]";
            var input             = default(PointF);
            var actual            = JsonConvert.SerializeObject(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_WritePositiveValues_JsonReflectsInput()
        {
            const string expected = "[1.2,3.4]";
            var input             = new PointF(1.2F, 3.4F);
            var actual            = JsonConvert.SerializeObject(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_WriteNegativeValues_JsonReflectsInput()
        {
            const string expected = "[-1.2,-3.4]";
            var input             = new PointF(-1.2F, -3.4F);
            var actual            = JsonConvert.SerializeObject(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }


        [Test]
        [Category("Converters")]
        [Ignore("Known bug: this test fails due to loss of accuracy in floating point numbers when working with large numbers.")]
        public void PointFConverter_WritePositiveExtremes_JsonReflectsInput()
        {
            const string expected = "[2147483647.0,2147483647.0]";
            var input             = new PointF(int.MaxValue, int.MaxValue);
            var actual            = JsonConvert.SerializeObject(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void PointFConverter_WriteNegativeExtremes_JsonReflectsInput()
        {
            const string expected = "[-2147483648.0,-2147483648.0]";
            var input             = new PointF(int.MinValue, int.MinValue);
            var actual            = JsonConvert.SerializeObject(input, new PointFConverter());

            Assert.AreEqual(expected, actual);
        }
    }
}
