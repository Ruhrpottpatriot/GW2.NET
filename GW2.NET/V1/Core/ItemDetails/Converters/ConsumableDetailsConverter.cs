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
    public class ConsumableDetailsConverter : ContentBasedTypeCreationConverter<ConsumableItemDetails>
    {
        /// <summary>
        /// Backing field. Holds a dictionary of in-game consumable item types and their corresponding .NET class.
        /// </summary>
        private static readonly IDictionary<ConsumableType, Type> ConsumableTypes = new Dictionary<ConsumableType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="ConsumableDetailsConverter"/> class.
        /// </summary>
        static ConsumableDetailsConverter()
        {
            ConsumableTypes.Add(ConsumableType.Unknown, typeof(UnknownConsumableItemDetails));
            ConsumableTypes.Add(ConsumableType.AppearanceChange, typeof(AppearanceChangeConsumableItemDetails));
            ConsumableTypes.Add(ConsumableType.Booze, typeof(BoozeItemDetails));
            ConsumableTypes.Add(ConsumableType.ContractNPC, typeof(ContractNPCConsumableItemDetails));
            ConsumableTypes.Add(ConsumableType.Food, typeof(FoodItemDetails));
            ConsumableTypes.Add(ConsumableType.Generic, typeof(GenericConsumableItemDetails));
            ConsumableTypes.Add(ConsumableType.Halloween, typeof(HalloweenConsumableItemDetails));
            ConsumableTypes.Add(ConsumableType.Immediate, typeof(ImmediateConsumableItemDetails));
            ConsumableTypes.Add(ConsumableType.Transmutation, typeof(TransmutationConsumableItemDetails));
            ConsumableTypes.Add(ConsumableType.Unlock, typeof(UnlockConsumableItemDetails));
            ConsumableTypes.Add(ConsumableType.Utility, typeof(UtilityConsumableItemDetails));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return ConsumableTypes.Values.Contains(objectType);
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

            ConsumableType jsonValue = JsonSerializer.Create().Deserialize<ConsumableType>(typeReader);

            Type itemType;

            if (!ConsumableTypes.TryGetValue(jsonValue, out itemType))
            {
                itemType = typeof(UnknownConsumableItemDetails);
            }

            return itemType;
        }
    }
}