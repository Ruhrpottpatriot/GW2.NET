// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends <see cref="ArmorDetails" /> from its <see cref="System.String" />
//   representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Core.Converters;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Boots;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Coats;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Gloves;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Helms;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Leggings;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Shoulders;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Unknown;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Converts an instance of a class that extends <see cref="ArmorDetails" /> from its <see cref="System.String" />
    ///     representation.
    /// </summary>
    public class ArmorDetailsConverter : ContentBasedTypeCreationConverter
    {
        #region Static Fields

        /// <summary>
        ///     Backing field. Holds a dictionary of known JSON values and their corresponding type.
        /// </summary>
        private static readonly IDictionary<ArmorType, Type> KnownTypes = new Dictionary<ArmorType, Type>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="ArmorDetailsConverter" /> class.
        /// </summary>
        static ArmorDetailsConverter()
        {
            KnownTypes.Add(ArmorType.Unknown, typeof(UnknownArmorDetails));
            KnownTypes.Add(ArmorType.Boots, typeof(BootsDetails));
            KnownTypes.Add(ArmorType.Coat, typeof(CoatDetails));
            KnownTypes.Add(ArmorType.Gloves, typeof(GlovesDetails));
            KnownTypes.Add(ArmorType.Helm, typeof(HelmDetails));
            KnownTypes.Add(ArmorType.HelmAquatic, typeof(AquaticHelmDetails));
            KnownTypes.Add(ArmorType.Leggings, typeof(LeggingsDetails));
            KnownTypes.Add(ArmorType.Shoulders, typeof(ShouldersDetails));
        }

        #endregion

        #region Public Methods and Operators

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
        public override Type GetTargetType(Type objectType, JObject content)
        {
            if (content["type"] == null)
            {
                return typeof(UnknownArmorDetails);
            }

            var jsonValue = JsonSerializer.Create().Deserialize<ArmorType>(content["type"].CreateReader());

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownArmorDetails);
            }

            return targetType;
        }

        #endregion
    }
}