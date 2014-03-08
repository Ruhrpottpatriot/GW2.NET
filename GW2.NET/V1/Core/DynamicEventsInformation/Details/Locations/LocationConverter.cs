// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations
{
    /// <summary>
    ///     Converts an instance of a class that extends <see cref="Location" /> from its <see cref="System.String" />
    ///     representation.
    /// </summary>
    public class LocationConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        ///     Backing field. Holds a dictionary of known JSON values and their corresponding type.
        /// </summary>
        private static readonly IDictionary<LocationType, Type> KnownTypes = new Dictionary<LocationType, Type>();

        /// <summary>
        ///     Initializes static members of the <see cref="LocationConverter" /> class.
        /// </summary>
        static LocationConverter()
        {
            KnownTypes.Add(LocationType.Unknown, typeof(UnknownLocation));
            KnownTypes.Add(LocationType.Sphere, typeof(SphereLocation));
            KnownTypes.Add(LocationType.Cylinder, typeof(CylinderLocation));
            KnownTypes.Add(LocationType.Polygon, typeof(PolygonLocation));
        }

        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return KnownTypes.Values.Contains(objectType);
        }

        /// <summary>
        ///     Gets the object type that will be used by the serializer.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        public override Type GetTargetType(Type objectType, JObject content)
        {
            if (content["type"] == null)
            {
                return typeof(UnknownLocation);
            }

            var jsonValue = JsonSerializer.Create().Deserialize<LocationType>(content["type"].CreateReader());

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownLocation);
            }

            return targetType;
        }
    }
}