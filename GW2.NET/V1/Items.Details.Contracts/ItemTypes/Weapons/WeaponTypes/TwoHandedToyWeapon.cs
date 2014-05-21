// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TwoHandedToyWeapon.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a two-handed toy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons.WeaponTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a two-handed toy.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class TwoHandedToyWeapon : Weapon
    {
        /// <summary>Initializes a new instance of the <see cref="TwoHandedToyWeapon" /> class.</summary>
        public TwoHandedToyWeapon()
            : base(WeaponType.TwoHandedToy)
        {
        }
    }
}