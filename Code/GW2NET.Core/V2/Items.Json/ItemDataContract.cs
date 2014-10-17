// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The item data contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>The item data contract.</summary>
    [DataContract]
    internal sealed class ItemDataContract
    {
        /// <summary>Gets or sets the default skin.</summary>
        [DataMember(Order = 5, Name = "default_skin")]
        internal string DefaultSkin { get; set; }

        /// <summary>Gets or sets the description.</summary>
        [DataMember(Order = 1, Name = "description")]
        internal string Description { get; set; }

        /// <summary>Gets or sets the details.</summary>
        [DataMember(Order = 12, Name = "details")]
        internal DetailsDataContract Details { get; set; }

        /// <summary>Gets or sets the flags.</summary>
        [DataMember(Order = 8, Name = "flags")]
        internal ICollection<string> Flags { get; set; }

        /// <summary>Gets or sets the game types.</summary>
        [DataMember(Order = 7, Name = "game_types")]
        internal ICollection<string> GameTypes { get; set; }

        /// <summary>Gets or sets the icon.</summary>
        [DataMember(Order = 11, Name = "icon")]
        internal string Icon { get; set; }

        /// <summary>Gets or sets the id.</summary>
        [DataMember(Order = 10, Name = "id")]
        internal int Id { get; set; }

        /// <summary>Gets or sets the level.</summary>
        [DataMember(Order = 3, Name = "level")]
        internal int Level { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [DataMember(Order = 0, Name = "name")]
        internal string Name { get; set; }

        /// <summary>Gets or sets the rarity.</summary>
        [DataMember(Order = 4, Name = "rarity")]
        internal string Rarity { get; set; }

        /// <summary>Gets or sets the restrictions.</summary>
        [DataMember(Order = 9, Name = "restrictions")]
        internal ICollection<string> Restrictions { get; set; }

        /// <summary>Gets or sets the type.</summary>
        [DataMember(Order = 2, Name = "type")]
        internal string Type { get; set; }

        /// <summary>Gets or sets the vendor value.</summary>
        [DataMember(Order = 6, Name = "vendor_value")]
        internal int VendorValue { get; set; }
    }
}