// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.Weapons
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a weapon.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Weapon : Item
    {
        /// <summary>Infrastructure. Stores the item details.</summary>
        private WeaponDetails details;

        /// <summary>Initializes a new instance of the <see cref="Weapon" /> class.</summary>
        public Weapon()
            : base(ItemType.Weapon)
        {
        }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin", Order = 100)]
        public int DefaultSkin { get; set; }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "weapon", Order = 101)]
        public WeaponDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.Weapon = this;
            }
        }
    }
}