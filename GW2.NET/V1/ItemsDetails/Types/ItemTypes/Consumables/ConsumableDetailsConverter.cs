// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends  from its
//   representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.Consumables
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.ItemsDetails.Types.ItemTypes.Consumables.ConsumableTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of a class that extends <see cref="ConsumableDetails" /> from its <see cref="System.String" />
    /// representation.</summary>
    public class ConsumableDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<ConsumableType, Type> KnownTypes = new Dictionary<ConsumableType, Type>();

        /// <summary>Initializes static members of the <see cref="ConsumableDetailsConverter" /> class.</summary>
        static ConsumableDetailsConverter()
        {
            KnownTypes.Add(ConsumableType.Unknown, typeof(UnknownConsumableDetails));
            KnownTypes.Add(ConsumableType.AppearanceChange, typeof(AppearanceChangeDetails));
            KnownTypes.Add(ConsumableType.Booze, typeof(BoozeDetails));
            KnownTypes.Add(ConsumableType.ContractNpc, typeof(ContractNpcDetails));
            KnownTypes.Add(ConsumableType.Food, typeof(FoodDetails));
            KnownTypes.Add(ConsumableType.Generic, typeof(GenericConsumableDetails));
            KnownTypes.Add(ConsumableType.Halloween, typeof(HalloweenConsumableDetails));
            KnownTypes.Add(ConsumableType.Immediate, typeof(ImmediateConsumableDetails));
            KnownTypes.Add(ConsumableType.Transmutation, typeof(TransmutationDetails));
            KnownTypes.Add(ConsumableType.Unlock, typeof(UnlockDetails));
            KnownTypes.Add(ConsumableType.Utility, typeof(UtilityDetails));
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
            var jsonToken = content["type"];

            if (jsonToken == null)
            {
                return typeof(UnknownConsumableDetails);
            }

            var jsonValue = jsonToken.Value<string>();

            try
            {
                ConsumableType type;

                if (!Enum.TryParse(jsonValue, true, out type))
                {
                    type = JsonSerializer.Create().Deserialize<ConsumableType>(jsonToken.CreateReader());
                }

                Type targetType;

                if (!KnownTypes.TryGetValue(type, out targetType))
                {
                    return typeof(UnknownConsumableDetails);
                }

                return targetType;
            }
            catch (JsonSerializationException)
            {
                return typeof(UnknownConsumableDetails);
            }
            finally
            {
                content.Remove("type");
            }
        }
    }
}