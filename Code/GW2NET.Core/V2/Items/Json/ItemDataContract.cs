// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    internal sealed class ItemDataContract
    {
        #region Properties

        [DataMember(Order = 5, Name = "default_skin")]
        internal string DefaultSkin { get; set; }

        [DataMember(Order = 1, Name = "description")]
        internal string Description { get; set; }

        [DataMember(Order = 12, Name = "details")]
        internal DetailsDataContract Details { get; set; }

        [DataMember(Order = 8, Name = "flags")]
        internal ICollection<string> Flags { get; set; }

        [DataMember(Order = 7, Name = "game_types")]
        internal ICollection<string> GameTypes { get; set; }

        [DataMember(Order = 11, Name = "icon")]
        internal string Icon { get; set; }

        [DataMember(Order = 10, Name = "id")]
        internal int Id { get; set; }

        [DataMember(Order = 3, Name = "level")]
        internal int Level { get; set; }

        [DataMember(Order = 0, Name = "name")]
        internal string Name { get; set; }

        [DataMember(Order = 4, Name = "rarity")]
        internal string Rarity { get; set; }

        [DataMember(Order = 9, Name = "restrictions")]
        internal ICollection<string> Restrictions { get; set; }

        [DataMember(Order = 2, Name = "type")]
        internal string Type { get; set; }

        [DataMember(Order = 6, Name = "vendor_value")]
        internal int VendorValue { get; set; }

        #endregion
    }
}