// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends  from its
//   representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes.UnlockTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of a class that extends <see cref="UnlockDetails" /> from its
    /// <see cref="System.String" /> representation.</summary>
    public class UnlockDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of in-game unlock item types and their corresponding .NET class.</summary>
        private static readonly IDictionary<UnlockType, Type> KnownTypes = new Dictionary<UnlockType, Type>();

        /// <summary>Initializes static members of the <see cref="UnlockDetailsConverter" /> class.</summary>
        static UnlockDetailsConverter()
        {
            KnownTypes.Add(UnlockType.Unknown, typeof(UnknownUnlockDetails));
            KnownTypes.Add(UnlockType.BagSlot, typeof(BagSlotUnlockDetails));
            KnownTypes.Add(UnlockType.BankTab, typeof(BankTabUnlockDetails));
            KnownTypes.Add(UnlockType.CraftingRecipe, typeof(CraftingRecipeUnlockDetails));
            KnownTypes.Add(UnlockType.Dye, typeof(DyeUnlockDetails));
            KnownTypes.Add(UnlockType.Content, typeof(ContentUnlockDetails));
            KnownTypes.Add(UnlockType.CollectibleCapacity, typeof(CollectibleCapacityUnlockDetails));
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return KnownTypes.Values.Contains(objectType);
        }

        /// <summary>Gets the object type that will be used by the serializer.</summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        protected override Type GetTargetType(Type objectType, JObject content)
        {
            var jsonToken = content["unlock_type"];

            if (jsonToken == null)
            {
                return typeof(UnknownUnlockDetails);
            }

            var jsonValue = jsonToken.Value<string>();

            try
            {
                UnlockType type;

                if (!Enum.TryParse(jsonValue, true, out type))
                {
                    type = JsonSerializer.Create().Deserialize<UnlockType>(jsonToken.CreateReader());
                }

                Type targetType;

                if (!KnownTypes.TryGetValue(type, out targetType))
                {
                    return typeof(UnknownUnlockDetails);
                }

                return targetType;
            }
            catch (JsonSerializationException)
            {
                return typeof(UnknownUnlockDetails);
            }
            finally
            {
                content.Remove("unlock_type");
            }
        }
    }
}