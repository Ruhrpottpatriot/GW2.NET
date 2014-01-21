// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Point3DConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2DotNET.V1.Core.Drawing;
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
            return objectType == typeof(Point3D);
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
            var points = serializer.Deserialize<double[]>(reader);
            return new Point3D(points[0], points[1], points[2]);
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
            if (value is Point3D)
            {
                var point3D = (Point3D)value;
                if ((point3D.X % 1D) == 0D)
                {
                    serializer.Serialize(writer, (int)point3D.X);
                }
                else
                {
                    serializer.Serialize(writer, point3D.X);
                }

                if ((point3D.Y % 1D) == 0D)
                {
                    serializer.Serialize(writer, (int)point3D.Y);
                }
                else
                {
                    serializer.Serialize(writer, point3D.Y);
                }

                if ((point3D.Z % 1D) == 0D)
                {
                    serializer.Serialize(writer, (int)point3D.Z);
                }
                else
                {
                    serializer.Serialize(writer, point3D.Z);
                }
            }

            writer.WriteEndArray();
        }
    }
}