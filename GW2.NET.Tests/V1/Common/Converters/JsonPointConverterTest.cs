namespace GW2DotNET.V1.Common.Converters
{
    using System.Drawing;

    using GW2DotNET.V1.DynamicEvents.Converters;

    using Newtonsoft.Json;

    using NUnit.Framework;

    [TestFixture]
    public class JsonPointConverterTest
    {
        [Test]
        [Category("Converters")]
        public void Read_BothNil_ReturnsDefault()
        {
            const string input = "[0,0]";
            Point expected = default(Point);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void Read_EmptyArray_ConverterThrowsJsonSerializationException()
        {
            const string input = "[]";
            JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());
        }

        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void Read_Empty_ExceptionIsThrownForValueType()
        {
            string input = string.Empty;
            JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());
        }

        [Test]
        [Category("Converters")]
        public void Read_Empty_ReturnsNullForNullableType()
        {
            string input = string.Empty;
            var output = JsonConvert.DeserializeObject<Point?>(input, new JsonPointConverter());

            Assert.IsNull(output);
        }

        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void Read_MoreThanTwoValues_ConverterThrowsJsonSerializationException()
        {
            const string input = "[1,2,3]";
            JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());
        }

        [Test]
        [Category("Converters")]
        public void Read_NegativeExtremes_PointReflectsInput()
        {
            const string input = "[-2147483648,-2147483648]";
            var expected = new Point(int.MinValue, int.MinValue);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void Read_NegativeValues_PointRefectsInput()
        {
            const string input = "[-1,-2]";
            var expected = new Point(-1, -2);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void Read_Null_ReturnsDefaultForValueType()
        {
            const string input = "null";
            Point expected = default(Point);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void Read_Null_ReturnsNullForNullableType()
        {
            const string input = "null";
            var output = JsonConvert.DeserializeObject<Point?>(input, new JsonPointConverter());

            Assert.IsNull(output);
        }

        [Test]
        [Category("Converters")]
        public void Read_PositiveExtremes_PointReflectsInput()
        {
            const string input = "[2147483647,2147483647]";
            var expected = new Point(int.MaxValue, int.MaxValue);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        public void Read_PositiveValues_PointRefectsInput()
        {
            const string input = "[1,2]";
            var expected = new Point(1, 2);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void Read_LessThanTwoValues_ConverterThrowsJsonSerializationException()
        {
            const string input = "[1]";
            JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());
        }
    }
}