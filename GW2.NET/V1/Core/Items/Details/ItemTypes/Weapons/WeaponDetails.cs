// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Weapons
{
    using GW2DotNET.V1.Core.Items.Details.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a weapon.
    /// </summary>
    [JsonConverter(typeof(WeaponDetailsConverter))]
    public abstract class WeaponDetails : EquipmentDetails
    {
        /// <summary>Initializes a new instance of the <see cref="WeaponDetails"/> class.</summary>
        /// <param name="weaponType">The weapon's type.</param>
        protected WeaponDetails(WeaponType weaponType)
        {
            this.Type = weaponType;
        }

        /// <summary>
        ///     Gets or sets the weapon's damage type.
        /// </summary>
        [JsonProperty("damage_type", Order = 1)]
        public WeaponDamageType DamageType { get; set; }

        /// <summary>
        ///     Gets or sets the weapon's defense.
        /// </summary>
        [JsonProperty("defense", Order = 4)]
        public int Defense { get; set; }

        /// <summary>
        ///     Gets or sets the weapon's maximum power.
        /// </summary>
        [JsonProperty("max_power", Order = 3)]
        public int MaximumPower { get; set; }

        /// <summary>
        ///     Gets or sets the weapon's minimum power.
        /// </summary>
        [JsonProperty("min_power", Order = 2)]
        public int MinimumPower { get; set; }

        /// <summary>
        ///     Gets or sets the weapon's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public WeaponType Type { get; set; }
    }
}