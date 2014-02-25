// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trinkets.Accessories;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trinkets.Amulets;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trinkets.Rings;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trinkets.Unknown;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trinkets
{
    /// <summary>
    /// Converts an instance of a class that extends <see cref="TrinketDetails"/> from its <see cref="System.String"/> representation.
    /// </summary>
    public class TrinketDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of known JSON values and their corresponding type.
        /// </summary>
        private static readonly IDictionary<TrinketType, Type> KnownTypes = new Dictionary<TrinketType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="TrinketDetailsConverter"/> class.
        /// </summary>
        static TrinketDetailsConverter()
        {
            KnownTypes.Add(TrinketType.Unknown, typeof(UnknownTrinketDetails));
            KnownTypes.Add(TrinketType.Accessory, typeof(AccessoryDetails));
            KnownTypes.Add(TrinketType.Amulet, typeof(AmuletDetails));
            KnownTypes.Add(TrinketType.Ring, typeof(RingDetails));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return KnownTypes.Values.Contains(objectType);
        }

        /// <summary>
        /// Gets the object type that will be used by the serializer.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        public override Type GetTargetType(Type objectType, JObject content)
        {
            if (content["type"] == null)
            {
                throw new JsonSerializationException(content.ToObject<ErrorResponse>().Text);
            }

            var jsonValue = JsonSerializer.Create().Deserialize<TrinketType>(content["type"].CreateReader());

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownTrinketDetails);
            }

            return targetType;
        }
    }
}