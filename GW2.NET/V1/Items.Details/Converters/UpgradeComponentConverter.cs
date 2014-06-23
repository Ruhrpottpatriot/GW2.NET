// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of <see cref="UpgradeComponent" /> from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents.UpgradeComponentTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of <see cref="UpgradeComponent" /> from its <see cref="System.String" /> representation.</summary>
    public class UpgradeComponentConverter : JsonConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<UpgradeComponentType, Type> KnownTypes = new Dictionary<UpgradeComponentType, Type>();

        /// <summary>Initializes static members of the <see cref="UpgradeComponentConverter" /> class.</summary>
        static UpgradeComponentConverter()
        {
            KnownTypes.Add(UpgradeComponentType.Unknown, typeof(UnknownUpgradeComponent));
            KnownTypes.Add(UpgradeComponentType.Default, typeof(DefaultUpgradeComponent));
            KnownTypes.Add(UpgradeComponentType.Gem, typeof(Gem));
            KnownTypes.Add(UpgradeComponentType.Rune, typeof(Rune));
            KnownTypes.Add(UpgradeComponentType.Sigil, typeof(Sigil));
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
            return typeof(UpgradeComponent) == objectType;
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

            var details = content["upgrade_component"] as JObject;

            var detailsType = details == null ? content.Property("upgrade_component_type") : details.Property("type");

            var type = detailsType.Value.Value<string>();

            Type itemType;

            try
            {
                UpgradeComponentType upgradeComponentType;

                if (!Enum.TryParse(type, true, out upgradeComponentType))
                {
                    upgradeComponentType = JsonSerializer.Create().Deserialize<UpgradeComponentType>(detailsType.CreateReader());
                }

                if (!KnownTypes.TryGetValue(upgradeComponentType, out itemType))
                {
                    itemType = typeof(UnknownUpgradeComponent);
                }
            }
            catch (JsonSerializationException)
            {
                itemType = typeof(UnknownUpgradeComponent);
            }
            finally
            {
                detailsType.Remove();
            }

            if (details != null)
            {
                // patch duplicate property
                details.Property("flags").Replace(new JProperty("upgrade_component_flags", details.Property("flags").Value));
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