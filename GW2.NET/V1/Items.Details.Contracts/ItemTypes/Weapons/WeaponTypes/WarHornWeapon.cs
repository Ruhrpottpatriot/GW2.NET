// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarHornWeapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a war horn.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons.WeaponTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a war horn.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class WarHornWeapon : Weapon
    {
        /// <summary>Initializes a new instance of the <see cref="WarHornWeapon" /> class.</summary>
        public WarHornWeapon()
            : base(WeaponType.Warhorn)
        {
        }
    }
}