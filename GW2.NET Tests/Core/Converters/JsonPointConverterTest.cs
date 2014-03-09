// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonPointConverterTest.cs" company="">
//   
// </copyright>
// <summary>
//    The json point converter test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Core.Converters
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The json point converter test.</summary>
    [TestFixture]
    public class JsonPointConverterTest
    {
        #region Public Methods and Operators

        /// <summary>The json point converter_ read both nil_ returns default.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadBothNil_ReturnsDefault()
        {
            const string input = "[0,0]";
            Point expected = default(Point);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ read empty array_ returns default.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadEmptyArray_ReturnsDefault()
        {
            const string input = "[]";
            Point expected = default(Point);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ read empty_ exception is thrown for value type.</summary>
        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void JsonPointConverter_ReadEmpty_ExceptionIsThrownForValueType()
        {
            string input = string.Empty;
            JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());
        }

        /// <summary>The json point converter_ read empty_ returns null for nullable type.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadEmpty_ReturnsNullForNullableType()
        {
            string input = string.Empty;
            var output = JsonConvert.DeserializeObject<Point?>(input, new JsonPointConverter());

            Assert.IsNull(output);
        }

        /// <summary>The json point converter_ read more than two values_ converter throws json serialization exception.</summary>
        [Test]
        [Category("Converters")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void JsonPointConverter_ReadMoreThanTwoValues_ConverterThrowsJsonSerializationException()
        {
            const string input = "[1,2,3]";
            JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());
        }

        /// <summary>The json point converter_ read negative extremes_ point reflects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadNegativeExtremes_PointReflectsInput()
        {
            const string input = "[-2147483648,-2147483648]";
            var expected = new Point(int.MinValue, int.MinValue);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ read negative values_ point refects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadNegativeValues_PointRefectsInput()
        {
            const string input = "[-1,-2]";
            var expected = new Point(-1, -2);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ read null_ returns default for value type.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadNull_ReturnsDefaultForValueType()
        {
            const string input = "null";
            Point expected = default(Point);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ read null_ returns null for nullable type.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadNull_ReturnsNullForNullableType()
        {
            const string input = "null";
            var output = JsonConvert.DeserializeObject<Point?>(input, new JsonPointConverter());

            Assert.IsNull(output);
        }

        /// <summary>The json point converter_ read positive extremes_ point reflects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadPositiveExtremes_PointReflectsInput()
        {
            const string input = "[2147483647,2147483647]";
            var expected = new Point(int.MaxValue, int.MaxValue);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ read positive values_ point refects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadPositiveValues_PointRefectsInput()
        {
            const string input = "[1,2]";
            var expected = new Point(1, 2);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ read single nil_ returns default.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadSingleNil_ReturnsDefault()
        {
            const string input = "[0]";
            Point expected = default(Point);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ read single value_ converter assumes value is x.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_ReadSingleValue_ConverterAssumesValueIsX()
        {
            const string input = "[1]";
            var expected = new Point(1, 0);
            var actual = JsonConvert.DeserializeObject<Point>(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ write default point_ json reflects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_WriteDefaultPoint_JsonReflectsInput()
        {
            const string expected = "[0,0]";
            Point input = default(Point);
            string actual = JsonConvert.SerializeObject(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ write negative extremes_ json reflects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_WriteNegativeExtremes_JsonReflectsInput()
        {
            const string expected = "[-2147483648,-2147483648]";
            var input = new Point(int.MinValue, int.MinValue);
            string actual = JsonConvert.SerializeObject(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ write negative values_ json reflects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_WriteNegativeValues_JsonReflectsInput()
        {
            const string expected = "[-1,-2]";
            var input = new Point(-1, -2);
            string actual = JsonConvert.SerializeObject(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ write positive extremes_ json reflects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_WritePositiveExtremes_JsonReflectsInput()
        {
            const string expected = "[2147483647,2147483647]";
            var input = new Point(int.MaxValue, int.MaxValue);
            string actual = JsonConvert.SerializeObject(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The json point converter_ write positive values_ json reflects input.</summary>
        [Test]
        [Category("Converters")]
        public void JsonPointConverter_WritePositiveValues_JsonReflectsInput()
        {
            const string expected = "[1,2]";
            var input = new Point(1, 2);
            string actual = JsonConvert.SerializeObject(input, new JsonPointConverter());

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}