// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents a weapon.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Weapon : SkinnedItem
    {
        /// <summary>Initializes a new instance of the <see cref="Weapon" /> class.</summary>
        public Weapon()
            : base(ItemType.Weapon)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "weapon", Order = 1000)]
        [JsonConverter(typeof(WeaponDetailsConverter))]
        public new WeaponDetails Details
        {
            get
            {
                return base.Details as WeaponDetails;
            }

            set
            {
                base.Details = value;
            }
        }
    }
}