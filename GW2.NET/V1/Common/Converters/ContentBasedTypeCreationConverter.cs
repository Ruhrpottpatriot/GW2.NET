// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentBasedTypeCreationConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Deserializes an instance of a specific type based on the content. This is useful for complex types with an inheritance tree, where the exact type of the JSON content is not known at compile time.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common.Converters
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Deserializes an instance of a specific type based on the content. This is useful for complex types with an inheritance tree, where the exact type of the JSON content is not known at compile time.</summary>
    public abstract class ContentBasedTypeCreationConverter : JsonConverter
    {
        /// <summary>Gets a value indicating whether this <see cref="JsonConverter" /> can write JSON.</summary>
        /// <value><c>true</c> if this <see cref="JsonConverter" /> can write JSON; otherwise, <c>false</c>.</value>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>Returns the object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JObject jsonObject = JObject.Load(reader);

            Type targetType = this.GetTargetType(objectType, jsonObject);

            return serializer.Deserialize(jsonObject.CreateReader(), targetType);
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the object type that will be used by the serializer.</summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        protected abstract Type GetTargetType(Type objectType, JObject content);
    }
}