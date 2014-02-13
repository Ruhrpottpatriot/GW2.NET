// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RectangleConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Converters
{
    /// <summary>
    /// Converts a <see cref="Rectangle"/> to and from its <see cref="System.String"/> representation.
    /// </summary>
    public class RectangleConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Rectangle);
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
            int[][] corners = serializer.Deserialize<int[][]>(reader);

            int left = corners[0][0];

            int top = corners[0][1];

            int right = corners[1][0];

            int bottom = corners[1][1];

            return Rectangle.FromLTRB(left, top, right, bottom);
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartArray();

            if (value is Rectangle)
            {
                Rectangle rectangle = (Rectangle)value;

                writer.WriteStartArray();

                {
                    serializer.Serialize(writer, rectangle.Left);

                    serializer.Serialize(writer, rectangle.Top);
                }

                writer.WriteEndArray();

                writer.WriteStartArray();

                {
                    serializer.Serialize(writer, rectangle.Right);

                    serializer.Serialize(writer, rectangle.Bottom);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndArray();
        }
    }
}