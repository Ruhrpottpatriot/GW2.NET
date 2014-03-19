// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GizmoDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends  from its
//   representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Gizmos
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Core.Common.Converters;
    using GW2DotNET.V1.Core.Items.Details.ItemTypes.Gizmos.GizmoTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of a class that extends <see cref="GizmoDetails" /> from its <see cref="System.String" />
    /// representation.</summary>
    public class GizmoDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<GizmoType, Type> KnownTypes = new Dictionary<GizmoType, Type>();

        /// <summary>Initializes static members of the <see cref="GizmoDetailsConverter" /> class.</summary>
        static GizmoDetailsConverter()
        {
            KnownTypes.Add(GizmoType.Unknown, typeof(UnknownGizmoDetails));
            KnownTypes.Add(GizmoType.Default, typeof(DefaultGizmoDetails));
            KnownTypes.Add(GizmoType.RentableContractNpc, typeof(RentableContractNpcDetails));
            KnownTypes.Add(GizmoType.UnlimitedConsumable, typeof(UnlimitedConsumableDetails));
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">locationType of the object.</param>
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
                return typeof(UnknownGizmoDetails);
            }

            var jsonValue = jsonToken.Value<string>();

            try
            {
                GizmoType type;

                if (!Enum.TryParse(jsonValue, true, out type))
                {
                    type = JsonSerializer.Create().Deserialize<GizmoType>(jsonToken.CreateReader());
                }

                Type targetType;

                if (!KnownTypes.TryGetValue(type, out targetType))
                {
                    return typeof(UnknownGizmoDetails);
                }

                return targetType;
            }
            catch (JsonSerializationException)
            {
                return typeof(UnknownGizmoDetails);
            }
            finally
            {
                content.Remove("type");
            }
        }
    }
}