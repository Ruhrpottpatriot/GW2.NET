// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.EventDetails.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.EventDetails
{
    /// <summary>
    /// Converts a <see cref="Location"/> to and from its <see cref="System.String"/> representation.
    /// </summary>
    public class LocationConverter : ContentBasedTypeCreationConverter<Location>
    {
        /// <summary>
        /// Backing field. Holds a dictionary of event location shapes and their corresponding .NET class.
        /// </summary>
        private static readonly IDictionary<LocationShape, Type> LocationTypes = new Dictionary<LocationShape, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="LocationConverter"/> class.
        /// </summary>
        static LocationConverter()
        {
            LocationTypes.Add(LocationShape.Sphere, typeof(SphereLocation));
            LocationTypes.Add(LocationShape.Cylinder, typeof(CylinderLocation));
            LocationTypes.Add(LocationShape.Polygon, typeof(PolygonLocation));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return LocationTypes.Values.Contains(objectType);
        }

        /// <summary>
        /// Gets the object type that will be used by the serializer.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        public override Type GetTargetType(Type objectType, JObject content)
        {
            var typeReader = content["type"].CreateReader();

            var locationShape = JsonSerializer.Create().Deserialize<LocationShape>(typeReader);

            Type locationType;

            if (!LocationTypes.TryGetValue(locationShape, out locationType))
            {
                throw new JsonSerializationException("Unknown location type: " + locationShape);
            }

            return locationType;
        }
    }
}