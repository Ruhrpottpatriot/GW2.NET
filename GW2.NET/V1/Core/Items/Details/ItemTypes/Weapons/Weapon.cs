// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Weapons
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a weapon.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Weapon : Item
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Weapon" /> class.
        /// </summary>
        public Weapon()
            : base(ItemType.Weapon)
        {
        }

        /// <summary>
        ///     Gets or sets the weapon's details.
        /// </summary>
        [JsonProperty("weapon", Order = 100)]
        public WeaponDetails WeaponDetails { get; set; }
    }
}