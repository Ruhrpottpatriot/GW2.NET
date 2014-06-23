// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonPointFConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts a <see cref="PointF" /> to and from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common.Converters
{
    using System;
    using System.Drawing;

    using GW2DotNET.Extensions;

    using Newtonsoft.Json;

    /// <summary>Converts a <see cref="PointF" /> to and from its <see cref="System.String" /> representation.</summary>
    public class JsonPointFConverter : JsonConverter
    {
        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(PointF?).IsAssignableFrom(objectType);
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

            var values = serializer.Deserialize<float[]>(reader);
            if (values.Length != 2)
            {
                throw new JsonSerializationException("Invalid point coordinates.");
            }

            return new PointF(x: values[0], y: values[1]);
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var point = (PointF)value;
            writer.WriteStartArray();
            serializer.Serialize(writer, Math.Round(point.X, 2));
            serializer.Serialize(writer, Math.Round(point.Y, 2));
            writer.WriteEndArray();
        }
    }
}