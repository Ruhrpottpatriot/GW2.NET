// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The bool converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>
    /// The boolean converter.
    /// </summary>
    internal class BooleanConverter : JsonConverter
    {
        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">
        /// The json writer to use.
        /// </param>
        /// <param name="value">
        /// The value to convert to a boolean value.
        /// </param>
        /// <param name="serializer">
        /// The serializer to use.
        /// </param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }

        /// <summary>
        /// The read json.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="existingValue">
        /// The existing value.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }

        /// <summary>
        /// Checks if the type can be converted to a boolean value
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <returns>
        /// True if the type can be converted to a boolean value, otherwise false.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
}