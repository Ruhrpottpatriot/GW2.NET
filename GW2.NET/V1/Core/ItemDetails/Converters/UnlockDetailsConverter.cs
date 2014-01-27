// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockDetailsConverter.cs" company="GW2.Net Coding Team">
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
    /// Converts a JSON object that describes a consumable item's details to the <see cref="ConsumableDetails"/> class.
    /// </summary>
    public class UnlockDetailsConverter : ContentBasedTypeCreationConverter<UnlockConsumableDetails>
    {
        /// <summary>
        /// Backing field. Holds a dictionary of in-game unlock item types and their corresponding .NET class.
        /// </summary>
        private static readonly IDictionary<UnlockType, Type> UnlockTypes = new Dictionary<UnlockType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="UnlockDetailsConverter"/> class.
        /// </summary>
        static UnlockDetailsConverter()
        {
            UnlockTypes.Add(UnlockType.Unknown, typeof(UnknownUnlockConsumableDetails));
            UnlockTypes.Add(UnlockType.BagSlot, typeof(BagSlotUnlockConsumableDetails));
            UnlockTypes.Add(UnlockType.BankTab, typeof(BankTabUnlockConsumableDetails));
            UnlockTypes.Add(UnlockType.CraftingRecipe, typeof(CraftingRecipeUnlockConsumableDetails));
            UnlockTypes.Add(UnlockType.Dye, typeof(DyeUnlockConsumableDetails));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return UnlockTypes.Values.Contains(objectType);
        }

        /// <summary>
        /// Gets the object type that will be used by the serializer.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        public override Type GetTargetType(Type objectType, JObject content)
        {
            var typeReader = content["unlock_type"].CreateReader();

            var jsonValue = JsonSerializer.Create().Deserialize<UnlockType>(typeReader);

            Type itemType;

            if (!UnlockTypes.TryGetValue(jsonValue, out itemType))
            {
                itemType = typeof(UnknownUnlockConsumableDetails);
            }

            return itemType;
        }
    }
}