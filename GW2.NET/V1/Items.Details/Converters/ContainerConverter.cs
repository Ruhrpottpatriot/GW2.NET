// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of <see cref="Container" /> from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers.ContainerTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of <see cref="Container" /> from its <see cref="System.String" /> representation.</summary>
    public class ContainerConverter : JsonConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<ContainerType, Type> KnownTypes = new Dictionary<ContainerType, Type>();

        /// <summary>Initializes static members of the <see cref="ContainerConverter" /> class.</summary>
        static ContainerConverter()
        {
            KnownTypes.Add(ContainerType.Unknown, typeof(UnknownContainer));
            KnownTypes.Add(ContainerType.Default, typeof(DefaultContainer));
            KnownTypes.Add(ContainerType.GiftBox, typeof(GiftBox));
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Container) == objectType;
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

            var details = content.Property("container");

            var detailsType = details == null ? content.Property("container_type") : ((JObject)details.Value).Property("type");

            var type = detailsType.Value.Value<string>();

            Type itemType;

            try
            {
                ContainerType containerType;

                if (!Enum.TryParse(type, true, out containerType))
                {
                    containerType = JsonSerializer.Create().Deserialize<ContainerType>(detailsType.CreateReader());
                }

                if (!KnownTypes.TryGetValue(containerType, out itemType))
                {
                    itemType = typeof(UnknownContainer);
                }
            }
            catch (JsonSerializationException)
            {
                itemType = typeof(UnknownContainer);
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