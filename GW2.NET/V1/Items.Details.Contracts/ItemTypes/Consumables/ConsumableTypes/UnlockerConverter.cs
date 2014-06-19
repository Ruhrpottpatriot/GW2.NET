// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockerConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of <see cref="Unlocker" /> from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes.UnlockTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of <see cref="Unlocker" /> from its <see cref="System.String" /> representation.</summary>
    public class UnlockerConverter : JsonConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<UnlockType, Type> KnownTypes = new Dictionary<UnlockType, Type>();

        /// <summary>Initializes static members of the <see cref="UnlockerConverter"/> class.</summary>
        static UnlockerConverter()
        {
            KnownTypes.Add(UnlockType.Unknown, typeof(UnknownUnlocker));
            KnownTypes.Add(UnlockType.BagSlot, typeof(BagSlotUnlocker));
            KnownTypes.Add(UnlockType.BankTab, typeof(BankTabUnlocker));
            KnownTypes.Add(UnlockType.CraftingRecipe, typeof(CraftingRecipeUnlocker));
            KnownTypes.Add(UnlockType.Dye, typeof(DyeUnlocker));
            KnownTypes.Add(UnlockType.Content, typeof(ContentUnlocker));
            KnownTypes.Add(UnlockType.CollectibleCapacity, typeof(CollectibleCapacityUnlocker));
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter"/> can write JSON.
        /// </summary>
        /// <value>
        /// <c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter"/> can write JSON; otherwise, <c>false</c>.
        /// </value>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Unlocker).IsAssignableFrom(objectType);
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var content = JObject.Load(reader);

            var details = content.Property("consumable");

            var detailsType = details == null ? content.Property("unlock_type") : ((JObject)details.Value).Property("unlock_type");

            var type = detailsType.Value.Value<string>();

            Type itemType;

            try
            {
                UnlockType unlockType;

                if (!Enum.TryParse(type, true, out unlockType))
                {
                    unlockType = JsonSerializer.Create().Deserialize<UnlockType>(detailsType.CreateReader());
                }

                if (!KnownTypes.TryGetValue(unlockType, out itemType))
                {
                    itemType = typeof(UnknownUnlocker);
                }
            }
            catch (JsonSerializationException)
            {
                itemType = typeof(UnknownUnlocker);
            }
            finally
            {
                detailsType.Remove();
            }

            var item = serializer.Deserialize(content.CreateReader(), itemType);

            return item;
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException();
        }
    }
}