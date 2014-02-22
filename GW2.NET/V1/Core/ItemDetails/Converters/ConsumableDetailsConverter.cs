// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemDetails.Models.Consumables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemDetails.Converters
{
    /// <summary>
    /// Converts a JSON object that describes a consumable item's details to the <see cref="ConsumableItemDetails"/> class.
    /// </summary>
    public class ConsumableDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of in-game consumable item types and their corresponding .NET class.
        /// </summary>
        private static readonly IDictionary<ConsumableType, Type> KnownTypes = new Dictionary<ConsumableType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="ConsumableDetailsConverter"/> class.
        /// </summary>
        static ConsumableDetailsConverter()
        {
            KnownTypes.Add(ConsumableType.Unknown, typeof(UnknownConsumableItemDetails));
            KnownTypes.Add(ConsumableType.AppearanceChange, typeof(AppearanceChangeConsumableItemDetails));
            KnownTypes.Add(ConsumableType.Booze, typeof(BoozeItemDetails));
            KnownTypes.Add(ConsumableType.ContractNPC, typeof(ContractNPCConsumableItemDetails));
            KnownTypes.Add(ConsumableType.Food, typeof(FoodItemDetails));
            KnownTypes.Add(ConsumableType.Generic, typeof(GenericConsumableItemDetails));
            KnownTypes.Add(ConsumableType.Halloween, typeof(HalloweenConsumableItemDetails));
            KnownTypes.Add(ConsumableType.Immediate, typeof(ImmediateConsumableItemDetails));
            KnownTypes.Add(ConsumableType.Transmutation, typeof(TransmutationConsumableItemDetails));
            KnownTypes.Add(ConsumableType.Unlock, typeof(UnlockConsumableItemDetails));
            KnownTypes.Add(ConsumableType.Utility, typeof(UtilityConsumableItemDetails));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
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
            JsonReader typeReader = content["type"].CreateReader();

            var jsonValue = JsonSerializer.Create().Deserialize<ConsumableType>(typeReader);

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownConsumableItemDetails);
            }

            return targetType;
        }
    }
}