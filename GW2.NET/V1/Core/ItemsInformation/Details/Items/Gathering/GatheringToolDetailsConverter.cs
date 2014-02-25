// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringToolDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gathering.Foraging;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gathering.Logging;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gathering.Mining;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gathering.Unknown;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gathering
{
    /// <summary>
    /// Converts an instance of a class that extends <see cref="GatheringToolDetails"/> from its <see cref="System.String"/> representation.
    /// </summary>
    public class GatheringToolDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of known JSON values and their corresponding type.
        /// </summary>
        private static readonly IDictionary<GatheringToolType, Type> KnownTypes = new Dictionary<GatheringToolType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="GatheringToolDetailsConverter"/> class.
        /// </summary>
        static GatheringToolDetailsConverter()
        {
            KnownTypes.Add(GatheringToolType.Unknown, typeof(UnknownToolDetails));
            KnownTypes.Add(GatheringToolType.Foraging, typeof(ForagingToolDetails));
            KnownTypes.Add(GatheringToolType.Logging, typeof(LoggingToolDetails));
            KnownTypes.Add(GatheringToolType.Mining, typeof(MiningToolDetails));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">locationType of the object.</param>
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

            var jsonValue = JsonSerializer.Create().Deserialize<GatheringToolType>(content["type"].CreateReader());

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownToolDetails);
            }

            return targetType;
        }
    }
}