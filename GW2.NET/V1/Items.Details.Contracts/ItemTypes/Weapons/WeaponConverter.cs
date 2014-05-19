// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of <see cref="Weapon" /> from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons.WeaponTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of <see cref="Weapon" /> from its <see cref="System.String" /> representation.</summary>
    public class WeaponConverter : JsonConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<WeaponType, Type> KnownTypes = new Dictionary<WeaponType, Type>();

        /// <summary>Initializes static members of the <see cref="WeaponConverter" /> class.</summary>
        static WeaponConverter()
        {
            KnownTypes.Add(WeaponType.Unknown, typeof(UnknownWeapon));
            KnownTypes.Add(WeaponType.Axe, typeof(Axe));
            KnownTypes.Add(WeaponType.Dagger, typeof(Dagger));
            KnownTypes.Add(WeaponType.Focus, typeof(Focus));
            KnownTypes.Add(WeaponType.GreatSword, typeof(GreatSword));
            KnownTypes.Add(WeaponType.Hammer, typeof(Hammer));
            KnownTypes.Add(WeaponType.Harpoon, typeof(Harpoon));
            KnownTypes.Add(WeaponType.LargeBundle, typeof(LargeBundle));
            KnownTypes.Add(WeaponType.LongBow, typeof(LongBow));
            KnownTypes.Add(WeaponType.Mace, typeof(Mace));
            KnownTypes.Add(WeaponType.Pistol, typeof(Pistol));
            KnownTypes.Add(WeaponType.Rifle, typeof(Rifle));
            KnownTypes.Add(WeaponType.Scepter, typeof(Scepter));
            KnownTypes.Add(WeaponType.Shield, typeof(Shield));
            KnownTypes.Add(WeaponType.ShortBow, typeof(ShortBow));
            KnownTypes.Add(WeaponType.SpearGun, typeof(SpearGun));
            KnownTypes.Add(WeaponType.Staff, typeof(Staff));
            KnownTypes.Add(WeaponType.Sword, typeof(Sword));
            KnownTypes.Add(WeaponType.Torch, typeof(Torch));
            KnownTypes.Add(WeaponType.Toy, typeof(ToyWeapon));
            KnownTypes.Add(WeaponType.Trident, typeof(Trident));
            KnownTypes.Add(WeaponType.TwoHandedToy, typeof(TwoHandedToyWeapon));
            KnownTypes.Add(WeaponType.Warhorn, typeof(WarHornWeapon));
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
            return typeof(Weapon).IsAssignableFrom(objectType);
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

            var details = content.Property("weapon");

            var detailsType = details == null ? content.Property("weapon_type") : ((JObject)details.Value).Property("type");

            var type = detailsType.Value.Value<string>();

            Type itemType;

            try
            {
                WeaponType weaponType;

                if (!Enum.TryParse(type, true, out weaponType))
                {
                    weaponType = JsonSerializer.Create().Deserialize<WeaponType>(detailsType.CreateReader());
                }

                if (!KnownTypes.TryGetValue(weaponType, out itemType))
                {
                    itemType = typeof(UnknownWeapon);
                }
            }
            catch (JsonSerializationException)
            {
                itemType = typeof(UnknownWeapon);
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