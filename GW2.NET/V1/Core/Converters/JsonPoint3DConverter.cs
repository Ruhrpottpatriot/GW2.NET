// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonPoint3DConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts a <see cref="Point3D" /> to and from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.Converters
{
    using System;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Core.Drawing;

    using Newtonsoft.Json;

    /// <summary>
    ///     Converts a <see cref="Point3D" /> to and from its <see cref="System.String" /> representation.
    /// </summary>
    public class JsonPoint3DConverter : JsonConverter
    {
        #region Public Methods and Operators

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Point3D?).IsAssignableFrom(objectType);
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

            var values = serializer.Deserialize<double[]>(reader);

            try
            {
                Preconditions.EnsureInRange(values.Length, 0, 3);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new JsonSerializationException("The input specifies more than 3 values.", exception);
            }

            double y = default(double), z = default(double);

            switch (values.Length)
            {
                case 3:
                    z = values[2];
                    goto case 2;
                case 2:
                    y = values[1];
                    goto case 1;
                case 1:
                    double x = values[0];
                    return new Point3D(x, y, z);
                default:
                    return default(Point3D);
            }
        }

        /// <summary>Writes the JSON representation of the object.</summary>
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

        #endregion
    }
}