// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringEnumFlagsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts a bit flag <see cref="Enum" /> to and from a string array of flag names.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts a bit flag <see cref="Enum" /> to and from a string array of flag names.</summary>
    public class StringEnumFlagsConverter : StringEnumConverter
    {
        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }

            var individualFlags = new Stack<string>();

            do
            {
                if (reader.TokenType == JsonToken.String)
                {
                    individualFlags.Push(reader.Value.ToString());
                }
            }
            while (reader.Read() && reader.TokenType != JsonToken.EndArray);

            if (individualFlags.Any())
            {
                string flags = string.Join(",", individualFlags);

                JValue jsonFlags = JValue.CreateString(flags);

                JsonReader valueReader = jsonFlags.CreateReader();

                if (valueReader.Read())
                {
                    return base.ReadJson(valueReader, objectType, existingValue, serializer);
                }
            }

            return existingValue;
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null || (int)value == 0)
            {
                this.WriteEmptyArray(writer);

                return;
            }

            Type enumType = value.GetType();

            string[] values = value.ToString().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            writer.WriteStartArray();

            foreach (string item in values)
            {
                base.WriteJson(writer, Enum.Parse(enumType, item, true), serializer);
            }

            writer.WriteEndArray();
        }

        /// <summary>Writes an opening and closing bracket.</summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        private void WriteEmptyArray(JsonWriter writer)
        {
            writer.WriteStartArray();

            writer.WriteEndArray();
        }
    }
}