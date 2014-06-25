// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringEnumFlagsConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts a bit flag <see cref="Enum" /> to and from a JSON string array.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common.Converters
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts a bit flag <see cref="Enum" /> to and from a JSON string array.</summary>
    public sealed class StringEnumFlagsConverter : StringEnumConverter
    {
        /// <summary>Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter"/> can read JSON.</summary>
        /// <value><c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter"/> can read JSON; otherwise, <c>false</c>.</value>
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter"/> can write JSON.</summary>
        /// <value><c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter"/> can write JSON; otherwise, <c>false</c>.</value>
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum && objectType.GetCustomAttributes(typeof(FlagsAttribute), false).Any();
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var values = serializer.Deserialize<string[]>(reader);
            if (values == null || !values.Any())
            {
                return existingValue;
            }

            var flags = string.Join(",", values);
            var jsonFlags = JValue.CreateString(flags);
            var valueReader = jsonFlags.CreateReader();
            valueReader.Read();
            return base.ReadJson(valueReader, objectType, existingValue, serializer);
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null || (int)value == 0)
            {
                writer.WriteStartArray();
                writer.WriteEndArray();
                return;
            }

            var enumType = value.GetType();
            var values = value.ToString().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            writer.WriteStartArray();
            foreach (var item in values)
            {
                base.WriteJson(writer, Enum.Parse(enumType, item, true), serializer);
            }

            writer.WriteEndArray();
        }
    }
}