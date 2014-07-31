// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an in-game item skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents an in-game item skin.</summary>
    public sealed class SkinContract : ServiceContract
    {
        /// <summary>Gets or sets the armor skin details.</summary>
        [DataMember(Name = "armor", Order = 8)]
        public ArmorSkinContract Armor { get; set; }

        /// <summary>Gets or sets the skin's description.</summary>
        [DataMember(Name = "description", Order = 7)]
        public string Description { get; set; }

        /// <summary>Gets or sets the skin's additional flags.</summary>
        [DataMember(Name = "flags", Order = 3)]
        public ICollection<string> Flags { get; set; }

        /// <summary>Gets or sets the skin's icon identifier for use with the render service.</summary>
        [DataMember(Name = "icon_file_id", Order = 5)]
        public string IconFileId { get; set; }

        /// <summary>Gets or sets the skin's icon signature for use with the render service.</summary>
        [DataMember(Name = "icon_file_signature", Order = 6)]
        public string IconFileSignature { get; set; }

        /// <summary>Gets or sets the name of the skin.</summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets the skin's restrictions.</summary>
        [DataMember(Name = "restrictions", Order = 4)]
        public ICollection<string> Restrictions { get; set; }

        /// <summary>Gets or sets the skin identifier.</summary>
        [DataMember(Name = "skin_id", Order = 0)]
        public string SkinId { get; set; }

        /// <summary>Gets or sets the skin type.</summary>
        [DataMember(Name = "type", Order = 2)]
        public string Type { get; set; }

        /// <summary>Gets or sets the weapon skin details.</summary>
        [DataMember(Name = "weapon", Order = 9)]
        public WeaponSkinContract Weapon { get; set; }
    }
}