// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponDetailsConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends  from its
//   representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Weapons
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Core.Common.Converters;
    using GW2DotNET.V1.Core.Items.Details.ItemTypes.Weapons.WeaponTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of a class that extends <see cref="WeaponDetails" /> from its <see cref="System.String" />
    /// representation.</summary>
    public class WeaponDetailsConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<WeaponType, Type> KnownTypes = new Dictionary<WeaponType, Type>();

        /// <summary>Initializes static members of the <see cref="WeaponDetailsConverter" /> class.</summary>
        static WeaponDetailsConverter()
        {
            KnownTypes.Add(WeaponType.Unknown, typeof(UnknownWeaponDetails));
            KnownTypes.Add(WeaponType.Axe, typeof(AxeDetails));
            KnownTypes.Add(WeaponType.Dagger, typeof(DaggerDetails));
            KnownTypes.Add(WeaponType.Focus, typeof(FocusDetails));
            KnownTypes.Add(WeaponType.GreatSword, typeof(GreatSwordDetails));
            KnownTypes.Add(WeaponType.Hammer, typeof(HammerDetails));
            KnownTypes.Add(WeaponType.Harpoon, typeof(HarpoonDetails));
            KnownTypes.Add(WeaponType.LargeBundle, typeof(LargeBundleDetails));
            KnownTypes.Add(WeaponType.LongBow, typeof(LongBowDetails));
            KnownTypes.Add(WeaponType.Mace, typeof(MaceDetails));
            KnownTypes.Add(WeaponType.Pistol, typeof(PistolDetails));
            KnownTypes.Add(WeaponType.Rifle, typeof(RifleDetails));
            KnownTypes.Add(WeaponType.Scepter, typeof(ScepterDetails));
            KnownTypes.Add(WeaponType.Shield, typeof(ShieldDetails));
            KnownTypes.Add(WeaponType.ShortBow, typeof(ShortBowDetails));
            KnownTypes.Add(WeaponType.SpearGun, typeof(SpearGunDetails));
            KnownTypes.Add(WeaponType.Staff, typeof(StaffDetails));
            KnownTypes.Add(WeaponType.Sword, typeof(SwordDetails));
            KnownTypes.Add(WeaponType.Torch, typeof(TorchDetails));
            KnownTypes.Add(WeaponType.Toy, typeof(ToyDetails));
            KnownTypes.Add(WeaponType.Trident, typeof(TridentDetails));
            KnownTypes.Add(WeaponType.TwoHandedToy, typeof(TwoHandedToyDetails));
            KnownTypes.Add(WeaponType.Warhorn, typeof(WarHornDetails));
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
        public override Type GetTargetType(Type objectType, JObject content)
        {
            if (content["type"] == null)
            {
                return typeof(UnknownWeaponDetails);
            }

            var jsonValue = JsonSerializer.Create().Deserialize<WeaponType>(content["type"].CreateReader());

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownWeaponDetails);
            }

            return targetType;
        }
    }
}