// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.AppearanceChange;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Booze;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.ContractNpc;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Food;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Generic;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Halloween;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Immediate;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Transmutation;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unknown;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables
{
    /// <summary>
    /// Converts an instance of a class that extends <see cref="ConsumableDetails"/> from its <see cref="System.String"/> representation.
    /// </summary>
    public class ConsumableDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of known JSON values and their corresponding type.
        /// </summary>
        private static readonly IDictionary<ConsumableType, Type> KnownTypes = new Dictionary<ConsumableType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="ConsumableDetailsConverter"/> class.
        /// </summary>
        static ConsumableDetailsConverter()
        {
            KnownTypes.Add(ConsumableType.Unknown, typeof(UnknownConsumableDetails));
            KnownTypes.Add(ConsumableType.AppearanceChange, typeof(AppearanceChangeConsumableDetails));
            KnownTypes.Add(ConsumableType.Booze, typeof(BoozeConsumableDetails));
            KnownTypes.Add(ConsumableType.ContractNpc, typeof(ContractNpcConsumableDetails));
            KnownTypes.Add(ConsumableType.Food, typeof(FoodConsumableDetails));
            KnownTypes.Add(ConsumableType.Generic, typeof(GenericConsumableDetails));
            KnownTypes.Add(ConsumableType.Halloween, typeof(HalloweenConsumableDetails));
            KnownTypes.Add(ConsumableType.Immediate, typeof(ImmediateConsumableDetails));
            KnownTypes.Add(ConsumableType.Transmutation, typeof(TransmutationConsumableDetails));
            KnownTypes.Add(ConsumableType.Unlock, typeof(UnlockConsumableDetails));
            KnownTypes.Add(ConsumableType.Utility, typeof(UtilityConsumableDetails));
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

            var jsonValue = JsonSerializer.Create().Deserialize<ConsumableType>(content["type"].CreateReader());

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownConsumableDetails);
            }

            return targetType;
        }
    }
}