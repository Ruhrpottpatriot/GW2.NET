// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends <see cref="Location" /> from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations;
    using GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations.LocationTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an object to and/or from JSON.</summary>
    public class LocationConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<LocationType, Type> KnownTypes = new Dictionary<LocationType, Type>();

        /// <summary>Initializes static members of the <see cref="LocationConverter" /> class.</summary>
        static LocationConverter()
        {
            KnownTypes.Add(LocationType.Unknown, typeof(UnknownLocation));
            KnownTypes.Add(LocationType.Sphere, typeof(SphereLocation));
            KnownTypes.Add(LocationType.Cylinder, typeof(CylinderLocation));
            KnownTypes.Add(LocationType.Polygon, typeof(PolygonLocation));
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Location) == objectType;
        }

        /// <summary>Gets the object type that will be used by the serializer.</summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        protected override Type GetTargetType(Type objectType, JObject content)
        {
            var jsonToken = content["type"];

            if (jsonToken == null)
            {
                return typeof(UnknownLocation);
            }

            var jsonValue = jsonToken.Value<string>();

            try
            {
                LocationType type;

                if (!Enum.TryParse(jsonValue, true, out type))
                {
                    type = JsonSerializer.Create().Deserialize<LocationType>(jsonToken.CreateReader());
                }

                Type targetType;

                if (!KnownTypes.TryGetValue(type, out targetType))
                {
                    return typeof(UnknownLocation);
                }

                return targetType;
            }
            catch (JsonSerializationException)
            {
                return typeof(UnknownLocation);
            }
            finally
            {
                content.Remove("type");
            }
        }
    }
}