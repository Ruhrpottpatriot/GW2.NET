// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of <see cref="Trinket" /> from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets.TrinketTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of <see cref="Trinket" /> from its <see cref="System.String" /> representation.</summary>
    public class TrinketConverter : JsonConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<TrinketType, Type> KnownTypes = new Dictionary<TrinketType, Type>();

        /// <summary>Initializes static members of the <see cref="TrinketConverter" /> class.</summary>
        static TrinketConverter()
        {
            KnownTypes.Add(TrinketType.Unknown, typeof(UnknownTrinket));
            KnownTypes.Add(TrinketType.Accessory, typeof(Accessory));
            KnownTypes.Add(TrinketType.Amulet, typeof(Amulet));
            KnownTypes.Add(TrinketType.Ring, typeof(Ring));
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
            return typeof(Trinket) == objectType;
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

            var details = content.Property("trinket");

            var detailsType = details == null ? content.Property("trinket_type") : ((JObject)details.Value).Property("type");

            var type = detailsType.Value.Value<string>();

            Type itemType;

            try
            {
                TrinketType trinketType;

                if (!Enum.TryParse(type, true, out trinketType))
                {
                    trinketType = JsonSerializer.Create().Deserialize<TrinketType>(detailsType.CreateReader());
                }

                if (!KnownTypes.TryGetValue(trinketType, out itemType))
                {
                    itemType = typeof(UnknownTrinket);
                }
            }
            catch (JsonSerializationException)
            {
                itemType = typeof(UnknownTrinket);
            }
            finally
            {
                detailsType.Remove();
            }

            return serializer.Deserialize(content.CreateReader(), itemType);
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