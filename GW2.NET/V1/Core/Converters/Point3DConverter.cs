// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Point3DConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2DotNET.Extensions;
using GW2DotNET.V1.Core.Drawing;
using GW2DotNET.V1.Core.Utilities;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Converters
{
    /// <summary>
    /// Converts a <see cref="Point3D"/> to and from its <see cref="System.String"/> representation.
    /// </summary>
    public class Point3DConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Point3D?).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
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

            var values = serializer.Deserialize<double[]>(reader);

            try
            {
                Preconditions.EnsureExact(actualValue: values.Length, expectedValue: 3);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new JsonSerializationException("The input must specify exactly 3 dimensions.", exception);
            }

            var x      = values[0];
            var y      = values[1];
            var z      = values[2];

            return new Point3D(x, y, z);
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var point3D = (Point3D)value;

            writer.WriteStartArray();

            {
                serializer.Serialize(writer, point3D.X);

                serializer.Serialize(writer, point3D.Y);

                serializer.Serialize(writer, point3D.Z);
            }

            writer.WriteEndArray();
        }
    }
}