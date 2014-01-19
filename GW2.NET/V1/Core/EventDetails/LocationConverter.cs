// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.EventDetails
{
    /// <summary>
    /// Converts a <see cref="Location"/> to and from its <see cref="System.String"/> representation.
    /// </summary>
    public class LocationConverter : CustomCreationConverter<Location>
    {
        /// <summary>
        /// Backing field for the location type.
        /// </summary>
        /// <remarks>
        /// This field exists because of poor design on JSON.NET's part.
        /// The "Create()" method does not take any parameters other than the object type.
        /// </remarks>
        private string locationType;

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Location).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Creates the instance that will be populated by the serializer.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns an instance of a class that extends <see cref="Location"/>.</returns>
        public override Location Create(Type objectType)
        {
            if (string.Equals(this.locationType, "sphere", StringComparison.OrdinalIgnoreCase))
            {
                return new SphereLocation()
                    {
                        LocationType = Location.Shape.Sphere
                    };
            }

            if (string.Equals(this.locationType, "cylinder", StringComparison.OrdinalIgnoreCase))
            {
                return new CylinderLocation()
                {
                    LocationType = Location.Shape.Cylinder
                };
            }

            if (string.Equals(this.locationType, "poly", StringComparison.OrdinalIgnoreCase))
            {
                return new PolygonLocation()
                {
                    LocationType = Location.Shape.Polygon
                };
            }

            throw new NotImplementedException("Unknown location type: " + this.locationType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            this.locationType = (string)jsonObject["type"];

            return base.ReadJson(jsonObject.CreateReader(), objectType, existingValue, serializer);
        }
    }
}