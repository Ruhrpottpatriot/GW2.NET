// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Weapons
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a weapon skin.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class WeaponSkin : Skin
    {
        /// <summary>Infrastructure. Stores the skin details.</summary>
        private WeaponSkinDetails details;

        /// <summary>Initializes a new instance of the <see cref="WeaponSkin" /> class.</summary>
        public WeaponSkin()
            : base(SkinType.Weapon)
        {
        }

        /// <summary>Gets or sets the skin details.</summary>
        [DataMember(Name = "weapon", Order = 100)]
        public WeaponSkinDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.WeaponSkin = this;
            }
        }
    }
}