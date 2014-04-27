// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonRectangleConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts a <see cref="Rectangle" /> to and from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common.Converters
{
    using System;
    using System.Drawing;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;

    using Newtonsoft.Json;

    /// <summary>Converts a <see cref="Rectangle" /> to and from its <see cref="System.String" /> representation.</summary>
    public class JsonRectangleConverter : JsonConverter
    {
        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Rectangle?).IsAssignableFrom(objectType);
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return objectType.CreateDefault();
            }

            var values = serializer.Deserialize<int[][]>(reader);

            try
            {
                Preconditions.EnsureExact(actualValue: values.Length, expectedValue: 2);
                Preconditions.EnsureInRange(values[0].Length, 0, 2);
                Preconditions.EnsureInRange(values[1].Length, 0, 2);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new JsonSerializationException("Bad coordinates.", exception);
            }

            int top, left, bottom, right;

            switch (values[0].Length)
            {
                case 2:
                    top = values[0][0];
                    left = values[0][1];
                    break;
                case 1:
                    top = left = values[0][0];
                    break;
                default:
                    top = left = default(int);
                    break;
            }

            switch (values[1].Length)
            {
                case 2:
                    bottom = values[1][0];
                    right = values[1][1];
                    break;
                case 1:
                    bottom = right = values[1][0];
                    break;
                default:
                    bottom = right = default(int);
                    break;
            }

            return Rectangle.FromLTRB(left, top, right, bottom);
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var rectangle = (Rectangle)value;

            writer.WriteStartArray();
            {
                writer.WriteStartArray();
                {
                    serializer.Serialize(writer, rectangle.Top);

                    serializer.Serialize(writer, rectangle.Left);
                }

                writer.WriteEndArray();

                writer.WriteStartArray();
                {
                    serializer.Serialize(writer, rectangle.Bottom);

                    serializer.Serialize(writer, rectangle.Right);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndArray();
        }
    }
}