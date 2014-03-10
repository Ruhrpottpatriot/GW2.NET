// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownWeaponDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an unknown weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Weapons.Unknown
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about an unknown weapon.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class UnknownWeaponDetails : WeaponDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnknownWeaponDetails" /> class.
        /// </summary>
        public UnknownWeaponDetails()
            : base(WeaponType.Unknown)
        {
        }
    }
}