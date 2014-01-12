// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringEnumFlagsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Converters
{
    /// <summary>
    /// Converts a bit flag <see cref="Enum"/> to and from a string array of flag names.
    /// </summary>
    /// <typeparam name="TEnum">Type of the <see cref="Enum"/>.</typeparam>
    public class StringEnumFlagsConverter<TEnum> : JsonConverter where TEnum : struct, IConvertible
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringEnumFlagsConverter{TEnum}"/> class.
        /// </summary>
        public StringEnumFlagsConverter()
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentOutOfRangeException("TEnum", "Type parameter 'TEnum' must be an enumeration.");
            }
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TEnum);
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
            string[] enumNames = Enum.GetNames(objectType);
            Type underlyingType = Enum.GetUnderlyingType(objectType);
            try
            {
                Stack<string> individualFlags = new Stack<string>();
                do
                {
                    if (reader.TokenType == JsonToken.Null)
                    {
                        return existingValue;
                    }

                    if (reader.TokenType == JsonToken.String)
                    {
                        string enumText = reader.Value.ToString();
                        if (!enumNames.Contains(enumText, StringComparer.OrdinalIgnoreCase))
                        {
                            throw new JsonSerializationException(string.Format("Parameter '{0}' is not a valid flag", enumText));
                        }

                        individualFlags.Push(enumText);
                    }
                }
                while (reader.Read() && reader.TokenType != JsonToken.EndArray);

                string validFlags = string.Join(", ", individualFlags);
                if (validFlags.Any())
                {
                    return Enum.Parse(objectType, validFlags, true);
                }

                return existingValue;
            }
            catch (Exception exception)
            {
                throw new JsonSerializationException(exception.Message, exception);
            }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (((TEnum)value).ToInt32(null) == 0)
            {
                writer.WriteStartArray();
                writer.WriteEndArray();
                return;
            }

            var flags = value.ToString().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            writer.WriteStartArray();

            foreach (var flag in flags)
            {
                writer.WriteValue(flag);
            }

            writer.WriteEndArray();
        }
    }
}
