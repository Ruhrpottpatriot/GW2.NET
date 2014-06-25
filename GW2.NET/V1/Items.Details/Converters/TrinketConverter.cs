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
    using System.Linq;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Items.Details.Contracts.Trinkets;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an object to and/or from JSON.</summary>
    public class TrinketConverter : TypeDiscriminatorConverter<Trinket>
    {
        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Read the entire JSON object into memory
            var content = JObject.Load(reader);

            // Get the type discriminator
            var detailsProperty = content.Property("trinket");
            var typeProperty = detailsProperty.Value.Value<JObject>().Property("type");
            var discriminator = typeProperty.Value.ToString();

            // Remove the type discriminator from the JSON object
            typeProperty.Remove();

            // Get a corresponding System.Type
            Type type;
            type = this.KnownTypes.TryGetValue(discriminator, out type) ? type : typeof(UnknownTrinket);

            // Try to hand over execution to a more specific converter
            var converter = serializer.Converters.FirstOrDefault(jsonConverter => jsonConverter.CanConvert(type));
            if (converter != null)
            {
                // Let the other converter deserialize the result
                return converter.ReadJson(content.CreateReader(), type, existingValue, serializer);
            }

            // Flatten the 'trinket' values
            detailsProperty.Remove();

            // Flatten the 'infix_upgrade' values (if any)
            var infixProperty = detailsProperty.Value.Value<JObject>().Property("infix_upgrade");
            if (infixProperty != null)
            {
                infixProperty.Remove();
            }

            // Deserialize the result
            var result = serializer.Deserialize(content.CreateReader(), type);
            serializer.Populate(detailsProperty.Value.CreateReader(), result);
            if (infixProperty != null)
            {
                serializer.Populate(infixProperty.Value.CreateReader(), result);
            }

            return result;
        }
    }
}