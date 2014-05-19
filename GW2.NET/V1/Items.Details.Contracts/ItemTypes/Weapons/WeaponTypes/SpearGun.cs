// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpearGun.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a spear gun.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons.WeaponTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a spear gun.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class SpearGun : Weapon
    {
        /// <summary>Initializes a new instance of the <see cref="SpearGun" /> class.</summary>
        public SpearGun()
            : base(WeaponType.SpearGun)
        {
        }
    }
}