// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Armors
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents an armor skin.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class ArmorSkin : Skin
    {
        /// <summary>Infrastructure. Stores the skin details.</summary>
        private ArmorSkinDetails details;

        /// <summary>Initializes a new instance of the <see cref="ArmorSkin" /> class.</summary>
        public ArmorSkin()
            : base(SkinType.Armor)
        {
        }

        /// <summary>Gets or sets the skin details.</summary>
        [DataMember(Name = "armor", Order = 100)]
        public ArmorSkinDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.ArmorSkin = this;
            }
        }
    }
}