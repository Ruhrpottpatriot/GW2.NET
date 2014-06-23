// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends <see cref="Skin" /> from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Skins.Details.Contracts;
    using GW2DotNET.V1.Skins.Details.Contracts.SkinTypes;
    using GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Armors;
    using GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Backs;
    using GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Weapons;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of a class that extends <see cref="Skin" /> from its <see cref="System.String" /> representation.</summary>
    public class SkinConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<SkinType, Type> KnownTypes = new Dictionary<SkinType, Type>();

        /// <summary>Initializes static members of the <see cref="SkinConverter" /> class.</summary>
        static SkinConverter()
        {
            KnownTypes.Add(SkinType.Unknown, typeof(UnknownSkin));
            KnownTypes.Add(SkinType.Armor, typeof(ArmorSkin));
            KnownTypes.Add(SkinType.Back, typeof(BackSkin));
            KnownTypes.Add(SkinType.Weapon, typeof(WeaponSkin));
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Skin) == objectType;
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
                return typeof(UnknownSkin);
            }

            var jsonValue = jsonToken.Value<string>();

            try
            {
                SkinType type;

                if (!Enum.TryParse(jsonValue, true, out type))
                {
                    type = JsonSerializer.Create().Deserialize<SkinType>(jsonToken.CreateReader());
                }

                Type targetType;

                if (!KnownTypes.TryGetValue(type, out targetType))
                {
                    return typeof(UnknownSkin);
                }

                return targetType;
            }
            catch (JsonSerializationException)
            {
                return typeof(UnknownSkin);
            }
            finally
            {
                content.Remove("type");
            }
        }
    }
}