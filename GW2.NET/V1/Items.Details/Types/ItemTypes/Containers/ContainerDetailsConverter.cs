// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends  from its
//   representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.Containers
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Types.ItemTypes.Containers.ContainerTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of a class that extends <see cref="ContainerDetails" /> from its <see cref="System.String" />
    /// representation.</summary>
    public class ContainerDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<ContainerType, Type> KnownTypes = new Dictionary<ContainerType, Type>();

        /// <summary>Initializes static members of the <see cref="ContainerDetailsConverter" /> class.</summary>
        static ContainerDetailsConverter()
        {
            KnownTypes.Add(ContainerType.Unknown, typeof(UnknownContainerDetails));
            KnownTypes.Add(ContainerType.Default, typeof(DefaultContainerDetails));
            KnownTypes.Add(ContainerType.GiftBox, typeof(GiftBoxDetails));
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
                return typeof(UnknownContainerDetails);
            }

            var jsonValue = jsonToken.Value<string>();

            try
            {
                ContainerType type;

                if (!Enum.TryParse(jsonValue, true, out type))
                {
                    type = JsonSerializer.Create().Deserialize<ContainerType>(jsonToken.CreateReader());
                }

                Type targetType;

                if (!KnownTypes.TryGetValue(type, out targetType))
                {
                    return typeof(UnknownContainerDetails);
                }

                return targetType;
            }
            catch (JsonSerializationException)
            {
                return typeof(UnknownContainerDetails);
            }
            finally
            {
                content.Remove("type");
            }
        }
    }
}