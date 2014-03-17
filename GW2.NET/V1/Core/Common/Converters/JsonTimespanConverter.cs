// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonTimespanConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts a timespan to and from its  representation in milliseconds.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Common.Converters
{
    using System;

    using GW2DotNET.Extensions;

    using Newtonsoft.Json;

    /// <summary>Converts a timespan to and from its <see cref="System.String" /> representation in milliseconds.</summary>
    public class JsonTimespanConverter : JsonConverter
    {
        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(TimeSpan?).IsAssignableFrom(objectType);
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

            var milliseconds = serializer.Deserialize<double>(reader);

            return TimeSpan.FromMilliseconds(milliseconds);
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var timeSpan = (TimeSpan)value;

            serializer.Serialize(writer, timeSpan.TotalMilliseconds);
        }
    }
}