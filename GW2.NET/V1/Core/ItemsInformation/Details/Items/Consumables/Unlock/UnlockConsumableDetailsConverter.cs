// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockConsumableDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ErrorInformation;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock.BagSlots;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock.BankTabs;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock.CraftingRecipes;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock.Dyes;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock.Unknown;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock
{
    /// <summary>
    /// Converts an instance of a class that extends <see cref="UnlockConsumableDetails"/> from its <see cref="System.String"/> representation.
    /// </summary>
    public class UnlockConsumableDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of in-game unlock item types and their corresponding .NET class.
        /// </summary>
        private static readonly IDictionary<UnlockType, Type> KnownTypes = new Dictionary<UnlockType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="UnlockConsumableDetailsConverter"/> class.
        /// </summary>
        static UnlockConsumableDetailsConverter()
        {
            KnownTypes.Add(UnlockType.Unknown, typeof(UnknownUnlockConsumableDetails));
            KnownTypes.Add(UnlockType.BagSlot, typeof(BagSlotUnlockConsumableDetails));
            KnownTypes.Add(UnlockType.BankTab, typeof(BankTabUnlockConsumableDetails));
            KnownTypes.Add(UnlockType.CraftingRecipe, typeof(CraftingRecipeUnlockConsumableDetails));
            KnownTypes.Add(UnlockType.Dye, typeof(DyeUnlockConsumableDetails));
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
            if (content["unlock_type"] == null)
            {
                throw new JsonSerializationException(content.ToObject<ErrorResult>().Text);
            }

            var jsonValue = JsonSerializer.Create().Deserialize<UnlockType>(content["unlock_type"].CreateReader());

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownUnlockConsumableDetails);
            }

            return targetType;
        }
    }
}